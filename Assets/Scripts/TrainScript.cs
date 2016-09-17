// Train Script

using UnityEngine;
using System.Collections;
using UnityEditorInternal;

public class TrainScript : MonoBehaviour
{
    public Transform transform;
    public float maxSpeed; // unit: m/s
    public float speed;
    public float acceleration; // unit: m/s^2
    public float angularSpeed; // unit: degree/s
    public float rotationDirection; // -1 or 1 // rotating clockwise or counterclockwise


    void Awake () {
	    transform = GetComponent<Transform>();
	    maxSpeed = 10;
	    acceleration = 3;
        angularSpeed = 180;

        speed = 0;
        rotationDirection = 1; // counterclockwise
	}
	
	void Update () {
	    if (speed < maxSpeed) {
	        speed = Mathf.Min(speed + acceleration*Time.deltaTime, maxSpeed);
	    }

        transform.Rotate(0, 0, angularSpeed * Time.deltaTime * rotationDirection);
        transform.position += transform.up * speed * Time.deltaTime;

        if (Input.GetButtonDown("Fire1")) {
            toggleDirection();
        }
    }

    void toggleDirection() {
        rotationDirection *= -1;
    }
}
