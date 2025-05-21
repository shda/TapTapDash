using SuperTiled2Unity;
using UnityEngine;

namespace TapTapDash.Scripts
{
    public class LevelLines : MonoBehaviour
    {
        [SerializeField] private MovementLine[] lines;

        private void Awake()
        {
            lines =  gameObject.GetComponentsInChildren<MovementLine>();

            float z = 0;
            foreach (var line in lines)
            {
                z += 0.01f;
                line.transform.position += new Vector3(0,0,z);
            }
        }
    }
}