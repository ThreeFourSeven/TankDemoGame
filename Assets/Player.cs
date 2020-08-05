using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject bulletObject;
    public float bulletSpeed = 10.0f;

    public float moveSpeed = 1.0f;
    public float rotationSpeed = 1.0f;
    public float bulletSize = 1.0f;
    public GameObject hpBar;
    public float bulletDamage = 1.0f;
    public float armor = 1.0f;

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
        direction = new Vector3();
    }

    void Update()
    {
        if (health > 0) {
            hpBar.transform.localScale = new Vector3(health / MAX_HP, hpBar.transform.localScale.y, hpBar.transform.localScale.z);
        }
        else
        {
            hpBar.transform.localScale = new Vector3(0.0f, hpBar.transform.localScale.y, hpBar.transform.localScale.z);
        }

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 mp = Input.mousePosition;
        turret.GetComponent<Turret>().target = Camera.main.ScreenToWorldPoint(new Vector3(mp.x, mp.y, mp.z)) - transform.position;
        if (Input.GetMouseButtonDown(0)) {
            Vector3 d = turret.GetComponent<Turret>().GetDirection();
            Vector3 p = transform.position - new Vector3(0, 0, -.5f);
            GameObject go = Instantiate(bulletObject, p, Quaternion.identity);
            Vector2 d2d = new Vector2(d.x, d.y);
            d2d.Normalize();
            go.GetComponent<Bullet>().direction = new Vector3(d2d.x, d2d.y, 0.0f) * bulletSpeed;
            go.GetComponent<Bullet>().parent = gameObject;
            go.GetComponent<Bullet>().damage = bulletDamage;
            go.transform.localScale = new Vector3(bulletSize * go.transform.localScale.x, bulletSize * go.transform.localScale.y, bulletSize * go.transform.localScale.z);
        }
        movement.Set(0, 0, 0);
        movement.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        if (movement.magnitude > 0.0)
            direction.Set(movement.x, movement.y, movement.z);
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        tread.transform.localRotation = Quaternion.RotateTowards(tread.transform.localRotation, Quaternion.Euler(0, 0, -angle), 2*rotationSpeed);
        GetComponent<Rigidbody2D>().MovePosition(transform.position + movement*moveSpeed*Time.deltaTime);
    }

    public void Heal(float amt) {
        health += amt;
    }

    public void Damage(float dmg) {
        health -= dmg / armor;
    }
}

