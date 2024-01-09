using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Screen or button on click switches to scene
   public void switchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
