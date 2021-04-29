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
    [HideInInspector]
    public PlayerController controller;
    private Transform target;
    [HideInInspector]
    public PhotonView pView;
    public Vector2 moveVector;
    [HideInInspector]
    public ViewBob viewBob;
    private PlayerInputActions inputActions;
    private bool refreshLook = true;

    [Header("Close Quarters Cutoff")]
    public float cutoff = 5;
    public float cutoffRatio = .75f;

    public Transform Target { get => target; set => target = value; }

    void Start()
    {
        pView = controller.pView;

        if ((pView.IsMine && !controller.offlineMode) || (controller.offlineMode && name != "Current Enemy Player"))
        {
            inputActions = new PlayerInputActions();
            inputActions.MainActionMap.Move.performed += Move_performed;
            inputActions.Enable();
            Debug.Log(name + ": Input Created");
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
        while (target == null && timer < 10f)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            timer += 0.5f;
            GetTarget();
        }
        // Timed out, not good :(
        Debug.LogError(name + " couldn't find another player, something is really wrong...");
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
        if (target != null)
        {
            Debug.Log(name + ": already have target");
            return;
        }
        GameController.RefreshPlayers();
        List<GameObject> players = GameController.instance.players;
        if (players.Count != 2)
        {
            Debug.Log(name + ": no enemy found - wrong player count");
            return;
        }
        if (this.gameObject == players[0])
        {
            // this is player 0
            target = players[1].transform;
            players[1].GetComponent<PlayerMovement>().target = this.transform;
        }
        else
        {
            // this is player 1
            target = players[0].transform;
            players[0].GetComponent<PlayerMovement>().target = this.transform;
        }
        players[0].GetComponent<PlayerMovement>().refreshLook = true;
        players[1].GetComponent<PlayerMovement>().refreshLook = true;
        Debug.Log(name + ": enemy found");
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
        controller.animationController.animationScale = Vector2.one;
        if ((pView.IsMine && !controller.offlineMode) || (controller.offlineMode && name == "Current Player"))
        {
            float dist;
            if (target)
                dist = Vector3.Distance(transform.position, target.position);
            else
                dist = 100f;
            if (dist < cutoff)
            {
                float forwardFactor = (dist - cutoff * cutoffRatio) / (cutoff - cutoff * cutoffRatio);
                float rightwardFactor = dist / cutoff;
                Vector3 movement = moveVector.ToXZ();

                if (moveVector.y > 0)
                {
                    movement.Scale(new Vector3(rightwardFactor, 1, forwardFactor));
                    controller.animationController.animationScale = new Vector2(rightwardFactor, forwardFactor);
                }
                else
                {
                    movement.Scale(new Vector3(rightwardFactor, 1, 1));
                    controller.animationController.animationScale = new Vector2(rightwardFactor, 1);
                }


                transform.Translate(movement * moveSpeed * Time.deltaTime);
            }
            else
                transform.Translate(moveVector.ToXZ() * moveSpeed * Time.deltaTime);
            viewBob.moving = (moveVector * controller.animationController.animationScale).sqrMagnitude > 0.04f; // deadzone på 0.2 (0.2*0.2=0.04)
            viewBob.moveVectorX = moveVector.x;
        }

        if (controller.offlineMode || PhotonRoom.room.playersInRoom > 1)
        {
            GetTarget();
        }

        if (refreshLook)
            if (target != null)
                transform.LookAt(target, Vector3.up);
            else
            {
                refreshLook = false;
                Debug.LogWarning("Look Target unassigned");
            }
    }

}
