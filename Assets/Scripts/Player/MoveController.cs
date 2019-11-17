using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float throwSpeed = 500f;
    public float mouseRot = 50f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal");
        float var = Input.GetAxis("Vertical");          

        if(Input.GetMouseButton(1))
        {
            transform.Translate(hor * moveSpeed * Time.fixedDeltaTime, 0,var * moveSpeed * Time.deltaTime);  
            float rotX = Input.GetAxis("Mouse X")* mouseRot * Mathf.Deg2Rad;
            transform.Rotate ( Vector3.up, rotX);
        }
        else
        {
            transform.Translate(0, 0,var * moveSpeed * Time.deltaTime);  
            transform.Rotate(0, hor * throwSpeed * Time.deltaTime, 0);
        }
    }

    
}
