using UnityEngine;

namespace Art
{
    public class FakeParallax : MonoBehaviour
    {
        [SerializeField] private GameObject[] _parallaxGroups;

        [SerializeField] private float[] _amountPerGroup;

        [SerializeField] private float _amount;

        void Update()
        {
            for (var i = 0; i < _parallaxGroups.Length; i++)
            {
                var group = _parallaxGroups[i];
                var amountPerGroup = _amountPerGroup[i];
                group.transform.position = new Vector3(amountPerGroup * _amount, 0, 0);
            }
        }
        

    }
}