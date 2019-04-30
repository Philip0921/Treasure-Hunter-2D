using UnityEngine;
using UnityEngine.SceneManagement;

public class Playlist : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Menu")
        {
            AudioManager.INSTANCE.Play("MainMusic");
        }

        if (sceneName == "Level1")
        {
            AudioManager.INSTANCE.Stop("MainMusic");
            AudioManager.INSTANCE.Play("GameMusic");
        }

        //if (sceneName == "Level2")
        //{
        //    AudioManager.instance.Stop("MainMusic");
        //    AudioManager.instance.Play("GameMusic");
        //}


        if (sceneName == "GameOver")
        {
            AudioManager.INSTANCE.Play("MainMusic");
            AudioManager.INSTANCE.Stop("GameMusic");
        }
    }


}
