using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    public GameObject targetObject;
    public string textDisplay;
    public float timeToDie;
    public float yOffset = 2f;
    public Text text;
    public RectTransform positionUI;

    private bool fadeout;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = textDisplay;    
        positionUI = GetComponent<RectTransform>();

        StartCoroutine(FadeOut());
    }

    // Update is called once per frame
    void Update()
    {
        positionUI.position = new Vector3(targetObject.transform.position.x, targetObject.transform.position.y + yOffset, positionUI.position.z);
    }

    void DestroyNotification()
    {
        //NotificationManager.instance.notifications.Find(
        Destroy(this.gameObject);
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(timeToDie - 1f);

        text.CrossFadeAlpha(0f, 1f, false);

        StartCoroutine(DestroyNotif());
    }

    IEnumerator DestroyNotif()
    {
        yield return new WaitForSeconds(1);

        DestroyNotification();
    }
}
