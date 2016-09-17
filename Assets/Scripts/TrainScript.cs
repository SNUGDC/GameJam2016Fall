// Train Script

using UnityEngine;
using System.Collections;
using UnityEditorInternal;

public class TrainScript : MonoBehaviour
{
    private Transform transform;
    private Rigidbody2D rigidbody;

    public float maxSpeed;
    public float maxAngularVelocity; 
    public float force; // This parameter controls both speed and rotation
    public float rotationDirection; // -1 or 1 // rotating clockwise or counterclockwise


    void Awake () {
	    transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody2D>();

	    maxSpeed = 10;
        force = 10;
        maxAngularVelocity = 360;

        rotationDirection = 1; // counterclockwise

	}
	
	void Update () {
        if (Input.GetButtonDown("Fire1")) {
            toggleDirection();
        }
    }

    void FixedUpdate() {
        rigidbody.AddForceAtPosition(transform.up * force, transform.position + transform.right * rotationDirection);
        rigidbody.velocity = Vector2.ClampMagnitude(rigidbody.velocity, maxSpeed);
        rigidbody.angularVelocity = Mathf.Clamp(rigidbody.angularVelocity, -maxAngularVelocity, maxAngularVelocity);
   }
    void toggleDirection() {
        rotationDirection *= -1;
    }
}
