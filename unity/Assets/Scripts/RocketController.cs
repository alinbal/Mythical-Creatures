using UnityEngine;
using System.Collections;

public class RocketController : MonoBehaviour
{
	[SerializeField] private Rigidbody2D _rocketRigidBody;
	[SerializeField] private GameObject _cratePrefab;
	private GameObject _currentCrate;
	// Use this for initialization
	void Start()
	{
		_currentCrate = Instantiate(_cratePrefab);
		var distJoint = _currentCrate.GetComponent<DistanceJoint2D>();
		distJoint.connectedBody = _rocketRigidBody;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.UpArrow))
		{
			//apply force up
			_rocketRigidBody.AddForce(Vector2.up * 0.9f, ForceMode2D.Impulse);
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			//apply force left
			_rocketRigidBody.AddForce(Vector2.left * 0.8f, ForceMode2D.Force);
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			//apply force right
			_rocketRigidBody.AddForce(Vector2.right * 0.8f, ForceMode2D.Force);
		}

		if (Input.GetKeyUp(KeyCode.Space))
		{
			//drop the crate and create a new one 
			if (_currentCrate!=null)
			{
				var distanceJoint = _currentCrate.GetComponent<DistanceJoint2D>();
				if (distanceJoint!=null)
				{
					Destroy(distanceJoint);
				}

				_currentCrate = Instantiate(_cratePrefab , transform.position,transform.rotation) as GameObject;
				if (_currentCrate != null)
				{
					var distJoint = _currentCrate.GetComponent<DistanceJoint2D>();
					distJoint.connectedBody = _rocketRigidBody;
				}
			}
		}
	}
}
