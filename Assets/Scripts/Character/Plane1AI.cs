using System;
using UnityEngine;

public class Plane1AI:AI
{

    public float AttackInterval = 1f;
    private float m_AttackTimer = 0;
    public float Speed = 3f;
    public float AliveTime = 15f;
    private float m_AliveTimer = 0;
    private Weapon m_Weapon;
    public void Awake()
    {
        m_AttackTimer = 0;
        m_Weapon = GetComponent<Weapon>();
        m_AttackTimer = 0;
    }

    public void Update()
    {
        AttackUpdate();
        MoveUpdate();
        m_AliveTimer += Time.deltaTime;
        if (m_AttackTimer >= AliveTime)
        {
            if (TryGetComponent<Character>(out var c))
            {
                c.Die();
            }
        }
    }

    private void MoveUpdate()
    {
        transform.position += Speed * Time.deltaTime * (Vector3)Vector2.down;
    }

    public void AttackUpdate()
    {
        if(m_Weapon == null && !TryGetComponent<Weapon>(out m_Weapon))
            return;
        m_AttackTimer += Time.deltaTime;
        if (m_AttackTimer >= AttackInterval)
        {
            m_Weapon.Attack();
            m_AttackTimer = 0;

        }
    }
}
