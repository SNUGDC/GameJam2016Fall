using UnityEngine;
using System.Collections;

public class MagnetBullet : MonoBehaviour {

    public float magnetPower;
    public GameObject Owner;
    public GameObject Prey;

    Rigidbody2D OwnerRb;
    Rigidbody2D PreyRb;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update () {

        transform.LookAt((Vector2)transform.position + GetComponent<Rigidbody2D>().velocity, Vector3.right);

        //if (Owner != null)
        //{
        //    OwnerRb = Owner.GetComponent<Rigidbody2D>();
        //    Debug.Log(Owner);

        //}
        //if (Prey != null)
        //{
            //if (OwnerRb.mass >= PreyRb.mass)
            //{

            //    Debug.Log("Pulling");
            //    //Debug.Break();
            //    //Prey.transform.position = Vector2.Lerp(Prey.transform.position, Owner.transform.position, 0.1f);
            //    Prey.GetComponent<Rigidbody2D>().AddForce((Owner.transform.position - Prey.transform.position).normalized * magnetPower);
            //}
            //else
            //{
            //    Debug.Log("Going");
            //    //Debug.Break();
            //    //Owner.transform.position = Vector2.Lerp(Owner.transform.position, Prey.transform.position, 0.1f);
            //    Owner.GetComponent<Rigidbody2D>().AddForce((Prey.transform.position - Owner.transform.position).normalized * magnetPower);

            //}

           
               
                //Prey.GetComponent<Rigidbody2D>().AddForce((Owner.transform.position - Prey.transform.position).normalized * magnetPower);
                //Owner.GetComponent<Rigidbody2D>().AddForce((Prey.transform.position - Owner.transform.position).normalized * magnetPower);

         

        //}

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Magnet!");
        if (col.rigidbody != null)
        {
            var effect = EffectSpawner.instance.GetEffect("hit");
            effect.transform.position = transform.position;
            effect.SetActive(true);

            Prey = col.gameObject;
            PreyRb = Prey.GetComponent<Rigidbody2D>();

            var Funtion = Prey.AddComponent<MagnetFunction>();

            Funtion.Owner = Owner;
            Funtion.magnetPower = magnetPower;
            Destroy(gameObject);
            //Debug.Break();
        }

    }

}
