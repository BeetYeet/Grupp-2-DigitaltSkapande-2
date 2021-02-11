using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Gradient attackIdleBlend;
    [Range(0, 1)]
    public float moveVectorUpdateTime = .5f;

    [HideInInspector]
    public PlayerController controller;
    [HideInInspector]
    public Animator animator;

    private float smoothAnimX;
    private float smoothAnimY;
    private float smoothAnimFactor;
    private float factor;

    [HideInInspector]
    public Vector2 animationScale = Vector2.one;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMoveVector(controller.movement.moveVector.Spherize());
        factor = Mathf.SmoothDamp(factor, (controller.movement.moveVector * animationScale).magnitude, ref smoothAnimFactor, .05f);
        HandleBlending(factor);
    }

    private void HandleBlending(float magnitude)
    {
        float fightingState = GetFightingState();

        // Set the idle weight
        animator.SetLayerWeight(1, 1f);//Mathf.Clamp01(1 - magnitude - fightingState));

        // Set the locomotion (movement) weight
        animator.SetLayerWeight(2, Mathf.Clamp01(magnitude - fightingState));
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
        //Debug.Log(moveVector + "\n" + animationScale);
        float Xvalue = Mathf.SmoothDamp(animator.GetFloat("Right"), moveVector.x, ref smoothAnimX, moveVectorUpdateTime) * animationScale.x;
        float Yvalue = Mathf.SmoothDamp(animator.GetFloat("Forward"), moveVector.y, ref smoothAnimY, moveVectorUpdateTime) * animationScale.y;
        animator.SetFloat("Right", Xvalue);
        animator.SetFloat("Forward", Yvalue);
    }
}
