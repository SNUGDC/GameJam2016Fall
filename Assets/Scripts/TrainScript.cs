// Tank Script

using UnityEngine;

public class TrainScript : MonoBehaviour
{
    private Transform transform;
    private Rigidbody2D rigidbody;
    [HideInInspector] public BoxCollider2D collider;

    public float maxSpeed;
    public float force; // This parameter controls both speed and rotation

    private float maxAngularVelocity = 360; // Probably don't need to be public?
    private float rotationDirection = 1; // -1 or 1 // rotating clockwise or counterclockwise

    public KeyCode key; // The one keycode to rule them all.


    void Awake () {
	    transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }
	
	void Update () {
        if (Input.GetKeyDown(key)) {
            ToggleDirection();
        }
    }
    void ToggleDirection() {
        rotationDirection *= -1;
    }

    void FixedUpdate() {
        // Handle both rotation and acceleration by adding force at transform.right
        rigidbody.AddForceAtPosition(transform.up * force, transform.position + transform.right*2 * rotationDirection);

        // Set max speed and angular speed to prevent quantum leap.
        rigidbody.velocity = Vector2.ClampMagnitude(rigidbody.velocity, maxSpeed);
        rigidbody.angularVelocity = Mathf.Clamp(rigidbody.angularVelocity, -maxAngularVelocity, maxAngularVelocity);
    }
}
