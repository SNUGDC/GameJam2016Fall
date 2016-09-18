using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CameraZoom : MonoBehaviour
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

		Camera camera = GetComponent<Camera>();
		List<Vector3> tankViewportPoses = tanks.Select(
			tank => camera.WorldToViewportPoint(tank.transform.position)
		).ToList();
		float minX = tankViewportPoses.Min(pos => pos.x);
		float maxX = tankViewportPoses.Max(pos => pos.x);
		float minY = tankViewportPoses.Min(pos => pos.y);
		float maxY = tankViewportPoses.Max(pos => pos.y);

		float maxRatio = Mathf.Max(maxX - 1, -minY, maxY - 1, -minY);
		camera.orthographicSize = camera.orthographicSize * (maxRatio + 1.1f);
		camera.orthographicSize = Mathf.Max(camera.orthographicSize, 25f);
		// camera.orthographicSize = Mathf.Min(camera.orthographicSize, 40f);
	}
}
