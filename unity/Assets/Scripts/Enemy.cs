using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	public float speed = 1;
	private int _hitPoints;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		transform.Translate(Vector3.down * Time.deltaTime * speed);
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Bullet" || coll.gameObject.tag == "EndWall")
		{
			var bullet = coll.gameObject.GetComponent<Bullet>();
//			var damage = 0;
//			if (bullet != null)
//			{
//				damage = bullet.hitAmount;
//			}
//			_hitPoints -= damage;
//			if (_hitPoints < 0)
//			{
				Destroy(gameObject);
			//}
		}
	}
}
