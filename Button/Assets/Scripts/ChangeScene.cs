using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ChangeScene : MonoBehaviour
{
    public string URL = "https://github.com/B00123338/MyGame";
   public void GoToScene1()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void GoToScene2()
    {
        SceneManager.LoadScene("Scene2");
    }

    public void loadurl()
    {
        Application.OpenURL(URL);
    }
}
