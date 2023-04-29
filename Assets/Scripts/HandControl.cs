using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandControl : MonoBehaviour
{
    [SerializeField] InputActionReference ActionFist;
    [SerializeField] InputActionReference ActionPinch;
    [SerializeField] Animator handAnimator;
    [SerializeField] Animator clawAnimator;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float fistValue = ActionFist.action.ReadValue<float>();
        float pinchValue = ActionPinch.action.ReadValue<float>();

        handAnimator.SetFloat("Grip", fistValue);
        handAnimator.SetFloat("Trigger", pinchValue);
        clawAnimator.SetFloat("ClawGrab", pinchValue);

    }
}
