using System.Collections.Generic;
using System.Threading;
using BlockBlast.Scripts.Common;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace TapTapDash.Scripts
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private Hero hero;
        [SerializeField] private int maxLevelsLoad = 3;
        [SerializeField] private float minDistanceToLoadNextLevel = 100f;
        [SerializeField] private LevelsList levels;
        
        [SerializeField] private PoolGameObjectsComponent<TileMapLevel> _levelConnectorsPool;
        
        public bool IsInitStartLevel {get; private set;}
        
        private readonly Queue<TileMapLevel> _loadedLevels = new();
        private TileMapLevel _lastLoadedConnector;
        private CancellationTokenSource _cancelToken;
        
        public int CurrentLevelIndex { get; set; }
        
        public async UniTask<TileMapLevel> LoadLevelsStartOf(int index)
        {
            await PreloadConnectors();
            _lastLoadedConnector = _levelConnectorsPool.Get();
            _lastLoadedConnector.transform.position = Vector3.zero;
            
            CurrentLevelIndex = index;
            
            _cancelToken?.Cancel();
            _cancelToken = new CancellationTokenSource();
            UpdateAsync(_cancelToken.Token).Forget();
            return _lastLoadedConnector;
        }
        
        private async UniTask UpdateAsync(CancellationToken token)
        {
            while(!token.IsCancellationRequested)
            {
                while (_loadedLevels.Count < maxLevelsLoad)
                {
                    var level = await LoadLevelAndConnectToConnector(_lastLoadedConnector , CurrentLevelIndex);
                    if(token.IsCancellationRequested)
                        return;
                    
                    _loadedLevels.Enqueue(level);
                    
                    _lastLoadedConnector = _levelConnectorsPool.Get();
                    SetLevelToFinishPoint(level, _lastLoadedConnector);
                    
                    CurrentLevelIndex++;
                }
                
                if(token.IsCancellationRequested)
                    return;
                
                if(Vector3.Distance(
                       hero.transform.position , _lastLoadedConnector.transform.position) < minDistanceToLoadNextLevel)
                {
                    var first = _loadedLevels.Dequeue();
                    first.gameObject.SetActive(false);
                    
                    Destroy(first.gameObject);
                }

                IsInitStartLevel = true;
                await UniTask.Yield();
            }
        }
        
        private async UniTask PreloadConnectors()
        {
            _levelConnectorsPool.Init();
        }

        private async UniTask<TileMapLevel> LoadLevelAndConnectToConnector(TileMapLevel connector , int levelIndex)
        {
            Debug.Log($"Loading level {levelIndex}");
            
            var level = await levels.Levels[levelIndex].LoadAssetOrGetAsync();
            var newLevel = Instantiate(level).GetComponent<TileMapLevel>();
            
            SetLevelToFinishPoint(connector ,  newLevel);
            
            return newLevel;
        }

        private void SetLevelToFinishPoint(TileMapLevel finishPoint, TileMapLevel startPoint)
        {
            var finishPosition = finishPoint.GetFinishPosition();
            var startPosition = startPoint.GetStartPosition();
            
            startPoint.transform.position = startPoint.transform.position - startPosition + finishPosition;
        }

        private void OnDestroy()
        {
            _cancelToken?.Cancel();
            
            foreach (var level in levels.Levels)
            {
                level.ReleaseAsset();
            }
        }

        public TileMapLevel GetTileMapByPositon(Vector3 point)
        {
            foreach (var tileMapLevel in _loadedLevels)
            {
                if (tileMapLevel.IsPointInTileMap(point))
                {
                    return tileMapLevel;
                }
            }

            return null;
        }
    }
}