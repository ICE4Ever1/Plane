using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIStart:MonoBehaviour
    {
        public Button Btn_Start;
        public Button Plane1;
        public Button Plane2;
        public Button Quit;
        public int Index=1;
        public void Awake()
        {
            Btn_Start.onClick.AddListener(()=>
            {
                GameManager.Instance.PlaneIndex = Index;
                GameManager.Instance.LoadGameScene();
            });
            Plane1.onClick.AddListener(() => Index = 1);
            Plane2.onClick.AddListener(() => Index = 2);
            Quit.onClick.AddListener(() =>
            {
#if UNITY_EDITOR
                EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            });
        }
    }
}