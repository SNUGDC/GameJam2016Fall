using UnityEngine;
using System.Collections;

public class CannonBullet : MonoBehaviour {
    public bool isStrongBullet = false;

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
            var effect = EffectSpawner.instance.GetEffect("hit");
            effect.transform.position = transform.position;
            effect.SetActive(true);
        }
        
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.rigidbody != null)
        {
            if(isStrongBullet)
                col.rigidbody.velocity = Random.insideUnitCircle.normalized * col.rigidbody.velocity.magnitude;
            col.rigidbody.angularVelocity = Random.Range(-5, 5);
            Destroy(gameObject);
        }
    }
}
