using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string _animationName;
    private Animator _animator;
    private bool _isAnimated;

    private void Start()
    {
        _isAnimated = TryGetComponent<Animator>(out _animator);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_isAnimated)
            _animator.SetTrigger(_animationName);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_isAnimated)
            _animator.SetTrigger(_animationName);
    }
}
