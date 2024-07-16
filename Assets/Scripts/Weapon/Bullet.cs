using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Bullet:MonoBehaviour
{
    public float Speed = 7;
    public int Damage = 1;
    public string TargetTag;
    public float AliveTime = 5f;
    private float m_AliveTimer = 0;
    private void Update()
    {
        var dir = transform.up;
        transform.position += Speed * Time.deltaTime * dir;
        m_AliveTimer += Time.deltaTime;
        if (m_AliveTimer >= AliveTime)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(TargetTag))
        {
            return;
        }

        if (other.TryGetComponent<Character>(out var c))
        {
            c.Hurt(Damage);
            Die();    
        }
    }

    public void Die()
    {
        m_AliveTimer = 0;
        BulletPool.Instance.Release(this);
    }
}
