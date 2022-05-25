using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Meteors : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> m_Sprites;

    public GameObject m_MeteorPrefab;

    public static event Action m_OnDamage;

    private float X_Pos, Y_Pos, Z_Pos = 400;
    [SerializeField] private Bounds m_BoundingBox;

    public void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            StartSpawner();
        }
    }

    private IEnumerator MeteorSpawner(int _amount, float _delay)
    {
        for (int i = 0; i < _amount; i++)
        {
            Y_Pos = UnityEngine.Random.Range(m_BoundingBox.center.x - m_BoundingBox.size.x / 2, m_BoundingBox.center.x + m_BoundingBox.size.x / 2);
            X_Pos = UnityEngine.Random.Range(m_BoundingBox.center.y - m_BoundingBox.size.y / 2, m_BoundingBox.center.y + m_BoundingBox.size.y / 2);

            Meteor m = Instantiate(m_MeteorPrefab, new Vector3(X_Pos, Y_Pos, Z_Pos), Quaternion.identity).GetComponent<Meteor>();
            m.GetComponent<SpriteRenderer>().sprite = m_Sprites[UnityEngine.Random.Range(0, Mathf.FloorToInt(m_Sprites.Count))];
            m.Initialize();
            m.Subscribe(Damage);

            yield return new WaitForSeconds(_delay);
        }
    }

    public void StartSpawner()
    {
        StartCoroutine(MeteorSpawner(UnityEngine.Random.Range(10, 20), UnityEngine.Random.Range(0.2f, 1f)));
    }

    public void Damage()
    {
        m_OnDamage?.Invoke();
        print("damage taken");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(m_BoundingBox.center, (Vector3)m_BoundingBox.size + Vector3.forward * Z_Pos);
    }
}