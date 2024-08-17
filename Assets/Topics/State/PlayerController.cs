using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action SpacePressed;

    [SerializeField] private GameEnderTrigger _gameEnder;

    private MazeInputActions _inputActions;
    private bool _allowInput = true;

    private void Awake()
    {
        _inputActions = new MazeInputActions();
        _inputActions.PlayerMazeMap.Enable();

        _gameEnder.GameOver += OnGameOver;
    }

    void Update()
    {
        if (_allowInput && _inputActions.PlayerMazeMap.Undo.WasPerformedThisFrame()) SpacePressed?.Invoke();
    }

    private void OnGameOver()
    {
        _allowInput = false;
    }
}
