using SuperTiled2Unity;
using UnityEngine;

namespace TapTapDash.Scripts
{
    public class ChangeSpeedFromTileMap : MonoBehaviour
    {
        [SerializeField] private Hero hero;
        
        public void ChangeSpeedIfNeed(TileMapLevel  tileMapLevel)
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