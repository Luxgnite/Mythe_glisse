using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Transform character;
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        character = transform;
    }

    // Update is called once per frame
    void Update()
    {
        character.Translate(new Vector3(speed * Input.GetAxis("Horizontal") *Time.deltaTime ,0f,0f));
    }
}
