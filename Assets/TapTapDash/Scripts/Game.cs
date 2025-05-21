using System;
using BlockBlast.Scripts.Game;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TapTapDash.Scripts
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private InputHandler inputHandler;
        [SerializeField] private Hero hero;
        [SerializeField] private GameOverScreen gameOverScreen;
        [SerializeField] private RotateCameraByDirection rotateCameraByDirection;

        [SerializeField] private TileMapLevel tileMapLevel;
        [SerializeField] private Vector3 offsetHeroByGrid;

        private void Awake()
        {
            gameOverScreen.gameObject.SetActive(false);
            gameOverScreen.OnRestartGame = OnRestartGame;
            
            inputHandler.OnTap = OnTap;
        }

        private void Start()
        {
            hero.transform.position = tileMapLevel.StartPosition + offsetHeroByGrid;
        }

        private void OnRestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void Update()
        {
            if(hero.IsJumping)
                return;
            
            var coll = hero.GetCollider();
            if (!coll && hero.IsMoving)
            {
                hero.IsMoving = false;
                gameOverScreen.gameObject.SetActive(true);
            }
        }

        private void OnTap()
        {
            if(hero.IsJumping)
                return;
            
            if (tileMapLevel.TryGetDirectionByTileWorld(hero.transform.position, out Direction direction))
            {
                hero.SetDirection(direction);  
                rotateCameraByDirection.SetDirection(direction);
            }

            if (tileMapLevel.TryGetIJump(hero.transform.position))
            {
                hero.StartJumpAsync();
            }
        }
    }
}