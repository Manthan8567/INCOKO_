using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    InputReader myInputReader;

    public static Vector2 moveInput;
    public static Vector2 turnInput;
    public static float jumpInput;


    private void Awake()
    {
        myInputReader = new InputReader();
    }

    private void OnEnable()
    {
        // Player movement input
        myInputReader.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        myInputReader.Player.Move.canceled += ctx => moveInput = ctx.ReadValue<Vector2>();

        // Player jump input
        myInputReader.Player.Jump.performed += ctx => jumpInput = ctx.ReadValue<float>();
        myInputReader.Player.Jump.canceled += ctx => jumpInput = ctx.ReadValue<float>();

        myInputReader.Player.Turn.performed += ctx => turnInput = ctx.ReadValue<Vector2>();
        myInputReader.Player.Turn.canceled += ctx => turnInput = ctx.ReadValue<Vector2>();


        myInputReader.Player.Enable();
    }

}