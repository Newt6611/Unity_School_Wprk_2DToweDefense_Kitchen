using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;
    public Transform SpawnTopSide;
    public Transform SpawnBottomSide;
    float topY;
    float bottomY;

    public float SpawnTime;
    float SpawnTimeBTW;

    void Start()
    {
        topY = SpawnTopSide.position.y;
        bottomY = SpawnBottomSide.position.y;
    }

    void Update()
    {
        if (SpawnTimeBTW < 0)
        {
            Spawn();
            SpawnTimeBTW = SpawnTime;
        }
        else
        {
            SpawnTimeBTW -= Time.deltaTime;
        }

        Level();
        Debug.Log(SpawnTime);
    }

    void Spawn()
    {
        float spawnYPos = Random.Range(bottomY, topY);
        int spawnIndex = Random.Range(0, EnemyPrefabs.Length);
        IEnemy e = Instantiate(EnemyPrefabs[spawnIndex], new Vector3(transform.position.x, spawnYPos, transform.position.z), Quaternion.identity).GetComponent<IEnemy>();
    }

    void Level()
    {
        if (GameManager.gameTime < 110)
        {
            SpawnTime = 3.5f;
        }
        if (GameManager.gameTime < 80)
        {
            SpawnTime = 2f;
        }
        if (GameManager.gameTime < 65)
        {
            SpawnTime = 1f;
        }
        if (GameManager.gameTime < 55)
        {
            SpawnTime = 0.5f;
        }
        if (GameManager.gameTime < 45)
        {
            SpawnTime = 0.2f;
        }
    }

}
