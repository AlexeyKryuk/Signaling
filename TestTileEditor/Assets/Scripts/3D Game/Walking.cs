using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _obstacleRange = 4f;
    private float _sphereCastRadius = 1f;

    private Ray _ray;
    private RaycastHit _hit;

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        _ray = new Ray(transform.position, transform.forward * 2f);

        if (Physics.SphereCast(_ray, _sphereCastRadius, out _hit))
        {
            if (_hit.distance < _obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }
}
