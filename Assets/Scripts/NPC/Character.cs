using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour{
    public float damage = 1f;
    public float atkSpeed = 1f;

    public bool isEnemy;

    void Start(){
        isEnemy = CompareTag("Enemy");
    }

    public bool isMyEnemy(GameObject go){
        Character c = go.GetComponent<Character>();
        
        return go != null && c != null && c.isEnemy != this.isEnemy;
    }
}