using UnityEngine;
using System.Collections;

public class CannonBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt((Vector2)transform.position + GetComponent<Rigidbody2D>().velocity, Vector3.right);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("boom");
        if (col.rigidbody != null)
        {
            col.rigidbody.angularDrag = Random.Range(-5, 5);
        }
        
    }

    void OnDestroy()
    {

    }
}
