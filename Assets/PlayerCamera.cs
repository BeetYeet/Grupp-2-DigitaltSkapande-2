﻿using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float movementSmoothness = 0.2f;
    public float rotationSpeed = 5f;
    public float lookaheadPos = 2;
    public float lookaheadRot = 2;

    private Vector3 defaultPosition;
    private Quaternion defaultRotation;
    private Transform player;
    private Vector3 velocityPos = new Vector3();

    private Vector3 lastPlayerPos;
    private Quaternion lastPlayerRot;

    void Start()
    {
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
            playerRotationVelocity = Quaternion.AngleAxis(angle, axis);
        }
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocityPos, movementSmoothness);
        transform.position += playerMovementVelocity * lookaheadPos;

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Mathf.Clamp01(Time.deltaTime * rotationSpeed));
        transform.rotation *= playerRotationVelocity;

        lastPlayerPos = player.position;
        lastPlayerRot = player.rotation;
    }
}
