using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Gradient attackIdleBlend;

    [HideInInspector]
    public PlayerController controller;
    [HideInInspector]
    public Animator animator;

    private float smoothAnimX;
    private float smoothAnimY;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        HandleMoveVector(controller.movement.moveVector * controller.movement.moveVector.normalized);
        HandleBlending(controller.movement.moveVector.magnitude);
    }

    private void HandleBlending(float magnitude)
    {
        // Set the idle weight
        animator.SetLayerWeight(1, Mathf.Clamp01(1 - magnitude - GetFightingState()));
        animator.SetLayerWeight(2, magnitude);
    }

    private float GetFightingState()
    {
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(3);
        if (state.IsTag("Attack"))
        {
            // currently attacking
            return attackIdleBlend.Evaluate(state.normalizedTime).a;
        }
        else
        {
            return 0;
        }
    }

    // NIschlas om du kollar så if(change back) sadge;
    private void HandleMoveVector(Vector3 moveVector)
    {
        float Yvalue = Mathf.SmoothDamp(animator.GetFloat("Forward"), moveVector.y, ref smoothAnimX, .1f);
        float Xvalue = Mathf.SmoothDamp(animator.GetFloat("Right"), moveVector.x, ref smoothAnimY, .1f);
        animator.SetFloat("Forward", Yvalue);
        animator.SetFloat("Right", Xvalue);
    }
}
