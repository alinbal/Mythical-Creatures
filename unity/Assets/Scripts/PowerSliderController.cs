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
		_tween  = DOTween.To(() => _powerSlider.value, value => _powerSlider.value = value, 1, 0.3f);
		_tween.SetEase(Ease.Linear);
		_tween.SetLoops(-1, LoopType.Yoyo);
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public float GetValue()
	{
		_tween.Pause();
		return _powerSlider.value;
	}

	public void Reset()
	{
		_tween.Restart();
	}
}
