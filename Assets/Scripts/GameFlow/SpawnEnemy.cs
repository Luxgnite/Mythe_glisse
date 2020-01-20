using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Enemy enemySpawned { get; private set; }
    public Enemy spawnableEnemy;

    public void Awake()
    {
        enemySpawned = null;
    }

    public void Spawn()
    {
        if (enemySpawned == null)
        {
            Debug.Log(this.gameObject.name + " is spawning " + spawnableEnemy);
            enemySpawned = Instantiate(spawnableEnemy, this.transform.position, Quaternion.identity, this.transform);
        }
    }
}
