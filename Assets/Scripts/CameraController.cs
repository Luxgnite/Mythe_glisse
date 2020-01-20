using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject targetFollow;
    Transform targetFollowTransform;
    public float distanceX;
    public float distanceY;

    void Start()
    {
        targetFollowTransform = targetFollow.GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(targetFollowTransform.position.x + distanceX, targetFollowTransform.position.y + distanceY, -10);

    }
}
