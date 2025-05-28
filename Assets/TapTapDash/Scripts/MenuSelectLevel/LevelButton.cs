using System;
using TMPro;
using UnityEngine;

namespace TapTapDash.Scripts
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI label;
        private int LevelNumber { get; set; }
        
        public Action OnClick;

        public void OnClickButton()
        {
            OnClick?.Invoke();
        }
        
        public void SetLevel(int levelNumber)
        {
            LevelNumber = levelNumber;
            label.text = $"{LevelNumber}";
        }
    }
}