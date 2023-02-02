using System;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;

namespace Art
{
    public class SetPipelineScale : MonoBehaviour
    {
        [SerializeField] private UniversalRenderPipelineAsset _pipeline;
        [SerializeField] private Camera _camera;

        [SerializeField] private int _pixelsPerUnit;
        
        private void Update()
        {
            _pipeline.renderScale = (float)_pixelsPerUnit / _camera.pixelHeight * 2;
        }
    }
}   