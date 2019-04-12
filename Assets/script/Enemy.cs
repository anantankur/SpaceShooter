using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Rigidbody2D rb;
    public GameObject bullet, explosion;

    public float xSpeed, ySpeed;
    public int score;

    public bool canShoot;
    public float fireRate, health;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() {

        Destroy(gameObject, 10);

        if (!canShoot) return;

        fireRate = fireRate + Random.Range(fireRate / -2, fireRate / 2);
        InvokeRepeating("Shoot", fireRate, fireRate);

    }

    void Update() {
        rb.velocity = new Vector2(xSpeed, ySpeed*-1);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<SpaceShip>().Damage();
            Die();
        }
    }

    void Die() {
        Instantiate(explosion, transform.position, Quaternion.identity);
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);
        Destroy(gameObject);
    }

    public void Damage() {
        health--;
        if(health ==0) {
            Die();
        }
    }

    void Shoot() {
        GameObject temp = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
        temp.GetComponent<Bullet>().ChangeDirection();
    }
}
