using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TriInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace TapTapDash.Scripts
{
    [CreateAssetMenu(menuName = "Create LevelsList", fileName = "LevelsList", order = 0)]
    public class LevelsList : ScriptableObject
    {
        [SerializeField] private AssetReferenceT<GameObject>[] levels;
        
        [SerializeField] [ReadOnly] private string[] levelNames;
        //public AssetReferenceT<GameObject>[] Levels => levels;
        public string[] LevelNames => levelNames;
        
        public AssetReferenceT<GameObject> GetLevel(int index)
        {
            return levels[index % levels.Length];
        }

        public int CountLevels()
        {
            return levels.Length;
        }
        
        public IEnumerable<AssetReferenceT<GameObject>> GetLevels()
        {
            return levels;
        }
        
        [Button]
        private void Reverse()
        {
            levels = levels.Reverse().ToArray();
        }
        
        private void OnValidate()
        {
            levelNames = levels.Select(x => x.editorAsset.name).ToArray();
        }
    }
}