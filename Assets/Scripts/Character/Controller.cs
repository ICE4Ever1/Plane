using System;
using UnityEngine;

public class Controller:MonoBehaviour
{
    public float speed = 1f;

    private Border m_Border;
    
    public float AttackInterval = 1f;
    private float m_AttackTimer = 0;

    private Weapon m_Weapon;
    private void Awake()
    {
        m_AttackTimer = 0;
        m_Weapon = GetComponent<Weapon>();
        m_Border = GetComponent<Border>();
    }

    public void Update()
    {
        MoveUpdate();
        AttackUpdate();
    }

    private void MoveUpdate()
    {
        var move = InputManager.Instance.Move.Move.ReadValue<Vector2>();
        if (SceneManager.Instance.GlobalBorder != null && m_Border != null)
        {
            SceneManager.Instance.GlobalBorder.ClampMove(m_Border, ref move);
        }
        transform.position += (Vector3) move * (speed * Time.deltaTime);
    }

    public void AttackUpdate()
    {
        if (m_Weapon == null && !TryGetComponent<Weapon>(out m_Weapon))
            return;
        
        m_AttackTimer += Time.deltaTime;
        if (m_AttackTimer >= AttackInterval)
        {
            m_Weapon.Attack();
            m_AttackTimer = 0;
        }
    }
}
