using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints = null;
    [SerializeField] private GameObject _enemyPrefab = null;
    [SerializeField] private int _numberOfEnemies;

    private GameObject _enemy = null;
    private Vector3 _enemyPosition;
    private int _currentPointNumber = 0;
    private int _previousPointNumber = 0;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < _numberOfEnemies; i++)
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

            yield return new WaitForSeconds(2f);
        }
    }
}
