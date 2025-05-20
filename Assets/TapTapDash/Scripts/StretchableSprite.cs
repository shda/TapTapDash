using UnityEngine;

namespace TapTapDash.Scripts
{
    public class StretchableSprite : MonoBehaviour
    {
        public SpriteRenderer spriteRenderer;

        private void OnValidate()
        {
            if (spriteRenderer == null)
                spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
}
