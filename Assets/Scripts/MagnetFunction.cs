using UnityEngine;
using System.Collections;

public class MagnetFunction : MonoBehaviour {

    public float magnetPower;
    public GameObject Owner;
    public GameObject Prey;
    
    // Use this for initialization
    void Start () {
        Prey = gameObject;
        //PreyRb = Prey.GetComponent<Rigidbody2D>();
        Destroy(this, 1f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Prey.GetComponent<Rigidbody2D>().AddForce((Owner.transform.position - Prey.transform.position).normalized * magnetPower);
        Owner.GetComponent<Rigidbody2D>().AddForce((Prey.transform.position - Owner.transform.position).normalized * magnetPower);



    }
}
