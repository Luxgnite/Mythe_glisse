using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWarning : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            NotificationManager.instance.DisplayWarning();
    }
}
