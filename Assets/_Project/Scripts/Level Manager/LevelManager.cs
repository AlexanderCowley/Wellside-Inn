using UnityEngine;
using UnityEngine.SceneManagement;

namespace wellside
{
    public class LevelManager : MonoBehaviour
    {
        public void NextScene()
        {
            if(SceneManager.GetActiveScene().buildIndex + 1 == 3)
                LoadMainMenu();
            else
                SceneManager.LoadScene
                    (SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void LoadMainMenu() => SceneManager.LoadScene(0);

        public void QuitGame() => Application.Quit();

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextScene();
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                LoadMainMenu();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                QuitGame();
            }
        }
    }
}