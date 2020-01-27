using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNotif : MonoBehaviour
{
    public string text;
    public GameObject target;
    public float timeToDie;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            NotificationManager.instance.DisplayWorldNotification(text, target, timeToDie);
    }
}
