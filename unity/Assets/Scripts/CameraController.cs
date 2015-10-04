using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	[SerializeField]private Vector3 pos;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		var p = transform.position;
		p.x = pos.x;
		p.z = pos.z;
		transform.position = p;
	}
}
