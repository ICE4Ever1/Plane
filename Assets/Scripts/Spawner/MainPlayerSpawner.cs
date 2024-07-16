using System;
using UnityEngine;


/// <summary>
/// 个人觉得这里会不会直接交给GameManager特殊处理为好
/// </summary>
public class MainPlayerSpawner:Spawner
{
    public GameObject Prefab2;
    private void Start()
    {
        Spawn();
    }

    public new void Update()
    {
        
    }
    public override void Spawn()
    {
        GameObject g;
        if (GameManager.Instance.PlaneIndex == 1)
        {
            g=Instantiate(Prefab);
            OnLoad(g);

        }
        else if(GameManager.Instance.PlaneIndex == 2)
        {
            g=Instantiate(Prefab2);
            OnLoad(g);

        }

    }
    
    public override void OnLoad(GameObject go)
    {
        //go.transform.parent = this.transform;
        go.transform.position = this.transform.position;
        go.AddComponent<MainEntity>();
    }
    
}
