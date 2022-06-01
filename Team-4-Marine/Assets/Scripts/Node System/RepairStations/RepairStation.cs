using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(SpriteRenderer))]
public class RepairStation : MonoBehaviour
{
    [SerializeField] protected GameObject m_PhysicalModel;

    [SerializeField]
    private string m_StationName;

    [SerializeField]
    protected bool m_Fixed;

    [SerializeField]
    private Rect m_Hitbox;

    [SerializeField]
    private LayerMask m_PlayerMask;

    public static Action OnComplete;
    public static Action OnFail;
    public static Action OnOpen;
    public static Action OnClose;
    public bool m_Opened;

    [SerializeField] protected List<Switch> m_Switches = new List<Switch>();
    [SerializeField] protected List<Handle> m_Handles = new List<Handle>();
    [SerializeField] protected List<RotaryKnob> m_Rotaries = new List<RotaryKnob>();
    [SerializeField] protected List<Indicator> m_Indicators = new List<Indicator>();
    [SerializeField] protected List<StationDisplay> m_Displays = new List<StationDisplay>();
    [SerializeField] protected List<ButtonComponent> m_Buttons = new List<ButtonComponent>();
    [SerializeField] protected ButtonComponent m_ConfirmationButton;

    [SerializeField] protected List<Indicator> m_ErrorLights = new List<Indicator>();
    protected int m_DamageTaken = 0;
    private bool m_Locked = false;
    private float m_LockTime = 15f;

    public virtual void Start()
    {
        InitiatePuzzle();
        if (m_ConfirmationButton != null)
            m_ConfirmationButton.m_Actions.AddListener(CheckWinCondition);
    }

    public virtual void InitiatePuzzle()
    {
        m_Fixed = false;
        //for every type of puzzle component call their Initiate Function here, might change this to an interactable class array and add them seperately
        foreach (Switch s in m_Switches) s.Initiate();
        foreach (Handle h in m_Handles) h.Initiate();
        foreach (RotaryKnob r in m_Rotaries) r.Initiate();
        foreach (ButtonComponent b in m_Buttons) b.Initiate();
        foreach (StationDisplay sd in m_Displays) sd.Initiate();
        foreach (Indicator i in m_Indicators) i.Initiate();
        foreach (Indicator i in m_ErrorLights) i.Initiate();
        GetComponent<SpriteRenderer>().color = Color.yellow;
        if (!CheckForFailure()) InitiatePuzzle(); else return;
    }

    protected virtual void LateUpdate()
    {
        CheckForMechanic();
    }

    protected virtual void Update()
    {
        if (m_Displays.Count > 0)
            m_Displays[0].SetState(m_Fixed);
        if (!m_Fixed)
        {
            if (!m_Locked)
            {
                if (CheckForMechanic()) GetComponent<SpriteRenderer>().color = Color.cyan;
                else GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }

    public virtual void Open()
    {
        print("Opening");
        m_Opened = true;
        OnOpen?.Invoke();
        m_PhysicalModel.gameObject.SetActive(true);
    }

    public virtual void Close()
    {
        if (m_Opened == true)
        {
            print("Closing");
            m_Opened = false;
            OnClose?.Invoke();
            m_PhysicalModel.gameObject.SetActive(false);
            GameManager.GM.EnableMechanicInteraction();
            GameManager.GM.ForceRoam();
        }
    }

    public virtual void CheckWinCondition()
    {
        print("Checking for win");
        if (!CheckForFailure())
        {
            print("win");
            m_Fixed = true;
            GetComponent<SpriteRenderer>().color = Color.green;
            OnComplete?.Invoke();
        }
        else
        {
            print("broken");
            m_Fixed = false;
            m_DamageTaken++;
            GetComponent<SpriteRenderer>().color = Color.yellow;

            CheckDamage();
        }
    }

    protected void CheckDamage()
    {
        SetErrorLights();
        if (m_DamageTaken == 2)
        {
            Close();
            m_Opened = false;
            print("Locking Station");
            m_Locked = true;
            Invoke("Unlock", m_LockTime);
            Invoke("Close", 2f);
            GameManager.GM.DisableMechanicInteraction();

            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private void Unlock()
    {
        m_Locked = false;
        InitiatePuzzle();
    }

    protected void SetErrorLights()
    {
        m_DamageTaken = m_DamageTaken > m_ErrorLights.Count ? m_ErrorLights.Count : m_DamageTaken;
        for (int i = 0; i < m_DamageTaken; i++)
        {
            print("Setting lights");

            m_ErrorLights[i].SetIndicator(true);
        }
    }

    public virtual bool CheckForFailure()
    {
        return true;
    }

    public bool CheckForMechanic()
    {
        Collider2D[] cols = Physics2D.OverlapBoxAll(transform.position + (Vector3)m_Hitbox.position, m_Hitbox.size, 0, m_PlayerMask);
        if (cols.Length > 0)
        {
            cols[0].GetComponent<MechanicScript>().SetStation(this);
            return true;
        }
        return false;
    }

    public bool IsFixed()
    {
        return m_Fixed;
    }

    protected virtual void TakeDamage(int _amount = 1)
    {
        m_DamageTaken += _amount;
        CheckDamage();
    }

    protected virtual void OnDrawGizmos()
    {
        if (m_Fixed)
        {
            Gizmos.color = Color.gray;
            Gizmos.DrawIcon(transform.position, "d_Favorite@2x");
        }
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + (Vector3)m_Hitbox.position, m_Hitbox.size);
    }
}