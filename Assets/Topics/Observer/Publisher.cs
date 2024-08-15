using System;
using UnityEngine;
using UnityEngine.Events;

public class Publisher : MonoBehaviour
{
    private MazeInputActions _inputActions;
    private MazeInputActions.PlayerMazeMapActions Input => _inputActions.PlayerMazeMap;

    public event Action<int> MoveForwardPressedA;
    public UnityEvent<int> MoveForwardPressedUE;

    private int _pressedCount = 0;

    private void Awake()
    {
        _inputActions = new MazeInputActions();
        Input.Enable();
    }

    private void Update()
    {
        if (Input.MoveForward.WasPerformedThisFrame())
        {
            _pressedCount++;
            MoveForwardPressedA?.Invoke(_pressedCount);
            MoveForwardPressedUE?.Invoke(_pressedCount);
        }
    }
}
