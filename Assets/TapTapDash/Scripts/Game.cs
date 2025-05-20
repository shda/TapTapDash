using System;
using BlockBlast.Scripts.Game;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TapTapDash.Scripts
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private LevelLines levelLines;
        [SerializeField] private InputHandler inputHandler;
        [SerializeField] private Hero hero;
        [SerializeField] private GameOverScreen gameOverScreen;
        [SerializeField] private RotateCameraByDirection rotateCameraByDirection;

        private void Awake()
        {
            gameOverScreen.gameObject.SetActive(false);
            gameOverScreen.OnRestartGame = OnRestartGame;
            
            inputHandler.OnTap = OnTap;
        }

        private void OnRestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void Update()
        {
            var coll = hero.GetCollider();
            if (!coll && hero.IsMoving)
            {
                hero.IsMoving = false;
                gameOverScreen.gameObject.SetActive(true);
            }
        }

        private void OnTap()
        {
            var coll = hero.GetCollider();
            if (coll)
            {
                var line = coll.GetComponentInParent<MovementLine>();
                if (line)
                {
                    hero.SetDirection(line.DirectionAfterTab);  
                    rotateCameraByDirection.SetDirection(line.DirectionAfterTab);
                }
            }
        }
    }
}