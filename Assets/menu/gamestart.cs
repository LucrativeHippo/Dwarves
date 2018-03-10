using UnityEngine;
using UnityEngine.SceneManagement;

public class gamestart : MonoBehaviour
{


    public void changescene(string scenename)
    {

        SceneManager.LoadScene(scenename);

        Time.timeScale = 1.0f;

    }
}

