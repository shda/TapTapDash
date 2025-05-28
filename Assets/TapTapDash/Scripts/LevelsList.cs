using UnityEngine;
using UnityEngine.AddressableAssets;

namespace TapTapDash.Scripts
{
    [CreateAssetMenu(menuName = "Create LevelsList", fileName = "LevelsList", order = 0)]
    public class LevelsList : ScriptableObject
    {
        [SerializeField] private AssetReferenceT<GameObject>[] levels;
        public AssetReferenceT<GameObject>[] Levels => levels;
    }
}