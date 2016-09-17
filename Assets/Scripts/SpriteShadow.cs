using UnityEngine;
using System.Collections;

// [ExecuteInEditMode]
public class SpriteShadow : MonoBehaviour {
	public bool isMovingObject = false;
	void OnDrawGizmos()
	{
		MoveShadowToPosition();
	}
	void Update()
	{
		if(isMovingObject)
		{
			MoveShadowToPosition();
		}
	}
	void MoveShadowToPosition()
	{
		transform.position = transform.parent.position + new Vector3(-1,-1,1);
	}
}
