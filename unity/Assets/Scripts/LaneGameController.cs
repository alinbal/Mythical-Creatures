using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class LaneGameController : MonoBehaviour
{
	private static LaneGameController _instance;
	public static LaneGameController instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType(typeof(LaneGameController)) as LaneGameController;
				if (_instance != null) DontDestroyOnLoad(_instance.gameObject);
			}
			return _instance;
		}
	}

	[SerializeField] private Text _scoreText;
	[SerializeField] private Text _hitPoints;
	private float _speedBallIncrease = 0;

	public int points = 0;
	public int hitPoints = 0;

	public List<Lane> lanes = new List<Lane>(); 
	// Use this for initialization
	void Start()
	{
		InvokeRepeating("SelectRandomLaneAndFire",2,1);
	}

	public void RefreshScoreBoard()
	{
		_scoreText.text = "Score:" + points;
		_hitPoints.text = "Life:" + hitPoints;
		//Invoke("SelectRandomLaneAndFire",2);
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void SelectRandomLaneAndFire()
	{
		var randomIndex = UnityEngine.Random.Range(0, 4);
		var randomLane = lanes[randomIndex];
		randomLane.enemySpawner.CreateEnemy();
		randomLane.spriteRenderer.color = Color.white;
		randomLane.text.color = Color.black;
		foreach (var lane in lanes)
		{
			if (randomLane!=lane)
			{
				lane.spriteRenderer.color = Color.black;
				lane.text.color = Color.white;
			}
		}
	}

	[Serializable]
	public class Lane
	{
		public EnemySpawner enemySpawner;
		public SpriteRenderer spriteRenderer;
		public Text text;
	}
}
