using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private XRRayInteractor xRRayInteractor_Grap;
    [SerializeField] private XRRayInteractor xRRayInteractor_Teleport;

    [SerializeField] private InputActionReference _Joystick_North_Sector;

    private void Awake()
    {
        xRRayInteractor_Teleport.enabled = false;

    }
    private void OnEnable()
    {
        _Joystick_North_Sector.action.performed += PalanArribaPresionada;
        _Joystick_North_Sector.action.canceled += PalanArribaPresionada;
    }



    private void OnDisable()
    {
        _Joystick_North_Sector.action.performed -= PalanArribaPresionada;
        _Joystick_North_Sector.action.canceled -= PalanArribaLiberada;
    }
    private void PalanArribaPresionada(InputAction.CallbackContext context)
    {
        xRRayInteractor_Grap.enabled = false;
        xRRayInteractor_Teleport.enabled = true;


    }

    private void PalanArribaLiberada(InputAction.CallbackContext context) => Invoke("PalanArribaLiberada_Invoke", 0.01f);
    private void PalanArribaLiberada_Invoke()
    {
        xRRayInteractor_Grap.enabled = true;
        xRRayInteractor_Teleport.enabled = false;


    }

}