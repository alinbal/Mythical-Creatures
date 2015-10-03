using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class PowerSliderController : MonoBehaviour
{
	[SerializeField] private Slider _powerSlider;
	private Tween _tween;

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			
		}

		var pos = Input.mousePosition;
		pos.y += 0.2f;
		transform.position = pos;
	}

	public void StartAnimation()
	{
		_tween  = DOTween.To(() => _powerSlider.value, value => _powerSlider.value = value, 1,1);
		_tween.SetEase(Ease.Linear);
	}

	public float GetValue()
	{
		_tween.Pause();
		return _powerSlider.value;
	}

	public void Reset()
	{
		_powerSlider.value = 0;
		_tween.Rewind();
	}
}
