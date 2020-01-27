using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moto : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AkSoundEngine.SetState("Moto_or_not_group", "Moto");
        AkSoundEngine.PostEvent("Police_moto_event", GameManager.instance.gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    public void StopMovement()
    {
        rb.velocity = Vector2.zero;
    }
}
