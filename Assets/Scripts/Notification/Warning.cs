using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeOut());
    }
    void DestroyNotification()
    {
        //NotificationManager.instance.notifications.Find(
        Destroy(this.gameObject);
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(3f);

        StartCoroutine(DestroyNotif());
    }

    IEnumerator DestroyNotif()
    {
        yield return new WaitForSeconds(1);

        DestroyNotification();
    }
}
