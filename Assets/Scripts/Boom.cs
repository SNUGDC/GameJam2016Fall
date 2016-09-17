using UnityEngine;
using System.Collections.Generic;

public class Boom : MonoBehaviour {
	public float power = 40f;
	private List<Collider2D> collided = new List<Collider2D>();
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D col) {
		if(col.GetComponent<Rigidbody2D>() == null) return;
		if(collided.Contains(col)) return;
		collided.Add(col);
		var body = col.GetComponent<Rigidbody2D>();
		body.AddForce(Random.insideUnitCircle.normalized*power, ForceMode2D.Impulse);
	}

	void OnEnable()
	{
		CancelInvoke();
		Invoke("DisableSelf",0.2f);
		collided.Clear();
	}

	void DisableSelf()
	{
		enabled = false;
	}
}
