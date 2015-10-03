using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

	private static GameController _instance;
	public static GameController instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType(typeof(GameController)) as GameController;
				if (_instance != null) DontDestroyOnLoad(_instance.gameObject);
			}
			return _instance;
		}
	}

	public Canon player1;
	public Canon player2;

	private Canon _currenPlayer = null;

	// Use this for initialization
	void Start()
	{
		_currenPlayer = player1;
		_currenPlayer.SetActive(true);
		player2.SetActive(false);
	}

	public void ChangePlayer()
	{
		if (_currenPlayer == player1)
		{
			player1.SetActive(false);
			player2.SetActive(true);
			_currenPlayer = player2;
		}
		else
		{
			player2.SetActive(false);
			player1.SetActive(true);
			_currenPlayer = player1;
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}
