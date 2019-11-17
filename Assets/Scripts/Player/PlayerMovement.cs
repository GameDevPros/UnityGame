using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    
    Rigidbody rb;
    Camera viewCamera;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        viewCamera = Camera.main;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal"),0, Input.GetAxisRaw("Vertical")).normalized * moveSpeed;

        Ray cameraRay = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlan = new Plane(Vector3.up, Vector3.zero);
        float rayLenght;

        if(groundPlan.Raycast(cameraRay, out rayLenght))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLenght);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }
}
