using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GoToScreenOnClick : MonoBehaviour
{
    [SerializeField] private SimpleUiScreen _canvas;

    private void Awake()
    {
        var button = GetComponent<Button>();
        
        button.onClick.AddListener(() => ScreenManager.Instance.Push(_canvas));
    }
}
