using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float punishmentSpeed = 3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            MovementController movementPlayer = GameManager.instance.player.GetComponent<MovementController>();
            movementPlayer.StopMovement();
            movementPlayer.baseSpeed = punishmentSpeed;
            movementPlayer.canJump = false;
            movementPlayer.canAccel = false;
            movementPlayer.actualSpeedLevel = 0;
            GameManager.instance.LoseLife();
            AkSoundEngine.PostEvent("Crash_obstacle_event", GameManager.instance.gameObject);
        }

        if(collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Moto>().StopMovement();
            collision.GetComponent<Moto>().enabled = false;
            AkSoundEngine.SetState("Moto_or_not_group", "No_Moto");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MovementController movementPlayer = GameManager.instance.player.GetComponent<MovementController>();
            movementPlayer.baseSpeed = movementPlayer.originalBaseSpeed;
            movementPlayer.canJump = true;
            movementPlayer.canAccel = true;
        }
    }
}
