// Train Script

using UnityEngine;
using System.Collections;
using UnityEditorInternal;

public class TrainScript : MonoBehaviour
{
    private Transform transform;
    private Rigidbody2D rigidbody;

    public float maxSpeed;
    public float force; // This parameter controls both speed and rotation
    private float maxAngularVelocity; // Probably don't need to be public?
    private float rotationDirection; // -1 or 1 // rotating clockwise or counterclockwise

    public KeyCode key;


    void Awake () {
	    transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody2D>();
        
        maxAngularVelocity = 360;
        rotationDirection = 1; // counterclockwise
    }
	
	void Update () {
        if (Input.GetKeyDown(key)) {
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
