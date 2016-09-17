using UnityEngine;

// [ExecuteInEditMode]
public class SpriteShadow : MonoBehaviour {
	public bool isMovingObject = false;
	public float shadowDistance = 1f;
	void OnDrawGizmos()
	{
		MoveShadowToPosition();
	}
	void LateUpdate()
	{
		if(isMovingObject)
		{
			MoveShadowToPosition();
		}
	}
	void MoveShadowToPosition()
	{
		transform.position = transform.parent.position + new Vector3(-shadowDistance,-shadowDistance,1);
	}
}
