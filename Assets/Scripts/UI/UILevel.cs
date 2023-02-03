using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILevel : MonoBehaviour
{
    public UIHealth uiHealth;
    void Start()
    {
        uiHealth = GetComponentInChildren<UIHealth>();
    }
}
