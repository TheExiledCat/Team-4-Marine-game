using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class WeaponDisplay : StationDisplay
{
    [SerializeField]
    private TMP_Text m_AmmoCounter;

    [SerializeField]
    private Image m_AmmoFill;

    private int m_Ammo = 0;

    public override void Initiate()
    {
        base.Initiate();
        m_Ammo = Mathf.RoundToInt(Random.Range(0f, 100f));
        m_AmmoCounter.text = m_Ammo.ToString("00");
    }

    private void Update()
    {
        print(float.Parse(m_AmmoCounter.text));
        m_AmmoFill.fillAmount = float.Parse(m_AmmoCounter.text) / 100f;
    }
}