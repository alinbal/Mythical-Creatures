using UnityEngine;
using System.Collections;

public class CrateController : MonoBehaviour
{
	public bool anchoredToRocket = true;
	[SerializeField]public Sprite selectedSprite;
	[SerializeField]public Sprite unselectedSprite;
	[SerializeField] public SpriteRenderer _spriteRenderer;

	// Use this for initialization
	void Start()
	{
		_spriteRenderer.sprite = selectedSprite;
	}

	public void UnselectBox()
	{
		_spriteRenderer.sprite = unselectedSprite;
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Brick")
		{
			if (GameController.instance.height > 1 && !GameController.instance.isGameLost && !anchoredToRocket)
			{
				GameController.instance.isGameLost = true;
				GameController.instance.GameOver();
			}
			//_spriteRenderer.color  = Color.black;
			//text.color = Color.white;
		}
	}
}
