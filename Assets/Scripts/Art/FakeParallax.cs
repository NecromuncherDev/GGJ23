using System;
using UnityEngine;

namespace Art
{
    public class FakeParallax : MonoBehaviour
    {
        [SerializeField] private GameObject[] _parallaxGroups;

        [SerializeField] private float[] _amountPerGroup;

        [SerializeField] private float _amount;
        [SerializeField] private float _amountY;
        [SerializeField] private float _heightModifier;
        [SerializeField] private float _heightOffset;
        
        [SerializeField] private GameObject _follow;

        private float _followStartX;
        private float _followStartY;
        
        private void Start()
        {
            if (_follow == null)
            {
                _follow = FindObjectOfType<Camera>().gameObject;
            }
            
            _followStartX = _follow.transform.position.x;
            _followStartY = _follow.transform.position.y;
        }

        void Update()
        {
            _amount = _followStartX - _follow.transform.position.x;
            _amountY = _followStartY - _follow.transform.position.y;
            for (var i = 0; i < _parallaxGroups.Length; i++)
            {
                var group = _parallaxGroups[i];
                var amountPerGroup = _amountPerGroup[i];
                group.transform.localPosition = new Vector3(
                    amountPerGroup * _amount, 
                    _heightOffset + amountPerGroup * _amountY * _heightModifier, 0);
            }
        }
        

    }
}