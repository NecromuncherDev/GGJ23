using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_ManualAnimatorTrigger : MonoBehaviour
{
    public Animator animator;
    public string[] triggerNames;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && triggerNames[0] != null)
        {
            animator.SetTrigger(triggerNames[0]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && triggerNames[1] != null)
        {
            animator.SetTrigger(triggerNames[1]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && triggerNames[2] != null)
        {
            animator.SetTrigger(triggerNames[1]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && triggerNames[3] != null)
        {
            animator.SetTrigger(triggerNames[1]);
        }
    }
}
