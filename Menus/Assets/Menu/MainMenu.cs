using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadScene("GameM&K");
        }

        public void Quitgame()
        {
            Debug.Log("QUIT");
            Application.Quit();
        }
    }
}
