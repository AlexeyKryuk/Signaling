using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public float Speed = 5f;
    public float obstacleRange = 3.0f;

    private void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);

        Ray ray = new Ray(transform.position, transform.forward * 2f);
        RaycastHit hit;

        if (Physics.SphereCast(ray, 1f, out hit))
        {
            if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }

    }
}
