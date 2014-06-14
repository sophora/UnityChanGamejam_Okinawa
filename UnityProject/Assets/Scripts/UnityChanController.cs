using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CapsuleCollider))]
[RequireComponent(typeof (Rigidbody))]

public class UnityChanController : MonoBehaviour
{

	private void FixedUpdate()
	{
		if(Input.GetButton("Fire1"))
		{

		}
		else if(Input.GetButton("Fire2"))
		{

		}
	}



	private void ResetCollider()
	{
		mCapsuleCollider.height = mOrgColHight;
		mCapsuleCollider.center = mOrgVectColCenter;
	}

	private void Start()
	{
		mAnimator         = GetComponent<Animator>();
		mCapsuleCollider  = GetComponent<CapsuleCollider>();
		mRigidbody        = GetComponent<Rigidbody>();
		mCameraObject     = GameObject.FindWithTag("MainCamera");
		mOrgColHight      = mCapsuleCollider.height;
		mOrgVectColCenter = mCapsuleCollider.center;
    }

	private Animator          mAnimator;
	private AnimatorStateInfo mCurrentBaseState;
	private CapsuleCollider   mCapsuleCollider;
	private Rigidbody         mRigidbody;
	private GameObject        mCameraObject;
	private float 			  mOrgColHight;
	private Vector3           mOrgVectColCenter;
}
