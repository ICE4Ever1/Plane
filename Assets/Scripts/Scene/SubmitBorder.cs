using System;
using UnityEngine;

namespace Scene
{
    public class SubmitBorder:MonoBehaviour
    {
        private void Start()
        {
            if (TryGetComponent<Border>(out var b))
            {
                SceneManager.Instance.GlobalBorder = b;
            }
        }
    }
}