using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private GameObject _enemyPrefab;
	public float _delaySpawnTime;
	public float _spawnInterval;
	// Use this for initialization
	void Start()
	{
		//InvokeRepeating("CreateEnemy",_delaySpawnTime,_spawnInterval);
	}

	public void CreateEnemy()
	{
		Instantiate(_enemyPrefab, transform.position, transform.rotation);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
