using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RocketController : MonoBehaviour
{
	[SerializeField] private Rigidbody2D _rocketRigidBody;
	[SerializeField] private GameObject _cratePrefab;
	[SerializeField] private List<GameObject> _spawnPoints = new List<GameObject>(); 
	private GameObject _currentCrate;
	[SerializeField] private GameObject _explostionPrefab;
	// Use this for initialization
	void Start()
	{
		_currentCrate = Instantiate(_cratePrefab);
		var distJoint = _currentCrate.GetComponent<DistanceJoint2D>();
		distJoint.connectedBody = _rocketRigidBody;
		GameController.onGameLost += () =>
		{
			Instantiate(_explostionPrefab, transform.position, transform.rotation);
		};
	}

	void OnDestroy()
	{
		GameController.onGameLost = null;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.UpArrow))
		{
			//apply force up
			_rocketRigidBody.AddForce(Vector2.up , ForceMode2D.Impulse);
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			//apply force left
			_rocketRigidBody.AddForce(Vector2.left * 0.4f, ForceMode2D.Impulse);
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			//apply force right
			_rocketRigidBody.AddForce(Vector2.right * 0.4f, ForceMode2D.Impulse);
		}

		if (Input.GetKeyUp(KeyCode.Space))
		{
			//drop the crate and create a new one 
			if (_currentCrate!=null)
			{
				var distanceJoint = _currentCrate.GetComponent<DistanceJoint2D>();
				var crateController = _currentCrate.GetComponent<CrateController>();
				crateController.anchoredToRocket = false;
				crateController.UnselectBox();
				if (distanceJoint!=null)
				{
					Destroy(distanceJoint);
				}

				var randomSpawmPoint = _spawnPoints[Random.Range(0, 4)];
				_currentCrate = Instantiate(_cratePrefab , randomSpawmPoint.transform.position,randomSpawmPoint.transform.rotation) as GameObject;
				if (_currentCrate != null)
				{
					var distJoint = _currentCrate.GetComponent<DistanceJoint2D>();
					distJoint.connectedBody = _rocketRigidBody;
				}

				GameController.instance.height++;
				GameController.instance.UpdateUi();
			}
		}
	}
}
