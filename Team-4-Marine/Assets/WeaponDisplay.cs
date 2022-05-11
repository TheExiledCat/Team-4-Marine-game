using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class WeaponDisplay : StationDisplay
{
    [SerializeField]
    private TMP_Text AmmoCounter;

    [SerializeField]
    private Image AmmoFill;

    private void Update()
    {
        print(float.Parse(AmmoCounter.text));
        AmmoFill.fillAmount = float.Parse(AmmoCounter.text) / 100f;
    }
}