using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Rigidbody2D rb;
    int dir = 1;

    void Start() {
        Destroy(gameObject, 2);
    }

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ChangeDirection() {
        dir *= -1;
    }

    void Update() {
        rb.velocity = new Vector2(0 ,10 * dir);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(dir == 1) {
            if (collision.gameObject.tag == "Enemy") {
                collision.gameObject.GetComponent<Enemy>().Damage();
                Destroy(gameObject);
            }
        } else {
            if (collision.gameObject.tag == "Player") {
                collision.gameObject.GetComponent<SpaceShip>().Damage();
                Destroy(gameObject);
            }
        }

    }
}
