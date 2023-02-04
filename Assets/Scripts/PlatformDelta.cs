using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDelta : MonoBehaviour
{
    [HideInInspector]
    public Vector3 delta = Vector3.zero;
    private Vector3 prevPosition = Vector3.zero;

    private void Start()
    {
        prevPosition = transform.position;
    }

    private void Update()
    {
        delta = transform.position - prevPosition;
        prevPosition = transform.position;
    }
}