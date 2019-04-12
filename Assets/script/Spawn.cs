using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject[] enemies;
    public float rate;

    void Start() {
        InvokeRepeating("SpawnEnemy", 1, rate);
    }
    
    void SpawnEnemy() {
        Instantiate(enemies[(int)Random.Range(0, enemies.Length)], new Vector3(Random.Range(-9.1f, 9.1f), 6.5f, 0), Quaternion.identity);
    }
}
