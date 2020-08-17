using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandering : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _cellNumber;
    private Collider2D _collider;

    private float _startPositionX;
    private int _direction;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        _startPositionX = transform.position.x;
        _direction = 1;
    }

    private void Update()
    {
        if (transform.position.x >= _startPositionX + _collider.bounds.size.x * _cellNumber - 0.1f)
        {
            _direction = -1;
        }
        if (transform.position.x <= _startPositionX)
        {
            _direction = 1;
        }

        transform.Translate(new Vector3(_speed * _direction * Time.deltaTime, 0, 0));
    }
}
