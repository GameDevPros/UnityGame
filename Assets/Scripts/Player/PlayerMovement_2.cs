using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_2 : MonoBehaviour {

	public float moveSpeed = 50;

	Rigidbody rb;

    Camera viewCamera;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        viewCamera = Camera.main;
    }
	
	void FixedUpdate () 
	{
		float hor = Input.GetAxisRaw("Horizontal");
        float var = Input.GetAxisRaw("Vertical");    
		var rigidbody = GetComponent<Rigidbody>();

		rigidbody.velocity = new Vector3(hor,0, var).normalized * moveSpeed;

		float angleRad = Mathf.Atan2 (hor, var);
		float angleDeg = angleRad * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0,angleDeg,0);
	}
}
