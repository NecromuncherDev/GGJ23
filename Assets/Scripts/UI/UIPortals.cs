using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPortals : MonoBehaviour
{
    [SerializeField]
    private FloatVariable _portals;
    private TextMeshProUGUI _text;

    void Start()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _portals.SetValue(10);
    }

    // Update is called once per frame
    void Update()
    {
        _text.SetText(_portals.Value.ToString());
    }
}
