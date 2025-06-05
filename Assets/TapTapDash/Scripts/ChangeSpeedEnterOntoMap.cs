using Cysharp.Threading.Tasks;
using SuperTiled2Unity;
using UnityEngine;
using UnityEngine.Serialization;

namespace TapTapDash.Scripts
{
    public class ChangeSpeedEnterOntoMap : MonoBehaviour
    {
        [SerializeField] private Hero hero;
        [FormerlySerializedAs("levelLoader")] [SerializeField] private LoadingLevelInRuntime loadingLevelInRuntime;

        private TileMapLevel _lastEnterLevel;
        
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
            var tileMapLevel = loadingLevelInRuntime.GetTileMapByPositon(currentPosition);
            if (tileMapLevel && tileMapLevel != _lastEnterLevel)
            {
                _lastEnterLevel = tileMapLevel;
                ChangeSpeedIfNeed(tileMapLevel);
            }
        }


        public void ChangeSpeedIfNeed(TileMapLevel tileMapLevel)
        {
            if (tileMapLevel.Properties)
            {
                if (tileMapLevel.Properties.TryGetCustomProperty("speed", out var customProperty))
                {
                    var speed = customProperty.GetValueAsFloat();
                    hero.SetSpeed(speed);
                }
            }
        }
    }
}