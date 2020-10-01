using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon;
using UnityEngine.InputSystem;



public class PlayerMovement : MonoBehaviourPunCallbacks
{
    public Transform target;
    public PhotonView pView;
    private GameObject[] players;
    private PlayerInputActions inputActions;
    private Vector2 moveVector;

    void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.MainActionMap.Move.performed += Move_performed;
        pView = GetComponent<PhotonView>();
    }

    private void Move_performed(InputAction.CallbackContext obj)
    {
        moveVector = obj.ReadValue<Vector2>();
    }

    public override void OnJoinedRoom()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            if (!players[i].GetComponent<PhotonView>().IsMine)
            {
                target = players[i].transform;
            }
        }
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
        if (pView.IsMine)
        {
            transform.Translate(new Vector3(moveVector.x, 0f, moveVector.y) * .2f);
            transform.LookAt(target, Vector3.up);
        }
    }
}
