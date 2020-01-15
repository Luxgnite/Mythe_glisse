using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    public Camera camera;
    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, this.transform.position.z) ;        
    }
}
