using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endGame : MonoBehaviour {
    GameObject player;
    private Text gameOverText;
    private Text backToMenu;
    private bool gameOver = false;

	// Use this for initialization
	void Start () {
        player = MetaScript.getPlayer();
        gameOverText.text = " ";
        backToMenu.text = " ";
	}
	
	// Update is called once per frame
	void Update () {
        if (player.GetComponent<Health>().getHealth() <= 0 && MetaScript.GetNPC().getCount() ==0 ){
            gameEnds();
        }
	}

    void gameEnds(){
        gameOver = true;

    }
}
