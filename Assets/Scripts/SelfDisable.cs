using UnityEngine;
using System.Collections;

public class SelfDisable : MonoBehaviour {
	public float delay = 1f;

	// Use this for initialization
	void OnEnable () {
		CancelInvoke();
		Invoke("DisableSelf",delay);
	}
	
	// Update is called once per frame
	void DisableSelf () {
		gameObject.SetActive(false);
	}
}
