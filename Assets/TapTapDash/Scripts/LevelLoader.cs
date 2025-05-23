using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace TapTapDash.Scripts
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private AssetReferenceT<GameObject>[] levels;
        [SerializeField] private AssetReferenceT<GameObject> levelConnector;
        
        public async UniTask<TileMapLevel> LoadConnector()
        {
            var connector = await levelConnector.LoadAssetOrGetAsync();
            var newConnector = Instantiate(connector);
            return newConnector.GetComponent<TileMapLevel>();
        }

        public async UniTask<TileMapLevel> LoadLevelAndConnectToConnector(TileMapLevel connector , int levelIndex)
        {
            var level = await levels[levelIndex].LoadAssetOrGetAsync();
            var newLevel = Instantiate(level).GetComponent<TileMapLevel>();
            
            SetLevelToFinishPoint(connector ,  newLevel);
            
            return newLevel.GetComponent<TileMapLevel>();
        }

        public void SetLevelToFinishPoint(TileMapLevel finishPoint, TileMapLevel startPoint)
        {
            var finishPosition = finishPoint.GetFinishPosition();
            var startPosition = startPoint.GetStartPosition();
            
            startPoint.transform.position = startPoint.transform.position - startPosition + finishPosition;
        }
    }
}