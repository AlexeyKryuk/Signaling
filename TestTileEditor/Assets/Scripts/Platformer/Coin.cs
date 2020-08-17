using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    static private int _count = 0;

    public static int Count { get => _count; private set => _count = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _count++;
            Destroy(gameObject);
        }
    }
}
