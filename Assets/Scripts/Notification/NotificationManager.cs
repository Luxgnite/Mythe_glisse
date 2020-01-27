using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    public Notification worldNotification;
    public Canvas worldCanvas;

    public Canvas UICanvas;
    public Warning warning;

    //public List<Notification> notifications;

    public static NotificationManager instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void DisplayWorldNotification(string text, GameObject target, float timeToDie)
    {
        Notification tempNotifRef = Instantiate(worldNotification);
        tempNotifRef.targetObject = target;
        tempNotifRef.textDisplay = text;
        tempNotifRef.timeToDie = timeToDie;

        tempNotifRef.transform.SetParent(worldCanvas.transform, false);

        //notifications.Add(tempNotifRef);
    }

    public void DisplayWarning()
    {
        Warning tempNotifRef = Instantiate(warning);

        tempNotifRef.transform.SetParent(UICanvas.transform, false);
    }
}
