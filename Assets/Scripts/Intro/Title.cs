using UnityEngine;
using System.Collections;
using DG.Tweening;
//using DG.Tweening.ShortcutExtensions;

public class Title : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.DOShakeScale (2, 0.05f, 2, 20, false).SetEase (Ease.InOutSine).SetLoops (-1);
	}
}
