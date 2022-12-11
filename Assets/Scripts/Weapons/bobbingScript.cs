using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobbingScript : MonoBehaviour
{
    public Animator gunAnimation;

    private void Update()
    {
        //if we're walking forward, we bob the gun
        if (Input.GetKeyDown(KeyCode.W))
        {
            gunAnimation.SetTrigger("weaponBob");
            gunAnimation.ResetTrigger("stop");
        }
        //if we stop moving forward, the gun stops bobbing
        if (Input.GetKeyUp(KeyCode.W))
        {
            gunAnimation.SetTrigger("stop");
            gunAnimation.ResetTrigger("weaponBob");
        }

        //if we're walking backward, we bob
        if (Input.GetKeyDown(KeyCode.S))
        {
            gunAnimation.SetTrigger("weaponBob");
            gunAnimation.ResetTrigger("stop");
        }
        //if we stop moving backward, no bobbing
        if (Input.GetKeyUp(KeyCode.S))
        {
            gunAnimation.SetTrigger("stop");
            gunAnimation.ResetTrigger("weaponBob");
        }

        //if we're walking backward, we bob
        if (Input.GetKeyDown(KeyCode.A))
        {
            gunAnimation.SetTrigger("weaponBob");
            gunAnimation.ResetTrigger("stop");
        }
        //if we stop moving backward, no bobbing
        if (Input.GetKeyUp(KeyCode.A))
        {
            gunAnimation.SetTrigger("stop");
            gunAnimation.ResetTrigger("weaponBob");
        }

        //if we're walking backward, we bob
        if (Input.GetKeyDown(KeyCode.D))
        {
            gunAnimation.SetTrigger("weaponBob");
            gunAnimation.ResetTrigger("stop");
        }
        //if we stop moving backward, no bobbing
        if (Input.GetKeyUp(KeyCode.D))
        {
            gunAnimation.SetTrigger("stop");
            gunAnimation.ResetTrigger("weaponBob");
        }
    }
}
