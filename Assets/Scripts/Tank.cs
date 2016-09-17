// Tank Script

using UnityEngine;
using System.Collections.Generic;

public class Tank : MonoBehaviour
{
    private Transform transform;
    private Rigidbody2D rigidbody;
    private List<Collider2D> triggerList = new List<Collider2D>();
    private float roadCondition = 1f;
    [HideInInspector] public BoxCollider2D collider;

    public float maxSpeed;
    public float force; // This parameter controls both speed and rotation
    public List<ParticleSystem> dustEffect;
    public float width = 2f;

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
        rigidbody.AddForceAtPosition(transform.up * force * roadCondition, transform.position + transform.right*width * rotationDirection);

        // Set max speed and angular speed to prevent quantum leap.
        // rigidbody.velocity = Vector2.ClampMagnitude(rigidbody.velocity, maxSpeed);
        // rigidbody.angularVelocity = Mathf.Clamp(rigidbody.angularVelocity, -maxAngularVelocity, maxAngularVelocity);
    }

    public static GameObject tankEnumToPrefab(TankEnum tankEnum) {
        return Resources.Load("Prefabs/" + tankEnum.ToString()) as GameObject;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        triggerList.Add(col);
        CheckOnRoad();
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(triggerList.Contains(col))
            triggerList.Remove(col);
        CheckOnRoad();
    }
    void CheckOnRoad()
    {
        if(triggerList.Exists(col => col.GetComponent<Road>() != null))
        {
            roadCondition = 1f;
            dustEffect.ForEach(e => e.Stop());
        }
        else
        {
            roadCondition = 0.5f;
            dustEffect.ForEach(e => e.Play());
        }
    }
}
