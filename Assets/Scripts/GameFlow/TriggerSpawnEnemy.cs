using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawnEnemy : Trigger
{
    public SpawnEnemy toTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGERED");
        if (collision.gameObject.tag == "Player")
        {
            toTrigger.Spawn();
        }
    }
}
