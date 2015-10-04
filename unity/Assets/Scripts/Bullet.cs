using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	public int hitAmount = 10;
	[SerializeField] private GameObject _explosionPrefab;
	public float speed = 10;

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Brick" || coll.gameObject.tag == "Ground" || coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "EndWall")
		{
			var explosion = Instantiate(_explosionPrefab, transform.position, transform.rotation);
			Destroy(gameObject);
			Destroy(explosion,1);
		}

		if (coll.gameObject.tag == "Enemy")
		{
			LaneGameController.instance.RefreshScoreBoard();
			LaneGameController.instance.points += 1;
		}

		if (coll.gameObject.tag == "EndWall")
		{
			LaneGameController.instance.hitPoints -= 1;
			LaneGameController.instance.RefreshScoreBoard();
		}
	}

	void Update()
	{
		transform.Translate(Vector3.up * Time.deltaTime * speed);
	}
}
