using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace TapTapDash.Scripts
{
    public class EventHeroEnterInNewTileMap : MonoBehaviour
    {
        [SerializeField] private Hero hero;
        [SerializeField] private LevelLoader levelLoader;

        private TileMapLevel _lastEnterLevel;

        public UnityEvent<TileMapLevel> OnHeroEnterNewLevel;
        
        private void Start()
        {
            CheckSpeedInMapAsync().Forget();
        }
        
        private async UniTask CheckSpeedInMapAsync()
        {
            while (!destroyCancellationToken.IsCancellationRequested)
            {
                ChangeSpeedIfNeed();
                await UniTask.Delay(100);
            }
        }
        
        private void ChangeSpeedIfNeed()
        {
            var currentPosition = hero.transform.position;
            var tileMapLevel = levelLoader.GetTileMapByPositon(currentPosition);
            if (tileMapLevel && tileMapLevel != _lastEnterLevel)
            {
                _lastEnterLevel = tileMapLevel;
                OnHeroEnterNewLevel?.Invoke(tileMapLevel);
            }
        }
    }
}