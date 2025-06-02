using System.Linq;
using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TapTapDash.Scripts
{
    public class LevelSelectGrid : MonoBehaviour
    {
        [SerializeField] private LevelButton levelButtonPrefab;
        [SerializeField] private Transform rootButtons;
        [SerializeField] private LevelsList levelsList;
        [SerializeField] private SceneReference gameScene;

        private void Awake()
        {
            var childrens = rootButtons.Cast<Transform>().ToArray();
            foreach (var children in childrens)
            {
                DestroyImmediate(children.gameObject);
            }

            for (var i = 0; i < levelsList.Levels.Length; i++)
            {
                // var level = levelsList.Levels[i];
                var newButton = Instantiate(levelButtonPrefab, rootButtons);
                newButton.SetLevel(i , levelsList.LevelNames[i]);

                var i1 = i;
                newButton.OnClick = () =>
                {
                    SelectLevel.SelectedLevelIndex = i1;
                    SceneManager.LoadScene(gameScene.Name);
                };
            }
        }
    }
}