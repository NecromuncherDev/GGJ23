using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Platformer.Core.Simulation;
using Platformer.Gameplay;

public class Robot : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();

        var robotStomp = Schedule<RobotStomp>(5);
        robotStomp.robot = this;
    }

    // Update is called once per frame
    //public void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.L))
    //    {
    //        Debug.Log("Playing animation");
    //        _animator.SetTrigger("Attack 2");
    //    }
    //}

    public void PlayAttack()
    {
        Debug.Log("Playing animation");
        _animator.SetTrigger("Attack 2");
    }
}
