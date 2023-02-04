using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    [SerializeField]
    private FloatVariable HEALTH;

    private Slider slider;

    private void Start()
    {
        slider = GetComponentInChildren<Slider>();
    }

    private void Update()
    {
        slider.value = HEALTH.Value;
    }
}
