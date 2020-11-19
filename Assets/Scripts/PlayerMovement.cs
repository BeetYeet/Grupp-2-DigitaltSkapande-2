using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviourPunCallbacks
{
    public float moveSpeed = 3f;
    public Transform target;
    public PhotonView pView;
    public Animator animator;
    private Vector2 moveVector;
    private ViewBob viewBob;
    private GameObject[] players;
    private PlayerInputActions inputActions;
    private float smoothAnimX;
    private float smoothAnimY;
    private bool refreshLook = true;

    void Awake()
    {
        pView = GetComponent<PhotonView>();
        if (pView.IsMine)
        {
            name = "Current Player";
            viewBob = GetComponentInChildren<ViewBob>();
            inputActions = new PlayerInputActions();
            inputActions.MainActionMap.Move.performed += Move_performed;
        }
        else
        {
            name = "Current Enemy Player";
            Destroy(GetComponentInChildren<PlayerCamera>().gameObject);
        }
        GetTarget();
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        OnJoinedRoom();
        StartCoroutine(AquireTarget());
    }

    public IEnumerator AquireTarget()
    {
        float timer = 0f;
        while (!target && timer < 10f)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            timer += 0.5f;
            GetTarget();
        }
        if (timer >= 10f)
        {
            // Timed out, not good :(
            Debug.LogError(name + " couldn't find another player, something is really wrong...");
        }
    }

    private void Move_performed(InputAction.CallbackContext obj)
    {
        moveVector = obj.ReadValue<Vector2>();
    }

    public override void OnJoinedRoom()
    {
        GetTarget();
    }

    public void GetTarget()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].GetComponent<PhotonView>().IsMine != photonView.IsMine)
            {
                target = players[i].transform;
                players[i].GetComponent<PlayerMovement>().target = transform;
                Debug.Log(name + ": Found enemy");
                refreshLook = true;
                return;
            }
        }
        Debug.Log(name + ": No enemy found");
    }


    public override void OnEnable()
    {
        base.OnEnable();
        if (inputActions != null)
            inputActions.Enable();
    }

    public override void OnDisable()
    {
        base.OnDisable();
        if (inputActions != null)
            inputActions.Disable();
    }

    void FixedUpdate()
    {
    }


    private void Update()
    {
        HandleAnimations(moveVector);
        if (pView.IsMine)
        {
            transform.Translate(moveVector.ToXZ() * moveSpeed * Time.deltaTime);
            viewBob.moving = moveVector.sqrMagnitude > 0.04f; // deadzone på 0.2 (0.2*0.2=0.04)
            viewBob.moveVectorX = moveVector.x;
        }

        if (PhotonRoom.room.playersInRoom > 1)
        {
            GetTarget();
        }

        if (refreshLook)
            if (target)
                transform.LookAt(target, Vector3.up);
            else
            {
                refreshLook = false;
                Debug.LogWarning("Look Target unassigned");
            }
    }

    // NIschlas om du kollar så if(change back) sadge;
    private void HandleAnimations(Vector3 moveVector)
    {
        float Yvalue = Mathf.SmoothDamp(animator.GetFloat("Forward"), moveVector.y, ref smoothAnimX, .1f);
        float Xvalue = Mathf.SmoothDamp(animator.GetFloat("Right"), moveVector.x, ref smoothAnimY, .1f);
        animator.SetFloat("Forward", Yvalue);
        animator.SetFloat("Right", Xvalue);
    }
}
