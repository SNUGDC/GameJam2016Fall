using UnityEngine;
using System.Collections;

public class MagnetBullet : MonoBehaviour {

    GameObject Owner;
    GameObject Prey;

    Rigidbody2D OwnerRb;
    Rigidbody2D PreyRb;

	// Use this for initialization
	void Start () {
        OwnerRb = Owner.GetComponent<Rigidbody2D>();
        PreyRb = Prey.GetComponent<Rigidbody2D>();

        Destroy(gameObject, 2f);
	}
	
	// Update is called once per frame
	void Update () {
        if (OwnerRb.mass >= PreyRb.mass)
        {
            Prey.transform.position = Vector2.Lerp(Prey.transform.position, Owner.transform.position, 0.75f);

        }
        else
        {
            Owner.transform.position = Vector2.Lerp(Owner.transform.position, Prey.transform.position, 0.75f);
        }
    }


}
