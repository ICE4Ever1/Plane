using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Spawner:MonoBehaviour
{
    //delay
    public float SpawnTime;
    private float m_SpawnTimer;
    
    public GameObject Prefab;

    public int SpawnCount = 5;

    private void Awake()
    {
        m_SpawnTimer = 0;
    }

    public void Update()
    {
        m_SpawnTimer += Time.deltaTime;
        if (m_SpawnTimer >= SpawnTime)
        {
            Spawn();
            m_SpawnTimer = 0;
        }
    }

    private void OnDestroy()
    {

    }

    public virtual void Spawn()
    {
        for(int i = 0; i < SpawnCount; i++)
        {
            var g=Instantiate(Prefab);
            OnLoad(g);
        }
    }

    public virtual void Spawn(int count)
    {
        for(int i = 0; i < count; i++)
        {

        }
    }
    public virtual void OnLoad(GameObject go)
    {
        go.transform.parent = this.transform;
        go.transform.localPosition = Vector3.zero;
    }
}
