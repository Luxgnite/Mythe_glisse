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
            movementPlayer.baseSpeed = punishmentSpeed;
            movementPlayer.canJump = false;
            movementPlayer.canAccel = false;
            movementPlayer.actualSpeedLevel = 0;
            GameManager.instance.LoseLife();
        }

        if(collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Moto>().StopMovement();
            collision.GetComponent<Moto>().enabled = false;
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
