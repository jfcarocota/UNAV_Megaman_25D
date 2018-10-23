using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore.PlayerController;

[RequireComponent(typeof(Animator))]
public class Character3D : MonoBehaviour 
{
	[SerializeField]
    private float moveSpeed = 2.0f;
	
	protected Animator anim;
	protected Rigidbody rb;

	[SerializeField]
    protected float speedLimit;
    Vector3 clampVel;
	public Vector3 normal;

	//Jump
	[SerializeField]
	private float jumpForce = 1f;

	protected bool jumping;
	protected bool shoot;
	protected bool slide;
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
	}


	private void Update()
	{
		Shoot();
        Flip();
		Slide();
		Jump();
	}

	protected virtual void Move3D()
	{
		grounding = groundSystem.CheckGround(transform);
         
        //transform.Translate(0f, 0f, moveSpeed * Mathf.Abs(ComponentX) * Time.deltaTime);
		//rb.AddForce(grounding & ComponentX != 0f?
		//	Vector3.ProjectOnPlane(-Vector3.forward * Mathf.Abs(ComponentX) * moveSpeed,Vector3.zero)
		//	: Vector3.forward * moveSpeed * Mathf.Abs(ComponentX), ForceMode.Impulse);
		
		rb.AddForce(grounding & ComponentX != 0f?
			Vector3.ProjectOnPlane(
				ComponentX >= 0f ? Vector3.forward:Vector3.back,normal)
				: (ComponentX >= 0f ? Vector3.forward:Vector3.back) * moveSpeed * Mathf.Abs(ComponentX), ForceMode.Impulse);


		clampVel = Vector3.ClampMagnitude(rb.velocity, speedLimit);

		rb.velocity = new Vector3(0f,rb.velocity.y,
            grounding & ComponentX != 0f ? clampVel.z :
            grounding & ComponentX == 0f ? 0f : 
            !grounding & ComponentX != 0f ? clampVel.z : 0f
        );

		rb.velocity -= ComponentX == 0f ? normal : Vector3.zero;
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
		Gizmos.DrawRay((Vector3)transform.position + groundSystem.StartPosition,transform.forward * 0.2f);
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
