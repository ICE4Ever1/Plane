using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Range(1,10)]
    public int MaxHP = 1;
    [SerializeField]
    private int m_CurHP;

    public float FlashTime = 0.3f;
    private float m_FlashTimer = 0f;
    private bool m_Invisible = false;
    private SpriteRenderer m_Renderer;
    private MaterialPropertyBlock m_MaterialPropertyBlock;
    private void Awake()
    {
        m_CurHP = MaxHP;
        m_Renderer = GetComponent<SpriteRenderer>();
        m_MaterialPropertyBlock = new MaterialPropertyBlock();
    }

    private void Update()
    {
        if (m_Invisible)
        {
            m_FlashTimer += Time.deltaTime;
            if (m_FlashTimer > FlashTime)
            {
                m_MaterialPropertyBlock.Clear();
                m_MaterialPropertyBlock.SetInt("_Flash", 0);
                m_Renderer.SetPropertyBlock(m_MaterialPropertyBlock);
                m_FlashTimer = 0;
                m_Invisible = false;
            }
        }
    }

    public void Hurt(int count)
    {
        if(m_Invisible)
            return;
        m_Invisible = true;
        m_CurHP -= count;
        m_MaterialPropertyBlock.Clear();
        m_MaterialPropertyBlock.SetInt("_Flash", 1);
        m_Renderer.SetPropertyBlock(m_MaterialPropertyBlock);

        if (m_CurHP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        var effect=EffectPool.Instance.Claim();
        effect.transform.position = transform.position;
        Destroy(gameObject);
    }
}
