using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    private AudioSource _audio;
    private float _deltaVolume;
    private Coroutine _increaseCoroutine;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _deltaVolume = -0.002f;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            PlaySignal();
        }
    }

    private void PlaySignal()
    {
        _deltaVolume *= -1f;

        if (_increaseCoroutine == null)
            _increaseCoroutine = StartCoroutine(IncreaseSignal());
    }

    private IEnumerator IncreaseSignal()
    {
        while (true)
        {
            _audio.volume += _deltaVolume;
            yield return new WaitForEndOfFrame();

            if (_audio.volume >= 0.5f)
            {
                _audio.volume = 0.5f;
                _increaseCoroutine = null;
                yield break;
            }
            else if (_audio.volume <= 0f)
            {
                _audio.volume = 0f;
                _increaseCoroutine = null;
                yield break;
            }
        }
    }
}
