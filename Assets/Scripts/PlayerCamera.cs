using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("Following")]
    public float movementSmoothness = 0.2f;
    public float rotationSpeed = 5f;
    public float lookaheadPos = 2;
    public float lookaheadRot = 2;
    public float lookaheadRotDistanceCutoff = 5f;

    [Header("View Bob")]
    public float followScale = 0.1f;
    public Vector2 bobScale = new Vector2(1, 1);
    public float degreesPerSecond = 90;
    public float angleCutoff = 90;

    private ViewBob bob;

    private Vector3 defaultPosition;
    private Quaternion defaultRotation;
    private Transform player;
    private Vector3 velocityPos = new Vector3();

    private Vector3 lastPlayerPos;
    private Quaternion lastPlayerRot;

    void Start()
    {
        bob = GetComponentInChildren<ViewBob>();
        bob.followScale = followScale;
        bob.bobScale = bobScale;
        bob.degreesPerSecond = degreesPerSecond;
        bob.angleCutoff = angleCutoff;

        defaultPosition = transform.localPosition;
        defaultRotation = transform.localRotation;
        player = transform.parent;
        transform.parent = null;
        lastPlayerPos = player.position;
        lastPlayerRot = player.rotation;
    }

    void Update()
    {
        Vector3 targetPos = player.TransformPoint(defaultPosition);
        Quaternion targetRot = player.rotation * defaultRotation;
        Vector3 playerMovementVelocity = (player.position - lastPlayerPos) / Time.deltaTime;
        Quaternion playerRotationVelocity;
        {
            Vector3 axis;
            float angle;
            Quaternion.FromToRotation(lastPlayerRot * Vector3.forward, player.rotation * Vector3.forward).ToAngleAxis(out angle, out axis);
            angle *= lookaheadRot / Time.deltaTime;
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
            if (playerMovement.Target != null)
            {
                float dist = Vector3.Distance(player.position, playerMovement.Target.position);
                if (dist > lookaheadRotDistanceCutoff)
                    angle /= dist;
                else
                    angle /= lookaheadRotDistanceCutoff;
            }
            playerRotationVelocity = Quaternion.AngleAxis(angle, axis);
        }
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocityPos, movementSmoothness);
        transform.position += playerMovementVelocity * lookaheadPos;

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Mathf.Clamp01(Time.deltaTime * rotationSpeed));
        transform.rotation *= playerRotationVelocity;

        transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);

        lastPlayerPos = player.position;
        lastPlayerRot = player.rotation;
    }
}
