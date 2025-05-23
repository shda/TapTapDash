using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public class FixedGridAtlasCreator : EditorWindow
{
    private const int CELL_SIZE = 128;
    private const int INITIAL_ATLAS_SIZE = 1024;
    private const int MAX_ATLAS_SIZE = 8192;

    [MenuItem("Tools/Create Grid Atlas (128x128 cells)")]
    public static void CreateGridAtlas()
    {
        // Получаем выделенные спрайты
        Object[] selectedObjects = Selection.objects;
        if (selectedObjects.Length == 0)
        {
            Debug.LogError("No sprites selected!");
            return;
        }

        // Собираем все спрайты
        List<Texture2D> sprites = new List<Texture2D>();
        foreach (Object obj in selectedObjects)
        {
            if (obj is Sprite sprite)
            {
                sprites.Add(GetReadableTexture(sprite));
            }
            else if (obj is Texture2D texture)
            {
                sprites.Add(GetReadableTexture(texture));
            }
        }

        if (sprites.Count == 0)
        {
            Debug.LogError("No valid sprites found!");
            return;
        }

        // Рассчитываем необходимый размер атласа
        int atlasSize = CalculateAtlasSize(sprites.Count);
        Texture2D atlasTexture = new Texture2D(atlasSize, atlasSize, TextureFormat.RGBA32, false);

        // Очищаем атлас (прозрачный фон)
        Color[] clearPixels = new Color[atlasSize * atlasSize];
        for (int i = 0; i < clearPixels.Length; i++) clearPixels[i] = Color.clear;
        atlasTexture.SetPixels(clearPixels);

        // Располагаем спрайты в сетке
        int cellsPerRow = atlasSize / CELL_SIZE;
        for (int i = 0; i < sprites.Count; i++)
        {
            int row = i / cellsPerRow;
            int col = i % cellsPerRow;

            // Проверяем, что хватает места
            if (row * CELL_SIZE >= atlasSize)
            {
                Debug.LogError("Atlas is too small to fit all sprites!");
                break;
            }

            // Позиция ячейки (верхний левый угол)
            int x = col * CELL_SIZE;
            int y = atlasSize - (row + 1) * CELL_SIZE; // Начинаем сверху

            // Копируем спрайт в ячейку (без центрирования)
            Texture2D sprite = sprites[i];
            int copyWidth = Mathf.Min(CELL_SIZE, sprite.width);
            int copyHeight = Mathf.Min(CELL_SIZE, sprite.height);
            
            // Если спрайт меньше ячейки - он останется в левом верхнем углу ячейки
            atlasTexture.SetPixels(x, y, copyWidth, copyHeight, sprite.GetPixels(0, 0, copyWidth, copyHeight));
        }

        atlasTexture.Apply();

        // Сохраняем PNG
        string savePath = EditorUtility.SaveFilePanel("Save Grid Atlas PNG", "Assets", "GridAtlas.png", "png");
        if (!string.IsNullOrEmpty(savePath))
        {
            File.WriteAllBytes(savePath, atlasTexture.EncodeToPNG());
            
            // Создаем файл с информацией о позициях
            CreateAtlasMetaFile(savePath, sprites.Count, atlasSize);
            
            AssetDatabase.Refresh();
            Debug.Log($"Grid atlas saved to: {savePath}");
            Debug.Log($"Atlas size: {atlasSize}x{atlasSize}, Cells: {cellsPerRow}x{cellsPerRow}");
        }
    }

    // Рассчитываем минимально необходимый размер атласа
    private static int CalculateAtlasSize(int spriteCount)
    {
        int size = INITIAL_ATLAS_SIZE;
        while (true)
        {
            int cellsAvailable = (size / CELL_SIZE) * (size / CELL_SIZE);
            if (cellsAvailable >= spriteCount || size >= MAX_ATLAS_SIZE)
                break;
            
            size *= 2;
        }

        if (size > MAX_ATLAS_SIZE)
        {
            Debug.LogError($"Cannot fit all sprites in {MAX_ATLAS_SIZE}x{MAX_ATLAS_SIZE} atlas!");
            return MAX_ATLAS_SIZE;
        }

        return size;
    }

    // Создаем читаемую текстуру из спрайта
    private static Texture2D GetReadableTexture(Sprite sprite)
    {
        Texture2D tex = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height, TextureFormat.RGBA32, false);
        Color[] pixels = sprite.texture.GetPixels(
            (int)sprite.rect.x, 
            (int)sprite.rect.y, 
            (int)sprite.rect.width, 
            (int)sprite.rect.height);
        tex.SetPixels(pixels);
        tex.Apply();
        return tex;
    }

    // Создаем читаемую текстуру из Texture2D
    private static Texture2D GetReadableTexture(Texture2D source)
    {
        RenderTexture rt = RenderTexture.GetTemporary(
            source.width,
            source.height,
            0,
            RenderTextureFormat.Default,
            RenderTextureReadWrite.Linear);

        Graphics.Blit(source, rt);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = rt;

        Texture2D readableTex = new Texture2D(source.width, source.height);
        readableTex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        readableTex.Apply();

        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(rt);
        return readableTex;
    }

    // Создаем файл с метаданными атласа
    private static void CreateAtlasMetaFile(string atlasPath, int spriteCount, int atlasSize)
    {
        string metaPath = Path.ChangeExtension(atlasPath, ".json");
        
        int cellsPerRow = atlasSize / CELL_SIZE;
        var metaData = new List<object>();
        
        for (int i = 0; i < spriteCount; i++)
        {
            int row = i / cellsPerRow;
            int col = i % cellsPerRow;
            
            metaData.Add(new {
                index = i,
                cellX = col * CELL_SIZE,
                cellY = atlasSize - (row + 1) * CELL_SIZE,
                cellSize = CELL_SIZE
            });
        }
        
        File.WriteAllText(metaPath, Newtonsoft.Json.JsonConvert.SerializeObject(metaData, Newtonsoft.Json.Formatting.Indented));
    }
}