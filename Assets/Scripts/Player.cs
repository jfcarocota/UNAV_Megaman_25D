using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character3D 
{
    private GameObject healthbar;

    private void Start()
    {
        healthbar = GameObject.Find("Healthbar");
    }

    protected override void Jump()
    {
        base.Jump();
        anim.SetBool("Grounding", grounding);
        if (jumping)
        {
            anim.SetTrigger("Jumping");
            jumping=false;
        }
    }
	protected override void Move3D()
	{
		base.Move3D();
		
		anim.SetFloat("InputX", Mathf.Abs(ComponentX));
	}

    protected override void Shoot()
    {
        base.Shoot();

        if (shoot)
        {
            anim.SetTrigger("Shoot");
            shoot=false;
        }
    }

    protected override void Slide()
    {
        base.Slide();
        if (slide)
        {
            anim.SetTrigger("Slide");
            slide = false;
        }
    }


}
