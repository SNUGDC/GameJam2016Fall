using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

    public GameObject gameObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
	}
}
