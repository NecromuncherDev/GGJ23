using System;
using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject
{
    public float Value;

    public void SetValue(float value)
    {
        Value = value;
    }

    public void ApplyChange(float amount)
    {
        Value += amount;
    }
}