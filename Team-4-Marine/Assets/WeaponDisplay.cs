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
    private int m_AmmoA;
    private int m_AmmoB;
    protected override void Awake()
    {
        m_TextName.text = m_StationName;
        print(m_Crosses.name);
    }

    public override void Initiate()
    {
        base.Initiate();
        m_AmmoA = Mathf.RoundToInt(Random.Range(0f, 100f));
        m_AmmoB = Mathf.RoundToInt(Random.Range(0f, 100f));
        m_AmmoCounter.text = m_Ammo.ToString("00");
        if (m_DigitCrosses <= 2)
        {
            m_Ammo = m_AmmoA;
        }
        else
        {
            m_Ammo = m_AmmoB;
        }
        SetNone();
    }
    public void SetNone()
    {
        m_AmmoCounter.text = "";
        m_AmmoFill.fillAmount = 0;
    }
    public void SetA()
    {
        m_AmmoCounter.text = m_AmmoA.ToString("00");
        m_AmmoFill.fillAmount = float.Parse(m_AmmoCounter.text) / 100f;
    }
    public void SetB()
    {
        m_AmmoCounter.text = m_AmmoB.ToString("00");
        m_AmmoFill.fillAmount = float.Parse(m_AmmoCounter.text) / 100f;
    }

    public int GetAmmo()
    {
        return m_Ammo;
    }
}