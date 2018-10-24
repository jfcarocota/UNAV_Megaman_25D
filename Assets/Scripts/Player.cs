using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character3D 
{
    private GameObject healthbar;

    private void Start()
    {
        healthbar = GameObject.Find("Healthbar"); // Barra de vida.
    }



    protected override void Jump()
    {
        base.Jump();
        anim.SetBool("Grounding", grounding);

        if (grounding){ anim.SetBool("Falling", false); }

        if (jumping)
        {
            anim.SetTrigger("Jumping");
            anim.SetBool("Falling", true);
            jumping =false;
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
        if (slide&&grounding)
        {
            anim.SetTrigger("Slide");
            slide = false;
        }
    }


}
