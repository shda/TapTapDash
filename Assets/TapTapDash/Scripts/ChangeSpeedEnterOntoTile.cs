using SuperTiled2Unity;
using UnityEngine;
using UnityEngine.Serialization;

namespace TapTapDash.Scripts
{
    public class ChangeSpeedEnterOntoTile : MonoBehaviour
    {
        [SerializeField] private Hero hero;
        [FormerlySerializedAs("levelLoader")] [SerializeField] private LoadingLevelInRuntime loadingLevelInRuntime;

        private SuperTileCoord _lastTile;
        private void Update()
        {
            if (hero.IsInJump)
                return;
            
            var currentPosition = hero.transform.position;

            var tileMapLevel = loadingLevelInRuntime.GetTileMapByPositon(currentPosition);
            if (tileMapLevel)
            {
                var tile = tileMapLevel.GetByTileWorldOrNull(currentPosition);
                if(tile == null)
                    return;
                
                if (_lastTile == null|| !_lastTile.Equals(tile))
                {
                    _lastTile = tile;

                    var addSpeed = tile.Tile.GetPropertyValueAsFloat("addSpeed" , 0);
                    hero.AddSpeed(addSpeed);
                }
                
            }
        }
    }
}