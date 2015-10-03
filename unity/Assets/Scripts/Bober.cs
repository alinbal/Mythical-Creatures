using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Bober : MonoBehaviour
{
	public Vector3 to;

	// Use this for initialization
	void Start()
	{
		var tweener = transform.DOLocalMove(to, 1);
		tweener.SetLoops(-1, LoopType.Yoyo);
	}
}
