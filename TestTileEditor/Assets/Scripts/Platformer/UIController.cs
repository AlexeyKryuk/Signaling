using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text _coinCountText;

    private void Update()
    {
        _coinCountText.text = Convert.ToString(Coin.Count);
    }
}
