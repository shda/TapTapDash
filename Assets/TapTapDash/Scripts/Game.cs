using System;
using BlockBlast.Scripts.Game;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace TapTapDash.Scripts
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private LevelLoader  levelLoader;
        [SerializeField] private Hero hero;
        [SerializeField] private InputHandler inputHandler;
        [SerializeField] private GameOverScreen gameOverScreen;
        [SerializeField] private RotateCameraByHeroDirection rotateCameraByHeroDirection;

        [SerializeField] private TileMapLevel tileMapLevel;
        [SerializeField] private Vector3 offsetHeroByGrid;
        
        private bool _isInitialized = false;

        private void Awake()
        {
            gameOverScreen.gameObject.SetActive(false);
            gameOverScreen.OnRestartGame = OnRestartGame;

            inputHandler.OnTap = OnTap;
        }

        private void Start()
        {
            LoadLevel();
        }

        private async void LoadLevel()
        {
            hero.IsMoving = false;
            _isInitialized = false;
            
            var startConnector = await levelLoader.LoadConnector();
            tileMapLevel = await levelLoader.LoadLevelAndConnectToConnector(startConnector, 0);
            
            hero.transform.position = startConnector.GetStartPosition() + offsetHeroByGrid;
            
            _isInitialized = true;
            hero.IsMoving = true;
        }

        private void OnRestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void Update()
        {
            if(!_isInitialized)
                return;
            
            if (hero.IsInJump)
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
            if (hero.IsInJump)
                return;

            var directionOffset = hero.Direction.ToVector2();
            var currentPosition = hero.transform.position;
            var foundAction = false;

            while (!foundAction)
            {
                if (tileMapLevel.IsTile(currentPosition))
                {
                    if (tileMapLevel.TryGetDirectionByTileWorld(currentPosition, out Direction newDirection))
                    {
                        hero.SetDirection(newDirection);
                        rotateCameraByHeroDirection.SetDirection(newDirection);
                        foundAction = true;
                    }

                    if (tileMapLevel.TryGetIJump(currentPosition))
                    {
                        hero.StartJumpAsync();
                        foundAction = true;
                    }
                }
                else
                {
                    foundAction = true;
                }

                currentPosition += (Vector3)directionOffset;
            }
        }
    }
}