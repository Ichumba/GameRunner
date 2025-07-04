using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IScreen))]
public class MainScreen : MonoBehaviour
{
    void Start()
    {
        if (!TryGetComponent(out GameplayScreen gameplayScreen)) return;

        ScreenManager.Instance.Push(gameplayScreen);
    }
}
