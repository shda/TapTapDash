using UnityEditor;
using UnityEngine;
using UnityEngine;
using UnityEditor;

namespace TapTapDash.Scripts.Editor
{
    [CustomEditor(typeof(MovementLine))]
    public class SpriteRendererEditor : UnityEditor.Editor
    {
        private MovementLine movementLine;
        private bool isResizing = false;
        private Vector2 originalSize;
        private Vector3 originalPosition;
        private Vector3 originalScale;

        // Якоря (0-1, где 0 - лево/низ, 1 - право/верх)
        private Vector2 anchor = new Vector2(0.5f, 0.5f); // По центру по умолчанию

        // Стили для GUI
        private GUIStyle anchorButtonStyle;

        private void OnEnable()
        {
            movementLine = (MovementLine)target;
        }

        private void OnGUI()
        {
            // Инициализация стиля кнопок якорей
            anchorButtonStyle = new GUIStyle(GUI.skin.button);
            anchorButtonStyle.fixedWidth = 20;
            anchorButtonStyle.fixedHeight = 20;
        }
        /*
       public override void OnInspectorGUI()
       {
           base.OnInspectorGUI();

           EditorGUILayout.Space();
           EditorGUILayout.LabelField("Anchor Settings", EditorStyles.boldLabel);

           // Отображение сетки якорей
           EditorGUILayout.BeginVertical();
           EditorGUILayout.BeginHorizontal();
           GUILayout.FlexibleSpace();
           if (GUILayout.Button("↖", anchorButtonStyle)) anchor = new Vector2(0, 1);
           if (GUILayout.Button("↑", anchorButtonStyle)) anchor = new Vector2(0.5f, 1);
           if (GUILayout.Button("↗", anchorButtonStyle)) anchor = new Vector2(1, 1);
           GUILayout.FlexibleSpace();
           EditorGUILayout.EndHorizontal();

           EditorGUILayout.BeginHorizontal();
           GUILayout.FlexibleSpace();
           if (GUILayout.Button("←", anchorButtonStyle)) anchor = new Vector2(0, 0.5f);
           if (GUILayout.Button("★", anchorButtonStyle)) anchor = new Vector2(0.5f, 0.5f);
           if (GUILayout.Button("→", anchorButtonStyle)) anchor = new Vector2(1, 0.5f);
           GUILayout.FlexibleSpace();
           EditorGUILayout.EndHorizontal();

           EditorGUILayout.BeginHorizontal();
           GUILayout.FlexibleSpace();
           if (GUILayout.Button("↙", anchorButtonStyle)) anchor = new Vector2(0, 0);
           if (GUILayout.Button("↓", anchorButtonStyle)) anchor = new Vector2(0.5f, 0);
           if (GUILayout.Button("↘", anchorButtonStyle)) anchor = new Vector2(1, 0);
           GUILayout.FlexibleSpace();
           EditorGUILayout.EndHorizontal();
           EditorGUILayout.EndVertical();

           // Точные значения якорей
           anchor = EditorGUILayout.Vector2Field("Anchor Position", anchor);
       }
       */


        private void OnSceneGUI()
        {
            var spriteRenderer = movementLine.Sprite;
            
            if (spriteRenderer.sprite == null) return;

            // Получаем текущие размеры спрайта
            Vector2 size = spriteRenderer.sprite.bounds.size;
            Vector3 scale = spriteRenderer.transform.localScale;
            Vector3 worldSize = new Vector3(size.x * scale.x, size.y * scale.y, 1);

            // Позиция спрайта
            Vector3 position = spriteRenderer.transform.position;

            // Рассчитываем точку якоря в мировых координатах
            Vector3 anchorPoint = position - new Vector3(
                worldSize.x * (0.5f - anchor.x),
                worldSize.y * (0.5f - anchor.y),
                0);

            // Рисуем прямоугольник вокруг спрайта
            Handles.DrawWireCube(position, worldSize);

            // Рисуем точку якоря
            Handles.color = Color.yellow;
            Handles.DotHandleCap(0, anchorPoint, Quaternion.identity, HandleUtility.GetHandleSize(anchorPoint) * 0.1f,
                EventType.Repaint);

            // Добавляем манипуляторы для растягивания
            Vector3 rightHandlePos = position + new Vector3(worldSize.x / 2, 0, 0);
            Vector3 leftHandlePos = position - new Vector3(worldSize.x / 2, 0, 0);
            Vector3 topHandlePos = position + new Vector3(0, worldSize.y / 2, 0);
            Vector3 bottomHandlePos = position - new Vector3(0, worldSize.y / 2, 0);

            // Обработка манипуляторов с учетом якоря
            EditorGUI.BeginChangeCheck();

            Vector3 newRightHandlePos = Handles.PositionHandle(rightHandlePos, Quaternion.identity);
            Vector3 newLeftHandlePos = Handles.PositionHandle(leftHandlePos, Quaternion.identity);
            Vector3 newTopHandlePos = Handles.PositionHandle(topHandlePos, Quaternion.identity);
            Vector3 newBottomHandlePos = Handles.PositionHandle(bottomHandlePos, Quaternion.identity);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(movementLine, "Resize Sprite");

                // Вычисляем изменение размеров
                float deltaRight = newRightHandlePos.x - rightHandlePos.x;
                float deltaLeft = newLeftHandlePos.x - leftHandlePos.x;
                float deltaTop = newTopHandlePos.y - topHandlePos.y;
                float deltaBottom = newBottomHandlePos.y - bottomHandlePos.y;

                // Новые размеры
                float newWidth = worldSize.x + deltaRight - deltaLeft;
                float newHeight = worldSize.y + deltaTop - deltaBottom;

                // Новый масштаб
                Vector3 newScale = new Vector3(
                    newWidth / size.x,
                    newHeight / size.y,
                    1);

                // Вычисляем смещение позиции на основе якоря
                Vector3 positionOffset = new Vector3(
                    deltaLeft + (deltaRight - deltaLeft) * anchor.x,
                    deltaBottom + (deltaTop - deltaBottom) * anchor.y,
                    0);
   
                // Применяем изменения
                spriteRenderer.transform.localScale = newScale;
                movementLine.transform.position += positionOffset;
                movementLine.ArrowChangeDirection.transform.localPosition += positionOffset;
            }
        }
    }
}