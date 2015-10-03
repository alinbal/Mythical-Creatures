using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	public int hitAmount = 10;
	[SerializeField] private GameObject _explosionPrefab;

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Brick" || coll.gameObject.tag == "Ground")
		{
			var explosion = Instantiate(_explosionPrefab, transform.position, transform.rotation);
			Destroy(gameObject);
			Destroy(explosion,1);
			GameController.instance.ChangePlayer();
		}
	}
}
