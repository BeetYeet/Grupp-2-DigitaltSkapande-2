using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIDataDisplay : MonoBehaviour
{
    [Header("Is this the local healthbar or the enemies?")]
    public bool isLocal = true;

    [Header("Resource Bars")]
    public Image barHP;
    public Image barGuard;
    public Image barHPRecovered;
    public Image barHPLost;
    public Image barGuardLost;

    [Header("How many seconds it takes for the bars to update")]
    [Range(0.01f, 0.25f)]
    public float showTime = .25f;

    [Header("Time untill the bar resets (seconds)")]
    public float displayDecayHP = 2f;
    public float displayDecayHPRecovered = 2f;
    public float displayDecayGuard = 2f;
    private float cooldownHPLost = 0f;
    private float cooldownHPRecovered = 0f;
    private float cooldownGuardLost = 0f;

    [Header("How often it looses 1% of its value when its decaying")]
    public float displayDecayspeedHP = 2f;
    public float displayDecayspeedHPRecovered = 2f;
    public float displayDecayspeedGuard = 2f;

    [Header("Health Script")]
    public Health health;

    /// <summary>
    /// modify this to alter %hp
    /// </summary>
    [Header("Values")]
    public float valueHP = 1f;

    /// <summary>
    /// modify this to alter %guard
    /// </summary>
    public float valueGuard = 1f;

    private float lastDisplayedValueHP = 1f;
    private float lastDisplayedValueGuard = 1f;
    private float velocityHP = 0f;
    private float velocityGuard = 0f;

    public float valueHPLost = 0f;
    public float valueGuardLost = 0f;
    private float lastDisplayedValueHPLost = 0f;
    private float lastDisplayedValueGuardLost = 0f;
    private float velocityHPLost = 0f;
    private float velocityGuardLost = 0f;

    public float valueHPRecovered = 0f;
    private float lastDisplayedValueHPRecovered = 0f;
    private float velocityHPRecovered = 0f;

    public float lastFrameHP = 1f;
    public float lastFrameGuard = 1f;

    private PlayerInputActions input;

    void Start()
    {
        var view = GetComponentInParent<PhotonView>();
        if (view && view.IsMine)
        {
            Destroy(transform.parent.parent.gameObject);
            return;
        }
        if (!(barGuard && barHP && barHPRecovered && barHPLost && barGuardLost))
        {
            Debug.LogError("Player UI Bars Unassigned!");
        }
        input = new PlayerInputActions();
        input.Enable();
        input.MainActionMap.DebugNum1.performed += DebugNum1_performed;
        input.MainActionMap.DebugNum2.performed += DebugNum2_performed;
        input.MainActionMap.DebugNum4.performed += DebugNum4_performed;
        input.MainActionMap.DebugNum5.performed += DebugNum5_performed;
    }

    private void DebugNum1_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        valueHP -= .1f;
    }
    private void DebugNum2_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        valueGuard -= .1f;
    }
    private void DebugNum4_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        valueHP += .1f;
    }
    private void DebugNum5_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        valueGuard += .1f;
    }

    private void OnEnable()
    {
        if (input != null)
            input.Enable();
    }
    private void OnDisable()
    {
        if (input != null)
            input.Disable();
    }

    void LateUpdate()
    {
        valueGuard = Mathf.Clamp01(valueGuard);
        valueHP = Mathf.Clamp01(valueHP);

        if (valueHP < lastFrameHP)
        {
            // lost hp since last frame
            float HPlost = lastFrameHP - valueHP;
            valueHPLost += HPlost;
            cooldownHPLost = displayDecayHP;
            lastFrameHP = valueHP;
        }
        if (valueHP > lastFrameHP)
        {
            // regained hp since last frame
            float HPgained = valueHP - lastFrameHP;
            valueHPRecovered += HPgained;
            cooldownHPRecovered = displayDecayHPRecovered;
            lastFrameHP = valueHP;
        }
        if (valueGuard < lastFrameGuard)
        {
            // lost guard since last frame
            float Guardlost = lastFrameGuard - valueGuard;
            valueGuardLost += Guardlost;
            cooldownGuardLost = displayDecayGuard;
            lastFrameGuard = valueGuard;
        }
        if (valueGuard > lastFrameGuard)
        {
            // recovered some guard
            lastFrameGuard = valueGuard;
        }



        cooldownHPLost -= Time.deltaTime;
        cooldownGuardLost -= Time.deltaTime;
        cooldownHPRecovered -= Time.deltaTime;

        if (valueHPLost < 0.01f)
        {
            valueHPLost = 0f;
            cooldownHPLost = 0f;
        }
        while (cooldownHPLost < -displayDecayspeedHP)
        {
            cooldownHPLost += displayDecayspeedHP;
            valueHPLost *= 0.99f;
        }

        if (valueGuardLost < 0.01f)
        {
            valueGuardLost = 0f;
            cooldownGuardLost = 0f;
        }
        while (cooldownGuardLost < -displayDecayspeedGuard)
        {
            cooldownGuardLost += displayDecayspeedGuard;
            valueGuardLost *= 0.99f;
        }

        if (valueHPRecovered < 0.01f)
        {
            valueHPRecovered = 0f;
            cooldownHPRecovered = 0f;
        }
        while (cooldownHPRecovered < -displayDecayspeedHPRecovered)
        {
            cooldownHPRecovered += displayDecayspeedHPRecovered;
            valueHPRecovered *= 0.99f;
        }


        float displayHP = Mathf.SmoothDamp(lastDisplayedValueHP, valueHP, ref velocityHP, showTime);
        float displayGuard = Mathf.SmoothDamp(lastDisplayedValueGuard, valueGuard, ref velocityGuard, showTime);

        float displayHPLost = Mathf.SmoothDamp(lastDisplayedValueHPLost, valueHPLost, ref velocityHPLost, showTime);
        float displayGuardLost = Mathf.SmoothDamp(lastDisplayedValueGuardLost, valueGuardLost, ref velocityGuardLost, showTime);

        float displayHPRecovered = Mathf.SmoothDamp(lastDisplayedValueHPRecovered, valueHPRecovered, ref velocityHPRecovered, showTime);

        lastDisplayedValueHP = displayHP;
        lastDisplayedValueGuard = displayGuard;

        lastDisplayedValueHPRecovered = displayHPRecovered;

        lastDisplayedValueHPLost = displayHPLost;
        lastDisplayedValueGuardLost = displayGuardLost;


        barHP.fillAmount = displayHP - displayHPRecovered;
        barGuard.fillAmount = displayGuard;

        barHPRecovered.fillAmount = displayHP;

        barHPLost.fillAmount = displayHP + displayHPLost;
        barGuardLost.fillAmount = displayGuard + displayGuardLost;
    }
}
