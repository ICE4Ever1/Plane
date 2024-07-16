
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Utils;

public class BulletPool:MonoSingleton<BulletPool>
{
    private ObjectPool<Bullet> m_Pool;
    public Bullet Prefab;
    private List<Bullet> m_Actives=new();
    public override void OnAwake()
    {
        base.OnAwake();
        m_Pool = new(() => Instantiate(Prefab,transform),
            (x) =>
            {
                x.gameObject.SetActive(true);
                m_Actives.Add(x);
            },
            (x) =>
            {
                x.gameObject.SetActive(false);
                m_Actives.Remove(x);
            });
    }

    public Bullet Claim()
    {
        return m_Pool.Get();
    }

    public void Release(Bullet b)
    {
        m_Pool.Release(b);
    }
    public void ReleaseAll()
    {
        while (m_Actives.Count>0)
        {
            Release(m_Actives[0]);
        }
        m_Actives.Clear();
    }
    private void OnDestroy()
    {
        m_Pool?.Dispose();
    }
}
