using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviourPunCallbacks
{
    public Transform target;
    public PhotonView pView;
    private GameObject[] players;
    private PlayerInputActions inputActions;
    [SerializeField] Animator animator;
    private Vector2 moveVector;

    void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.MainActionMap.Move.performed += Move_performed;
        pView = GetComponent<PhotonView>();
        GetTarget();
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        OnJoinedRoom();
        StartCoroutine(RefreshPlayerLook());
    }

    IEnumerator RefreshPlayerLook()
    {
        yield return new WaitForSeconds(.5f);
        GetTarget();
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
                Debug.Log("Found enemy");
                return;
            }
        }
        Debug.Log("No enemy found");
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
        animationhandle(moveVector);
        if (pView.IsMine)
        {
            transform.Translate(new Vector3(moveVector.x, 0f, moveVector.y) * .2f);
        }
        transform.LookAt(target, Vector3.up);
    }

    // afred om du kollar så if(look) cringe;
    private void animationhandle(Vector3 Vectormove)
    {
        if(Vectormove.x < 0)
        {
            animator.SetBool("Forward", false);
            animator.SetBool("Backwards", false);
            animator.SetBool("Left", false);
            animator.SetBool("Right", true);
        }
        else if (Vectormove.x > 0)
        {
            animator.SetBool("Forward", false);
            animator.SetBool("Backwards", false);
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
        }
        else if(Vectormove.y > 0)
        {
            animator.SetBool("Forward", true);
            animator.SetBool("Backwards", false);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
        }
        else if(Vectormove.y < 0)
        {
            animator.SetBool("Forward", false);
            animator.SetBool("Backwards", true);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
        }
        else
        {
            animator.SetBool("Forward", false);
            animator.SetBool("Backwards", false);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
        }

    }
}
