using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class Canon : MonoBehaviour
{
#pragma warning disable 649
	[SerializeField] private GameObject _pivotObject;
#pragma warning restore 649
	private Vector3 _pivotPoint;
	[SerializeField] private GameObject _bulletPrefab;
	[SerializeField] private GameObject _canonNozle;
	private float _sliderValue = 0;
	[SerializeField] private float _maxPower;
	private PowerSliderController _powerSliderController;
	public bool isFacingRight = false;
	private bool _isActive = false;
	[SerializeField]private SpriteRenderer _spriteArrow;

	// Use this for initialization
	void Start()
	{
		_pivotPoint = Camera.main.WorldToScreenPoint(_pivotObject.transform.position);
		_powerSliderController = UIController.instance.powerSliderController;
	}

	public void SetActive(bool active)
	{
		_isActive = active;
		_powerSliderController.Reset();
		if (active)
		{
			var color = _spriteArrow.color;
			color.a = 1;
			_spriteArrow.color = color;
		}
		else
		{
			var color = _spriteArrow.color;
			color.a = 0;
			_spriteArrow.color = color;
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (_isActive)
		{
			var angle = ConvertMousePosToAngle(Input.mousePosition, _pivotPoint);
			//_angleText.text = "Angle:" + angle; 
			var newRotation = Quaternion.Euler(new Vector3(0, 0, angle));
			_pivotObject.transform.localRotation = newRotation;

			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				if (_powerSliderController != null)
				{
					_powerSliderController.StartAnimation();
				}

			}

			if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				if (_powerSliderController != null)
				{
					FireBullet(_maxPower * _powerSliderController.GetValue());
				}
				else
				{
					FireBullet(_maxPower * 0.5f);
				}
			}

			if (Input.GetKeyUp(KeyCode.Space))
			{
				if (_powerSliderController != null)
				{
					_powerSliderController.Reset();
				}
			}
		}
	}

	//Converts the mouse position to angle
	private float ConvertMousePosToAngle(Vector2 mousePos, Vector2 relativePos)
	{
		var v = mousePos - relativePos;

		//use atan2 to get the angle; Atan2 returns radians
		var angleRadians = Mathf.Atan2(v.y, v.x);

		//convert to degrees
		var angleDegrees = angleRadians * Mathf.Rad2Deg;

		//angleDegrees will be in the range (-180,180].
		//I like normalizing to [0,360) myself, but this is optional..
		//if (angleDegrees<0) 
		//angleDegrees+=360;
		return isFacingRight ? Mathf.Clamp(angleDegrees, 0, 90) : Mathf.Clamp(angleDegrees, 90, 180);
	}

	void FireBullet(float power)
	{
		GameObject projectile = Instantiate(_bulletPrefab);
		projectile.transform.position = _canonNozle.transform.position;
		projectile.transform.rotation = _pivotObject.transform.rotation;
		projectile.transform.localScale = new Vector3(2, 2, 2);
		Rigidbody2D component = projectile.GetComponent<Rigidbody2D>();
		component.AddForce(_pivotObject.transform.right * power, ForceMode2D.Impulse);
	}
}
