using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerMovement : MonoBehaviour
{
    public Transform target;

    private PlayerInputActions inputActions;
    private Vector2 moveVector;

    void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.MainActionMap.Move.performed += Move_performed;
    }

    private void Move_performed(InputAction.CallbackContext obj)
    {
        moveVector = obj.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    void FixedUpdate()
    {
    }

    private void Update()
    {
        transform.Translate(new Vector3(moveVector.x, 0f, moveVector.y) * .2f);
        transform.LookAt(target, Vector3.up);
    }
}
