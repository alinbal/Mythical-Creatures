using UnityEngine;
using System.Collections;

public class BrickController : MonoBehaviour
{

	[SerializeField]
	private int _hitPoints;
	// Use this for initialization
	void Start()
	{

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Bullet")
		{
			//apply damage here
			var bullet = coll.gameObject.GetComponent<Bullet>();
			var damage = 0;
			if (bullet != null)
			{
				damage = bullet.hitAmount;
			}
			_hitPoints -= damage;
			if (_hitPoints < 0)
			{
				Destroy(gameObject);
			}
		}
	}
}
