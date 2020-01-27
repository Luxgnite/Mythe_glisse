using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPhase : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AkSoundEngine.PostEvent("Police_alarm_event", GameManager.instance.gameObject);
        AkSoundEngine.SetState("Explo_or_chase_group", "Chase");
    }
}
