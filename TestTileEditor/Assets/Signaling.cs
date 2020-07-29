using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    private AudioSource _audio;
    private bool _isInside;
    private float _deltaVolume;

    private void Start()
    {
        _deltaVolume = -0.01f;
        _isInside = false;
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            _deltaVolume *= -1f;

            if (!_isInside)
            {
                StartCoroutine(PlaySignal());
            }
        }
    }

    private IEnumerator PlaySignal()
    {
        _isInside = true;
        _audio.volume += _deltaVolume;

        if (_audio.volume > 0.5f)
        {
            _audio.volume = 0.5f;

            _isInside = false;
            yield break;
        }
        else if (_audio.volume < 0.01f)
        {
            _audio.volume = 0f;

            _isInside = false;
            yield break;
        }
        
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(PlaySignal());
    }
}
