using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CameraFollower : MonoBehaviour
{
	public float lerpSpeed = 1.0f;
	bool initialized = false;
	List<Tank> tanks = new List<Tank>();

	void Start()
	{
		StartCoroutine(WaitAndInitialize());
	}

	IEnumerator WaitAndInitialize()
	{
		yield return null;
		if (initialized == false)
		{
			Initialize();
		}
		else
		{
			Debug.Log("Already initialized");
		}
	}

	void Initialize()
	{
		Tank[] tanksArray = FindObjectsOfType<Tank>();
		tanks = new List<Tank>(tanksArray);

		initialized = true;
	}

	void LateUpdate()
	{
		if (!initialized)
		{
			return;
		}

		float x = tanks.Sum(tank => tank.transform.position.x) / tanks.Count;
		float y = tanks.Sum(tank => tank.transform.position.y) / tanks.Count;
		Vector3 unSmoothPos = new Vector3(x, y, transform.position.z);
		transform.position = Vector3.Lerp(transform.position, unSmoothPos, Time.deltaTime);
	}
}
