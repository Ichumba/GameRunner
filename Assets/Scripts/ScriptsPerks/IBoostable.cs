using UnityEngine;

public interface IBoostable
{
    void ApplyBoost(BoostType boostType, float value, float duration);
}

public enum BoostType
{
    Speed,
    Shield,
    Health
}
