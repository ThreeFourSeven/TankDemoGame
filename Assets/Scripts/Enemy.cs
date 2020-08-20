using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float moveSpeed = 1.0f;
    public float rotationSpeed = 1.0f;
    public GameObject bulletObject;
    public float bulletSpeed = 10.0f;
    public GameObject target;
    public float bulletSize = 1.0f;
    public GameObject hpBar;
    public float bulletDamage = 1.0f;
    public float armor = 1.0f;

    public GameObject hpDrop;
    public float hpDropChance = .35f;

    public float timeTillFire = 2.0f;
    public float timeTillNewDirection = 5.0f;
    public float range = 10.0f;
    private float timeCtr = 0.0f;
    private float moveCtr = 0.0f;

    private Vector3 movement;
    private Vector3 direction;
    private GameObject tread;
    private GameObject turret;
    private float health = 100;
    private const float MAX_HP = 100;

    // Start is called before the first frame update
    void Start()
    {
        tread = transform.GetChild(0).gameObject;
        turret = transform.GetChild(1).gameObject;
        movement = new Vector3();
        direction = Vector3.Normalize(new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)));
    }

    void Update()
    {
        if (Globals.paused)
            return;
        if (health > 0)
        {
            hpBar.transform.localScale = new Vector3(health / MAX_HP, hpBar.transform.localScale.y, hpBar.transform.localScale.z);
        }
        else {
            hpBar.transform.localScale = new Vector3(0.0f, hpBar.transform.localScale.y, hpBar.transform.localScale.z);
            float v = Random.Range(0.0f, 1.0f);
            if (v <= hpDropChance)
            {
                Instantiate(hpDrop, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Globals.paused)
            return;
        turret.GetComponent<Turret>().target = target.transform.position - transform.position;
        timeCtr += Time.deltaTime;
        if (timeCtr >= timeTillFire) {
            Vector3 direction = turret.GetComponent<Turret>().GetDirection();
            Vector3 p = transform.position - new Vector3(0, 0, -.5f);
            GameObject go = Instantiate(bulletObject, p, Quaternion.identity);
            Vector2 d2d = new Vector2(direction.x, direction.y);
            d2d.Normalize();
            go.GetComponent<Bullet>().direction = Vector3.Normalize(direction) * bulletSpeed;
            go.GetComponent<Bullet>().parent = gameObject;
            go.GetComponent<Bullet>().damage = bulletDamage;
            go.transform.localScale = new Vector3(bulletSize * go.transform.localScale.x, bulletSize * go.transform.localScale.y, bulletSize * go.transform.localScale.z);
            timeCtr = 0.0f;
        }
        moveCtr += Time.deltaTime;
        if (moveCtr >= timeTillNewDirection) {
            direction = Vector3.Normalize(new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)));
            moveCtr = 0.0f;
        }
        if ((target.transform.position - transform.position).magnitude > range) {
            direction = Vector3.Normalize(target.transform.position - transform.position);
        }
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        tread.transform.localRotation = Quaternion.RotateTowards(tread.transform.localRotation, Quaternion.Euler(0, 0, -angle), 2*rotationSpeed);
        movement = direction;
        GetComponent<Rigidbody2D>().MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);
    }

    void OnDestroy()
    {
        

    }

    public void Damage(float dmg)
    {
        health -= dmg / armor;
    }
}
