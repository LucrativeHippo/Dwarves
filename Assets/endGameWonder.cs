using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGameWonder : MonoBehaviour {

    void Start()
    {
        GameObject.Find("Calendar").GetComponent<StormBringer>().resetStorms(50, Weather.weatherTypes.HELLFIRE);

        GameObject.Find("Anagram_Revealler").GetComponent<SpriteRenderer>().enabled = true;

        light = GameObject.Find("Directional light");
        light.GetComponent<AmbientLight>().enabled = false;
        light.GetComponent<Light>().intensity = 2f;
        


        StartCoroutine(animatorTimer());
    }

    private GameObject light;


    public IEnumerator animatorTimer()
    {
        
        yield return new WaitForSeconds(6f);
        light.GetComponent<Light>().color = Color.red;
        GameObject.Find("Anagram_Revealler").GetComponent<Animator>().enabled = true;
        StartCoroutine(endGameTimer());
    
}

    public IEnumerator endGameTimer()
    {

        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("endGame");
    }
}
