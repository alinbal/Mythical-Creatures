using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Canon : MonoBehaviour
{
#pragma warning disable 649
	[SerializeField] private Text _angleText;
#pragma warning restore 649
#pragma warning disable 649
	[SerializeField] private GameObject _pivotObject;
#pragma warning restore 649
	private Vector3 _pivotPoint;

	// Use this for initialization
	void Start()
	{
		_pivotPoint =  Camera.main.WorldToScreenPoint(_pivotObject.transform.position);
	}

	// Update is called once per frame
	void Update()
	{
		var angle = ConvertMousePosToAngle(Input.mousePosition,_pivotPoint);
		_angleText.text = "Angle:" + angle; 
		var newRotation = Quaternion.Euler(new Vector3(0, 0, angle));
		_pivotObject.transform.localRotation = newRotation;
	}

	//Converts the mouse position to angle
	private float ConvertMousePosToAngle(Vector2 mousePos, Vector2 relativePos)
	{
		var v = mousePos - relativePos;
 
		//use atan2 to get the angle; Atan2 returns radians
		var angleRadians=Mathf.Atan2(v.y, v.x);
 
		//convert to degrees
		var angleDegrees = angleRadians * Mathf.Rad2Deg;
 
		//angleDegrees will be in the range (-180,180].
		//I like normalizing to [0,360) myself, but this is optional..
		//if (angleDegrees<0) 
			//angleDegrees+=360;

		return Mathf.Clamp(angleDegrees,0,90);
	}
}
