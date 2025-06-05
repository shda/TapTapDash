using System.Collections.Generic;
using System.Threading;
using BlockBlast.Scripts.Common;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace TapTapDash.Scripts
{
    public class LoadingLevelInRuntime : MonoBehaviour
    {
        [SerializeField] private Hero hero;
        [SerializeField] private int maxLevelsLoad = 3;
        [SerializeField] private float minDistanceToLoadNextLevel = 100f;
        [SerializeField] private LevelsList levels;
        [SerializeField] private PoolGameObjectsComponent<TileMapLevel> _levelConnectorsPool;
        
        public bool IsInitStartLevel {get; private set;}
        
        private readonly Queue<TileMapLevel> _loadedLevels = new();
        private readonly List<TileMapLevel> _connectors = new();
        private TileMapLevel _lastLoadedConnector;
        private CancellationTokenSource _cancelToken;
        
        public int CurrentLevelIndex { get; set; }
        
        public async UniTask<TileMapLevel> LoadLevelsStartOf(int index)
        {
            await PreloadConnectors();
            _lastLoadedConnector = _levelConnectorsPool.Get();
            _lastLoadedConnector.transform.position = Vector3.zero;
            _lastLoadedConnector.SetLevelNumber(index);
            
            _connectors.Add(_lastLoadedConnector);
            
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
                    
                    _lastLoadedConnector.SetLevelNumber(CurrentLevelIndex);
                    _connectors.Add(_lastLoadedConnector);
                }
                
                if(token.IsCancellationRequested)
                    return;
                
                RemoveOldLevels();
                UpdateLastLevel();
                
                IsInitStartLevel = true;
                await UniTask.Yield();
            }
        }

        private void RemoveOldLevels()
        {
            if(Vector3.Distance(
                   hero.transform.position , _lastLoadedConnector.transform.position) < minDistanceToLoadNextLevel)
            {
                var first = _loadedLevels.Dequeue();
                first.gameObject.SetActive(false);
                    
                Destroy(first.gameObject);
            }
        }

        private void UpdateLastLevel()
        {
            foreach (var connector in _connectors)
            {
                if (Vector3.Distance(connector.transform.position, hero.transform.position) < 7)
                {
                    if (connector.CurrentLevelIndex > SelectLevel.SelectedLevelIndex)
                    {
                        SelectLevel.SelectedLevelIndex = connector.CurrentLevelIndex;
                        Debug.Log(connector.CurrentLevelIndex);
                    }
                }
            }
        }

        private async UniTask PreloadConnectors()
        {
            _levelConnectorsPool.Init();
        }

        private async UniTask<TileMapLevel> LoadLevelAndConnectToConnector(TileMapLevel connector , int levelIndex)
        {
            Debug.Log($"Loading level {levelIndex}");
            
            var level = await levels.GetLevel(levelIndex).LoadAssetOrGetAsync();
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
            
            foreach (var level in levels.GetLevels())
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