using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthChanged : MonoBehaviour
{
    [SerializeField] private float _healPoint;
    [SerializeField] private float _damagePoint;
    [SerializeField] private float _ratioLerp;

    [SerializeField] private TMPro.TMP_Text _textHeal;
    [SerializeField] private TMPro.TMP_Text _textDamage;

    private Slider _healthSlider;
    private float _targetValue;

    private void Awake()
    {
        _healthSlider = GetComponent<Slider>();
        _targetValue = _healthSlider.value;
    }

    private void OnValidate()
    {
        if (_healPoint < 0f)
            _healPoint = 0f;

        if (_damagePoint < 0f)
            _damagePoint = 0f;

        _textHeal.text = $"+{_healPoint} HP";
        _textDamage.text = $"-{_damagePoint} HP";
    }

    private void Update()
    {
        _healthSlider.value = Mathf.Lerp(_healthSlider.value, _targetValue, Time.deltaTime * _ratioLerp);
    }

    public void Heal()
    {
        if (_healthSlider.value + _healPoint <= _healthSlider.maxValue)
            _targetValue += _healPoint;
        else
            _targetValue = _healthSlider.maxValue;
    }

    public void ApplyDamage()
    {
        if (_healthSlider.value - _damagePoint >= _healthSlider.minValue)
            _targetValue -= _damagePoint;
        else
            _targetValue = _healthSlider.minValue;
    }
}
