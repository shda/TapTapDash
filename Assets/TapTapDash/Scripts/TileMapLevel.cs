using System;
using System.Collections.Generic;
using System.Linq;
using SuperTiled2Unity;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

namespace TapTapDash.Scripts
{
    public class TileMapLevel : MonoBehaviour
    {
        [SerializeField] private SuperMap map;
        [SerializeField] private Tilemap tilemapService; 
        [SerializeField] private Tilemap tilemapGame;

      //  public Vector3 StartPosition;
      //  public Vector3 FinishPosition;

        private void Awake()
        {
           // StartPosition = CalcStartPoint(tilemapService , "start");
           // FinishPosition = CalcStartPoint(tilemapService ,"finish");
           
           HideServiceLayer();
        }

        public void HideServiceLayer()
        {
            var render = tilemapService.GetComponent<TilemapRenderer>();
            render.enabled = false;
        }

        //Todo: need optimization
        public Vector3 GetStartPosition()
        {
            return CalcStartPoint(tilemapService , "start");
        }

        //Todo: need optimization
        public Vector3 GetFinishPosition()
        {
            return CalcStartPoint(tilemapService , "finish");
        }
      

        private void Start()
        {
            /*
            foreach (var pos in tilemapControl.cellBounds.allPositionsWithin)
            {
                var tile = tilemapControl.GetTile(pos);
                
                if (tile)
                {
                    if (tile is SuperTile superTile)
                    {
                        Matrix4x4 transformMatrix = tilemapControl.GetTransformMatrix(pos);
                        Quaternion rotation = transformMatrix.rotation;
                        if (rotation != Quaternion.identity)
                        {
                            Debug.Log($"Тайл в {pos} повёрнут на угол: {rotation.eulerAngles}");
                        }
                    }
                }
            }
            */
        }

        public float GetAngleTile(Vector3 position)
        {
            return 0;
            
            var pos = tilemapService.WorldToCell(position);
            var tile = tilemapService.GetTile(pos);

            if (!tile)
                return 0.0f;
            
            if (tile is SuperTile superTile)
            {
                /*
                if (superTile.TryGetProperty("isJump", out CustomProperty property))
                {
                    return property.GetValueAsBool();
                }
                */
            }

            return 0;
        }

        public bool TryGetIJump(Vector3 position)
        {
            var pos = tilemapGame.WorldToCell(position);
            var tile = tilemapGame.GetTile(pos);
            
            if (!tile)
                return false;

            if (tile is SuperTile superTile)
            {
                if (superTile.TryGetProperty("isJump", out CustomProperty property))
                {
                    return property.GetValueAsBool();
                }
            }

            return false;
        }

        public bool IsTile(Vector3 position)
        {
            var pos = tilemapGame.WorldToCell(position);
            var tile = tilemapGame.GetTile(pos);
            return tile;
        }

        public bool TryGetDirectionByTileWorld(Vector3 position , out Direction direction)
        {
            direction = Direction.Left;

            var pos = tilemapGame.WorldToCell(position);
            var tile = tilemapGame.GetTile(pos);
            
            if (!tile)
                return false;

            if (tile is SuperTile superTile)
            {
                if (superTile.TryGetProperty("direction",  out CustomProperty property))
                {
                    direction = property.m_Value switch
                    {
                        "left" => Direction.Left,
                        "right" => Direction.Right,
                        "up" => Direction.Up,
                        "down" => Direction.Down,
                        _ => direction
                    };

                    return true;
                }
            }

            return false;
        }

        private Vector3 CalcStartPoint(Tilemap tilemap, string valueByName)
        {
            var tiles = FindTileByNameProperty(tilemap ,"name");

            foreach (var tile in tiles)
            {
                var nameValue = tile.Tile.GetPropertyValueAsString("name");
                if (string.Equals(nameValue, valueByName, StringComparison.Ordinal))
                {
                    return  tilemap.GetCellCenterWorld(tile.Position);
                }
            }
            
            throw new Exception("Could not find tile map tile named " + valueByName);
        }

        private SuperTileCoord[] FindTileByNameProperty(Tilemap tilemap, string propName)
        {
            var tiles = new List<SuperTileCoord>();
            
            foreach (var pos in tilemap.cellBounds.allPositionsWithin)
            {
                var tile = tilemap.GetTile(pos);
                
                if (tile)
                {
                    if (tile is SuperTile superTile)
                    {
                        if (superTile.m_CustomProperties != null)
                        {
                            if (superTile.TryGetProperty(propName,  out CustomProperty property))
                            {
                                tiles.Add(new SuperTileCoord(superTile , pos));
                            }
                        }
                    }
                }
            }
            return tiles.ToArray();
        }
        
        private void OnValidate()
        {
            if (!map)
            {
                map = GetComponent<SuperMap>();
            }
            
            if (!tilemapService)
            {
                tilemapService = transform.GetComponentsInChildren<Tilemap>()
                    .FirstOrDefault(x => x.name == "Service");
            }
            
            if (!tilemapGame)
            {
                tilemapGame = transform.GetComponentsInChildren<Tilemap>()
                    .FirstOrDefault(x => x.name == "Walk");
            }
        }

        public bool IsPointInTileMap(Vector3 point)
        {
            var bounds = GetTilemapWorldBounds(tilemapGame);
            return bounds.Contains(point);
        }

        private Bounds GetTilemapWorldBounds(Tilemap tilemap)
        {
            // Получаем границы в локальных координатах тайлмапа
            tilemap.CompressBounds(); // Обновляем границы
            BoundsInt cellBounds = tilemap.cellBounds;

            // Если тайлмап пуст, возвращаем нулевые границы
            if (cellBounds.size == Vector3Int.zero)
                return new Bounds(Vector3.zero, Vector3.zero);

            // Конвертируем ячейки в мировые координаты
            Vector3 minWorld = tilemap.CellToWorld(cellBounds.min);
            Vector3 maxWorld = tilemap.CellToWorld(cellBounds.max);

            // Учитываем размер одного тайла (обычно 1x1, но может быть иначе)
            Vector3 tileSize = tilemap.cellSize;
            maxWorld += tileSize; // Добавляем размер последнего тайла

            // Создаём Bounds, который охватывает всю тайлмапу
            Bounds worldBounds = new Bounds();
            worldBounds.SetMinMax(minWorld, maxWorld);

            return worldBounds;
        }
    }
}