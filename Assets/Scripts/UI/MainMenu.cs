using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void switchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
