
using System;
using UnityEngine;

public class MainEntity:MonoBehaviour
{
    private void OnDestroy()
    {
        GameManager.Instance.LoadGameStart();
    }
}
