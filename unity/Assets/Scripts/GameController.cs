using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
			}
			return _instance;
		}
	}

	[SerializeField] private Text _heightText;
	[SerializeField] private Text _heightTextShadow;
	[SerializeField] private GameObject _restartButton;
	[SerializeField] private GameObject _gameOverSprite;
	public int height;
	public bool isGameLost = false;

	public static Action onGameLost;
	public static Action onGameStart;

	void Start()
	{
		isGameLost = false;
		//_gameOverText.gameObject.SetActive(false)
		_gameOverSprite.SetActive(false);
		_restartButton.SetActive(false);
		Time.timeScale = 1;
		_heightText.text = "x0";
		_heightTextShadow.text = "x0";
		height = 0;
	}

	public void UpdateUi()
	{
		_heightText.text = "x" + height;
		_heightTextShadow.text = "x" + height;
	}

	public void GameOver()
	{
		var del = onGameLost;
		_gameOverSprite.SetActive(true);
		_restartButton.SetActive(true);
		//Time.timeScale = 0;
		Invoke("PauseGame",2f);
		if (del!=null)
		{
			del();
		}
	}

	void PauseGame()
	{
		Time.timeScale = 0;
	}

	public void RestartGame()
	{
		Application.LoadLevel("laneGame");
		Time.timeScale = 1;
	}
}
