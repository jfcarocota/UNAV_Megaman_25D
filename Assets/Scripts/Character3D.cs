using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore.PlayerController;

[RequireComponent(typeof(Animator))]
public class Character3D : MonoBehaviour 
{
	[SerializeField]
    private float moveSpeed = 2.0f;

	protected Rigidbody rb;

	//Jump
	[SerializeField]
	private float jumpForce = 1f;

	protected bool jumping;
	protected bool shoot;
	protected bool slide;
	protected Animator anim;
    protected float rotY = 0f;

	[SerializeField]
    GroundSystem groundSystem;
	protected bool grounding;

    private void Awake()
    {
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
    {
		Move3D();
		Jump();
	}


	private void Update()
	{
		Shoot();
        Flip();
		Slide();
	}

	protected virtual void Move3D()
	{
		grounding = groundSystem.CheckGround(transform);
         
        transform.Translate(0f, 0f, moveSpeed * Mathf.Abs(ComponentX) * Time.deltaTime);
	}

	protected virtual void Jump()
	{
		jumping=Btn_jump & grounding;
		if(jumping)
		{
			rb.AddForce(Vector3.up * (jumping?jumpForce:0), ForceMode.Impulse);
		}
	}

    void Flip()
    {
        rotY = ComponentX > 0f ? 0f : ComponentX < 0f ? 180 : rotY;
        transform.rotation = Quaternion.Euler(new Vector3(0f, rotY, 0f));
    }

	protected virtual void Slide()
	{
		slide = (Btn_Slide)?true:false;
	}
	protected virtual void Shoot()
	{
		shoot = (Btn_Fire)?true:false;
	}

	private void OnDrawGizmos()
	{
		groundSystem.DrawRay(transform);
		Gizmos.color = Color.red;
		Gizmos.DrawRay((Vector3)transform.position + groundSystem.StartPosition,transform.forward * 1f);
		//Gizmos.DrawRay((Vector3)transform.position + groundSystem.StartPosition, transform.right * 2f);
	}

	protected float ComponentX
	{
		get
		{
			return ControlSystem.Axis.x;
		}
	}

	protected bool Btn_jump
    {
        get
        {
            return ControlSystem.Btn_jump;
        }
    }

	protected bool Btn_Fire
	{
		get
		{
			return ControlSystem.Btn_fire;
		}
	}

	protected bool Btn_Slide
	{
		get
		{
			return ControlSystem.Btn_slide;
		}
	}
}
