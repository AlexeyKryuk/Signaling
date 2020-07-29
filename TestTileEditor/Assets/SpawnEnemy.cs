using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _enemyPrefab;
    private GameObject _enemy;
    private int _currentNumberOfEnemies = 0;
    public int NumberOfEnemies = 10;

    private Vector3 _enemyPosition;
    private int _currentPointNumber = 0;
    private int _previousPointNumber = 0;

    private float _repeatTime = 2f;
    private float _currentTime = 0f;

    private void Start()
    {
        _currentTime = _repeatTime;
    }

    private void Update()
    {
        _currentTime -= Time.deltaTime;
        if (_currentTime <= 0) 
        {
            _currentTime = _repeatTime;

            if (++_currentNumberOfEnemies <= NumberOfEnemies)
                SpawnEnemies();
        }
    }

    private void SpawnEnemies()
    {
        _enemy = Instantiate(_enemyPrefab) as GameObject;

        _previousPointNumber = _currentPointNumber;
        _currentPointNumber = Random.Range(0, _spawnPoints.Length);

        _enemyPosition = _spawnPoints[_currentPointNumber].position;
        while (_currentPointNumber == _previousPointNumber)
        {
            _currentPointNumber = Random.Range(0, _spawnPoints.Length);
            _enemyPosition = _spawnPoints[_currentPointNumber].position;
        }
        _enemy.transform.position = _enemyPosition;
    }
}
