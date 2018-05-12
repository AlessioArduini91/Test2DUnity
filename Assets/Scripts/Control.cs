using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Control : MonoBehaviour {
    Rigidbody2D rb;
    public float velocity = 5f;
    float accelerationPower = 5f;
    float steeringPower = 5f;
    float steeringAMount, speed, direction;
    float directionX;
    float directionY;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        directionX = CrossPlatformInputManager.GetAxis("Horizontal") * velocity * Time.deltaTime;
        directionY = CrossPlatformInputManager.GetAxis("Vertical") * velocity * Time.deltaTime;

        //rb.velocity = new Vector2(directionX * 10, directionY); 

        transform.position = new Vector2(transform.position.x + directionX, transform.position.y + directionY);

        steeringAMount = -Input.GetAxis("Horizontal");
        speed = Input.GetAxis("Vertical") * accelerationPower;
        direction = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
        rb.rotation += steeringAMount * steeringPower + rb.velocity.magnitude * direction;
        rb.AddRelativeForce(Vector2.up * speed);
        rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * steeringAMount / 2);
	}
}
