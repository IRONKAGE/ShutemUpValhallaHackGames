using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    float randX;
    float randY;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    int enemiesCount = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn && enemiesCount < 13)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-2.7f, 2.7f);
            randY = Random.Range(10f, 100f);
            enemiesCount += enemiesCount + 1;

            whereToSpawn = new Vector2(randX, randY);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }
    }
}
