using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public KeyCode actionKey;
    public GameObject projectile;
    public float cooldownDuration;
    private GameObject player;
    private GameObject spawnPoint;

    private bool canFire;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        spawnPoint = gameObject;
        canFire = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (player != null && Input.GetKey(actionKey) && canFire)
        {
            Vector3 direction = (spawnPoint.transform.localPosition.normalized);
            if (projectile != null)
            {
                Vector3 height = projectile.transform.position;
                GameObject bullet = Instantiate(projectile, player.transform.position + height + (direction * 0.2f), Quaternion.identity);
                bullet.GetComponent<PlayerProjectile>().direction = direction;

                IEnumerator co = Cooldown(cooldownDuration);
                StartCoroutine(co);
            }
        }
    }

    private IEnumerator Cooldown(float time)
    {
        canFire = false;
        yield return new WaitForSeconds(time);
        canFire = true;
    }
}
