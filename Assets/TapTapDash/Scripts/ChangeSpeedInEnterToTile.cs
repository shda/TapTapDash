using SuperTiled2Unity;
using UnityEngine;

namespace TapTapDash.Scripts
{
    public class ChangeSpeedInEnterToTile : MonoBehaviour
    {
        [SerializeField] private Hero hero;
        [SerializeField] private LevelLoader levelLoader;

        private SuperTileCoord _lastTile;
        private void Update()
        {
            if (hero.IsInJump)
                return;
            
            var currentPosition = hero.transform.position;

            var tileMapLevel = levelLoader.GetTileMapByPositon(currentPosition);
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