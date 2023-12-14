using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DIALOUGE
{
public class PlayerInpuManager : MonoBehaviour
{
    private PlayerInput input;
    private List<(InputAction action, Action<InputAction.CallbackContext> command)> actions = new List<(InputAction action, Action<InputAction.CallbackContext> command)> ();

    private void Awake()
    {
        input = GetComponent<PlayerInput> ();

        InitializeActions();
    }

    private void InitializeActions()
    {
        actions.Add((input.actions["Next"], PromptAdvance));
    }


    private void OnEnable()
    {
        foreach (var inputAction in actions)
            inputAction.action.performed += inputAction.command;
    }

    private void OnDisable()
    {
        foreach (var inputAction in actions)
            inputAction.action.performed -= inputAction.command;
    }

    public void PromptAdvance(InputAction.CallbackContext c)
    {
        DialougeSystem.instance.OnUserPrompt_Next();
    }


}
}