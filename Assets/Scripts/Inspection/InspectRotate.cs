using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class InspectRotate : MonoBehaviour 
{
    private float smooth = 5.0f;
    private float tiltAngle = 60.0f;

    void Update()
    {
        // TODO: Rotate object on world co-rds instead of local.
        // Rotate object to look at camera.
        
        // KJ: Got rid of on mouse down for now...
        //if (Input.GetMouseButton(0))
        //{
        
        // Smoothly tilts a transform towards a target rotation.
        float tiltY = Input.GetAxis("Horizontal") * tiltAngle * -1;
        float tiltX = Input.GetAxis("Vertical") * tiltAngle;

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(tiltX, tiltY, 0);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
        
        //}
    }
}