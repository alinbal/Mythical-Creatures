using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
	[SerializeField] private KeyCode _keyCode;
	[SerializeField] private GameObject _bullet;
	[SerializeField] private GameObject _nozzle;
	[SerializeField] private SpriteRenderer _spriteRenderer;
	[SerializeField] private Text text;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyUp(_keyCode))
		{
			Instantiate(_bullet,position:_nozzle.transform.position,rotation:_nozzle.transform.rotation);
			_spriteRenderer.color  = Color.black;
			text.color = Color.white;
		}
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Bullet")
		{
			_spriteRenderer.color  = Color.black;
			text.color = Color.white;
		}
	}
}
