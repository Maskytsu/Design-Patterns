using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputInvoker : MonoBehaviour
{
    [SerializeField] private MovementReciver _movementReciver;
    [SerializeField] private TextMeshProUGUI _infoTMP;
    [Header("Parameters")]
    [SerializeField] private float _bufferTime = 0.5f;
    [SerializeField] private int _queuesSize = 2;
    [Space]
    [SerializeField] private bool _isBufferOff = true;

    private MazeInputActions _inputActions;
    private MovementCommands _movementCommands;

    private Stack<ICommand> _undoStack = new Stack<ICommand>();

    private Queue<ICommand> _executeQueue = new Queue<ICommand>();
    private Queue<ICommand> _undoQueue = new Queue<ICommand>();

    private MazeInputActions.PlayerMazeMapActions Input => _inputActions.PlayerMazeMap;

    #region Unity callbacks
    private void Awake()
    {
        _inputActions = new MazeInputActions();
        _movementCommands = new MovementCommands();

        Cursor.lockState = CursorLockMode.Locked;
        Input.Enable();
    }

    private void Update()
    {
        ManageQueues();
        ManageInputs();
    }
    #endregion
    #region Update managements
    private void ManageQueues()
    {
        if (_isBufferOff)
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
        if (Input.MoveForward.WasPerformedThisFrame()) ExecuteMoveCommand(MovementDirection.FORWARD);
        if (Input.MoveBack.WasPerformedThisFrame()) ExecuteMoveCommand(MovementDirection.BACK);
        if (Input.MoveLeft.WasPerformedThisFrame()) ExecuteMoveCommand(MovementDirection.LEFT);
        if (Input.MoveRight.WasPerformedThisFrame()) ExecuteMoveCommand(MovementDirection.RIGHT);

        if (Input.RotateLeft.WasPerformedThisFrame()) ExecuteRotateLeftCommand();
        if (Input.RotateRight.WasPerformedThisFrame()) ExecuteRotateRightCommand();

        if (Input.Undo.WasPerformedThisFrame()) UndoPreviousCommand();
    }
    #endregion
    #region Commands methods
    private void ExecuteMoveCommand(MovementDirection movementDirection)
    {
        if (_isBufferOff)
        {
            ICommand command = new MovementCommands.MoveCommand(_movementReciver, transform, movementDirection);
            ExecuteCommand(command);
        }
        else if (_executeQueue.Count + _undoQueue.Count <= _queuesSize)
        {
            ICommand command = new MovementCommands.MoveCommand(_movementReciver, transform, movementDirection);
            _executeQueue.Enqueue(command);
        }
    }

    private void ExecuteRotateLeftCommand()
    {
        if (_isBufferOff)
        {
            ICommand command = new MovementCommands.RotateLeftCommand(_movementReciver);
            ExecuteCommand(command);
        }
        else if (_executeQueue.Count + _undoQueue.Count <= _queuesSize)
        {
            ICommand command = new MovementCommands.RotateLeftCommand(_movementReciver);
            _executeQueue.Enqueue(command);
        }
    }

    private void ExecuteRotateRightCommand()
    {
        if (_isBufferOff)
        {
            ICommand command = new MovementCommands.RotateRightCommand(_movementReciver);
            ExecuteCommand(command);
        }
        else if (_executeQueue.Count + _undoQueue.Count <= _queuesSize)
        {
            ICommand command = new MovementCommands.RotateRightCommand(_movementReciver);
            _executeQueue.Enqueue(command);
        }
    }

    private void UndoPreviousCommand()
    {
        if(_undoStack.Count > 0 && _isBufferOff)
        {
            ICommand command = _undoStack.Pop();
            UndoCommand(command);
        }
        else if (_undoStack.Count > 0 && _executeQueue.Count + _undoQueue.Count <= _queuesSize)
        {
            ICommand command = _undoStack.Pop();
            _undoQueue.Enqueue(command);
        }
    }
    #endregion
    #region Utility methods
    private void ExecuteCommand(ICommand command)
    {
        _infoTMP.text = "Last used input:\n" + command.ReturnInfoString();
        command.Execute();
        _undoStack.Push(command);
        StartCoroutine(CommandBuffer());
    }

    private void UndoCommand(ICommand command)
    {
        _infoTMP.text = "Last used input:\nUndo";
        command.Undo();
        _executeQueue.Clear();
        StartCoroutine(CommandBuffer());
    }

    private IEnumerator CommandBuffer()
    {
        _isBufferOff = false;
        yield return new WaitForSeconds(_bufferTime);
        _isBufferOff = true;
    }
    #endregion
}
