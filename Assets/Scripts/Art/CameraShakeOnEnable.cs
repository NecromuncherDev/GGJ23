using System;
using UnityEngine;

namespace Art
{
    public class CameraShakeOnEnable : MonoBehaviour
    {
        [SerializeField] private float shakeTimer;
        [SerializeField] private float shakeAmount;
        
        private void OnEnable()
        {
            CameraShake.myCameraShake.ShakeCamera(shakeAmount, shakeTimer);
        }
    }
}