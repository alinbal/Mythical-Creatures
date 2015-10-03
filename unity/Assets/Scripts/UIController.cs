using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour
{
	private static UIController _instance;
	public static UIController instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType(typeof(UIController)) as UIController;
				if (_instance != null) DontDestroyOnLoad(_instance.gameObject);
			}
			return _instance;
		}
	}

	[SerializeField] private PowerSliderController _powerSliderController;
	public PowerSliderController powerSliderController
	{
		get { return _powerSliderController; }
		set { _powerSliderController = value; }
	}
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
