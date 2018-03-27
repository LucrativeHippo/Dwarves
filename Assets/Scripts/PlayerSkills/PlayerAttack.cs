using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public GameObject projectile;
    public float cooldownDuration;
    private GameObject player;
    private GameObject spawnPoint;

    private bool canFire;
    private Controls controls;

	// Use this for initialization
	void Start () {
        player = MetaScript.getPlayer();
        spawnPoint = gameObject;
        canFire = true;
        controls = MetaScript.GetControls();
	}
	
	// Update is called once per frame
	void Update () {
        if (player != null && controls.key(controls.Attack) && canFire)
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
