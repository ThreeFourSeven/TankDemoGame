using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject parent;
    public float timeTillDeath = 10.0f;
    public Vector2 direction = new Vector2();
    public float damage = 1.0f;
    public GameObject collisionParticleEffect;
    private float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update() {
        timer += Time.deltaTime;
        if (timer >= timeTillDeath)
        {
            Destroy(gameObject);
            timer = 0;
        }
    }

    void FixedUpdate() {
        transform.localPosition = transform.localPosition + new Vector3(direction.x, direction.y, 0.0f)*Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != parent)
        {
            bool hit = false;
            if (collision.gameObject.GetComponent<Player>() != null)
            {
                collision.gameObject.GetComponent<Player>().Damage(damage);
                hit = true;
            }
            if (collision.gameObject.GetComponent<Enemy>() != null && parent.GetComponent<Enemy>() == null)
            {
                collision.gameObject.GetComponent<Enemy>().Damage(damage);
                hit = true;
            }
            if (hit)
            {
                Instantiate(collisionParticleEffect, transform.position + new Vector3(0, 0, -1), Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

}
