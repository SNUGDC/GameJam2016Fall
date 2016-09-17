using UnityEngine;
using System.Collections;

public class BombBullet : MonoBehaviour {

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
            var effect = EffectSpawner.instance.GetEffect("boom");
            effect.transform.position = transform.position;
            effect.SetActive(true);

            col.rigidbody.angularVelocity = Random.Range(-20, 20);
            float deg = Random.Range(0f, Mathf.PI * 2);

            col.rigidbody.AddForce(new Vector2(Mathf.Cos(deg), Mathf.Sin(deg))*150, ForceMode2D.Impulse);
            // Destroy(gameObject);
        }

        var effect2 = EffectSpawner.instance.GetEffect("boom");
        effect2.transform.position = transform.position;
        effect2.SetActive(true);
        Destroy(gameObject);
    }
}
