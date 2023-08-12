using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneController
{
    public class MainMenuManager : MonoBehaviour
    {
        public void PlayButtonAction()
        {
            SceneManager.LoadScene("CharacterSelection");
        }

        public void SettingsButtonAction()
        {
            // Todo
        }

        public void QuitButtonAction()
        {
            Application.Quit();
        }
    }
}