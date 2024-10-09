using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputCommandInvoker : MonoBehaviour
{
    [SerializeField] private MovementReciver _movementReciver;
    [SerializeField] private TextMeshProUGUI _inputInfoTMP;
    [Header("Parameters")]
    [SerializeField] private float _commandBufferTime = 0.5f;
    [SerializeField] private int _queuesMaxSize = 2;

    private Stack<ICommand> _undoStack = new Stack<ICommand>();

    private Queue<ICommand> _executeQueue = new Queue<ICommand>();
    private Queue<ICommand> _undoQueue = new Queue<ICommand>();
    private bool _isCommandBufferOff = true;

    private MazeInputActions _inputActions;
    private MazeInputActions.PlayerMazeMapActions InputMap => _inputActions.PlayerMazeMap;

    #region Unity callbacks
    private void Awake()
    {
        InitializeInput();
    }

    private void Update()
    {
        ManageCommandDequeuing();
        ManageInputs();
    }
    #endregion
    #region Update managements
    private void ManageCommandDequeuing()
    {
        if (_isCommandBufferOff)
        {
            if (_undoQueue.Count > 0)
            {
                ICommand command = _undoQueue.Dequeue();
                UndoCommand(command);
            }
            else if (_executeQueue.Count > 0)
            {
                ICommand command = _executeQueue.Dequeue();
                ExecuteCommand(command);
            }
        }
    }

    private void ManageInputs()
    {
        if (InputMap.MoveForward.WasPerformedThisFrame()) ExecuteMoveCommand(MovementDirection.FORWARD);
        if (InputMap.MoveBack.WasPerformedThisFrame()) ExecuteMoveCommand(MovementDirection.BACK);
        if (InputMap.MoveLeft.WasPerformedThisFrame()) ExecuteMoveCommand(MovementDirection.LEFT);
        if (InputMap.MoveRight.WasPerformedThisFrame()) ExecuteMoveCommand(MovementDirection.RIGHT);

        if (InputMap.RotateLeft.WasPerformedThisFrame()) ExecuteRotateCommand(RotationDirection.LEFT);
        if (InputMap.RotateRight.WasPerformedThisFrame()) ExecuteRotateCommand(RotationDirection.RIGHT);

        if (InputMap.Undo.WasPerformedThisFrame()) UndoPreviousCommand();
    }
    #endregion
    #region Commands methods
    private void ExecuteMoveCommand(MovementDirection movementDirection)
    {
        if (_isCommandBufferOff)
        {
            ICommand command = new MovementCommands.MoveCommand(_movementReciver, transform, movementDirection);
            ExecuteCommand(command);
        }
        else if (_executeQueue.Count + _undoQueue.Count <= _queuesMaxSize)
        {
            ICommand command = new MovementCommands.MoveCommand(_movementReciver, transform, movementDirection);
            _executeQueue.Enqueue(command);
        }
    }

    private void ExecuteRotateCommand(RotationDirection rotationDirection)
    {
        if (_isCommandBufferOff)
        {
            ICommand command = new MovementCommands.RotateCommand(_movementReciver, rotationDirection);
            ExecuteCommand(command);
        }
        else if (_executeQueue.Count + _undoQueue.Count <= _queuesMaxSize)
        {
            ICommand command = new MovementCommands.RotateCommand(_movementReciver, rotationDirection);
            _executeQueue.Enqueue(command);
        }
    }

    private void UndoPreviousCommand()
    {
        if(_undoStack.Count > 0 && _isCommandBufferOff)
        {
            ICommand command = _undoStack.Pop();
            UndoCommand(command);
        }
        else if (_undoStack.Count > 0 && _executeQueue.Count + _undoQueue.Count <= _queuesMaxSize)
        {
            ICommand command = _undoStack.Pop();
            _undoQueue.Enqueue(command);
        }
    }
    #endregion
    #region Utility methods
    private void InitializeInput()
    {
        _inputActions = new MazeInputActions();
        Cursor.lockState = CursorLockMode.Locked;
        InputMap.Enable();
    }

    private void ExecuteCommand(ICommand command)
    {
        _inputInfoTMP.text = "Last used input:\n" + command.ReturnInfoString();
        command.Execute();
        _undoStack.Push(command);
        StartCoroutine(CommandBuffer());
    }

    private void UndoCommand(ICommand command)
    {
        _inputInfoTMP.text = "Last used input:\nUndo";
        command.Undo();
        _executeQueue.Clear();
        StartCoroutine(CommandBuffer());
    }

    private IEnumerator CommandBuffer()
    {
        _isCommandBufferOff = false;
        yield return new WaitForSeconds(_commandBufferTime);
        _isCommandBufferOff = true;
    }
    #endregion
}