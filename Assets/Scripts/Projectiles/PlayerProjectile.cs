using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour {

    public Vector3 direction;
    public float speed;
    public float lifespan;
    public int damage;

    private float timePassed;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        timePassed += Time.deltaTime;
        if (timePassed >= lifespan)
        {
            Destroy(gameObject);
        }

        Vector3 newPos = transform.position;
        Vector3 distance = direction * speed * Time.deltaTime;
        newPos += distance;

        transform.position = newPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            Health bar = other.GetComponent<Health>();
            if (bar != null)
            {
                bar.damage(damage);
                Destroy(gameObject);
            }
        }
    }
}
