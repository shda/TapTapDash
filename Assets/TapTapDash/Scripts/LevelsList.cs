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
        public AssetReferenceT<GameObject>[] Levels => levels;
        public string[] LevelNames => levelNames;
        
        [Button]
        private void Reverse()
        {
            levels = levels.Reverse().ToArray();
        }
        
        private void OnValidate()
        {
            levelNames = Levels.Select(x => x.editorAsset.name).ToArray();
        }
    }
}