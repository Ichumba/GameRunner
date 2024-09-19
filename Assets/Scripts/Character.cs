using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Test test;
    private void Start()
    {
        test.PuzzleActive(10);
    }
}
