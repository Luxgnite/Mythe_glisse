using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawnEnemy : MonoBehaviour
{
    public SpawnEnemy toTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGERED");
        if (collision.gameObject.tag == "Player")
        {
            AkSoundEngine.PostEvent("Police_alarm_event", GameManager.instance.gameObject);
            toTrigger.Spawn();
        }
    }
}
