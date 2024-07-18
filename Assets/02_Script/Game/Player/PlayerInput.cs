using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : ExpansionMonoBehaviour, IInputContainer, DefaultInput.IPlayerActions
{

    private readonly int HASH_MOVE_VALUE_KEY = "MoveValue".GetHash();
    private readonly int HASH_JUMP_EVENT_KEY = "JumpEvent".GetHash();

    private Dictionary<int, Action> _eventContainer = new();
    private Dictionary<int, object> _valueContainer = new();
    private DefaultInput _input;

    private void Awake()
    {

        _input = new();
        _input.Player.SetCallbacks(this);
        _input.Player.Enable();

    }

    public void RegisterEvent(int key, Action @event)
    {

        if (!_eventContainer.ContainsKey(key))
        {

            _eventContainer.Add(key, null);

        }

        _eventContainer[key] += @event;

    }

    public void UnregisterEvent(int key, Action @event)
    {

        if (!_eventContainer.ContainsKey(key))
            return;

        _eventContainer[key] -= @event;

    }

    public T GetValue<T>(int key) where T : struct
    {

        if (_valueContainer.TryGetValue(key, out var v))
        {

            return v.Cast<T>();

        }

        return default(T);

    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {

        var vec = context.ReadValue<Vector2>();

        if (!_valueContainer.ContainsKey(HASH_MOVE_VALUE_KEY))
            _valueContainer.Add(HASH_MOVE_VALUE_KEY, Vector3.zero);

        _valueContainer[HASH_MOVE_VALUE_KEY] = vec;

    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {

        if (_eventContainer.ContainsKey(HASH_JUMP_EVENT_KEY) && context.performed)
        {

            _eventContainer[HASH_JUMP_EVENT_KEY]?.Invoke();

        }

    }

}