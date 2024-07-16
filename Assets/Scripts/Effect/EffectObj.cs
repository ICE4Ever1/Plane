
using System;
using UnityEngine;

public class EffectObj:MonoBehaviour
{
    private Animator m_Animator;
    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var stateInfo = m_Animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime >= 1)
        {
            Release();
        }
    }

    public void Release()
    {
        EffectPool.Instance.Release(this.gameObject);
    }
}
