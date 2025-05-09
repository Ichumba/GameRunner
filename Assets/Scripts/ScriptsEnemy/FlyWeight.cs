using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/EnemyType", fileName = "EnemyType")]

public class FlyWeight : ScriptableObject
{
    [field: SerializeField] public int Life { get; private set; }

    [field: SerializeField] public int Damage { get; private set; }

    [field: SerializeField] public int Range { get; private set; }




}