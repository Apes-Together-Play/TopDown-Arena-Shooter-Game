using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneController
{
    [CreateAssetMenu(menuName = "SceneOpener")]
    public class SceneOpener : ScriptableObject
    {
        [SerializeField] private string sceneName; 
        public void OpenSelectionScene()
        { 
            SceneManager.LoadScene(sceneName);
        }
    }
}