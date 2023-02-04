using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStigger : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private string _animationName;

    [SerializeField]
    private float _deley;

    float throttlingInterval = 2;
    float lastCollision = 0;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log($"Trigger enter {collider.gameObject.name}");

        if (collider.gameObject.tag == "Player" && Time.time - lastCollision > throttlingInterval)
        {
            lastCollision = Time.time;
            IEnumerator coroutine = WaitAndTrigger(_deley);
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator WaitAndTrigger(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            _animator.SetTrigger(_animationName);
        }
    }
}
