using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InputInvoker : MonoBehaviour
{
    [SerializeField] private MovementReciver _movementReciver;

    private MazeInputActions _inputActions;
    private MovementCommands _movementCommands;

    private Stack<ICommand> _undoStack = new Stack<ICommand>();

    private Queue<ICommand> _executeQueue = new Queue<ICommand>();
    private Queue<ICommand> _undoQueue = new Queue<ICommand>();

    private MazeInputActions.PlayerMazeMapActions Input => _inputActions.PlayerMazeMap;

    private bool _isBufferComplete = true;
    private float _bufferTime = 0.5f;
    private int _queuesSize = 2;

    //----------------------------------------------------------------------------------------------------
    #region Unity callbacks

    private void Awake()
    {
        _inputActions = new MazeInputActions();
        _movementCommands = new MovementCommands();
        Input.Enable();
    }

    private void Update()
    {
        ManageQueues();
        ManageInputs();
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Input.Enable();
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Input.Disable();
    }

    #endregion
    //----------------------------------------------------------------------------------------------------
    #region Update managements

    private void ManageInputs()
    {
        if (Input.MoveForward.WasPerformedThisFrame()) RunMoveCommand(transform.forward);
        if (Input.MoveBack.WasPerformedThisFrame()) RunMoveCommand(-transform.forward);
        if (Input.MoveLeft.WasPerformedThisFrame()) RunMoveCommand(-transform.right);
        if (Input.MoveRight.WasPerformedThisFrame()) RunMoveCommand(transform.right);


        if (Input.RotateLeft.WasPerformedThisFrame()) RunRotateLeftCommand();
        if (Input.RotateRight.WasPerformedThisFrame()) RunRotateRightCommand();

        if (Input.Undo.WasPerformedThisFrame()) UndoPreviousCommand();
    }

    private void ManageQueues()
    {
        if (_isBufferComplete)
        {
            if (_undoQueue.Count > 0)
            {
                ICommand command = _undoQueue.Dequeue();
                command.Undo();
                _executeQueue.Clear();
                StartCoroutine(CommandBuffer());
            }
            else if (_executeQueue.Count > 0)
            {
                ICommand command = _executeQueue.Dequeue();
                ExecuteCommand(command);
            }
        }
    }

    #endregion
    //----------------------------------------------------------------------------------------------------
    #region Running commands

    private void RunMoveCommand(Vector3 movementVector)
    {
        if (_isBufferComplete)
        {
            ICommand command = new MovementCommands.MoveCommand(_movementReciver, movementVector);
            ExecuteCommand(command);
        }
        else if (_executeQueue.Count + _undoQueue.Count <= _queuesSize)
        {
            ICommand command = new MovementCommands.MoveCommand(_movementReciver, movementVector);
            _executeQueue.Enqueue(command);
        }
    }

    private void RunRotateLeftCommand()
    {
        if (_isBufferComplete)
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

    private void RunRotateRightCommand()
    {
        if (_isBufferComplete)
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
        if(_undoStack.Count > 0 && _isBufferComplete)
        {
            ICommand command = _undoStack.Pop();
            command.Undo();
            StartCoroutine(CommandBuffer());
        }
        else if (_undoStack.Count > 0 && _executeQueue.Count + _undoQueue.Count <= _queuesSize)
        {
            ICommand command = _undoStack.Pop();
            _undoQueue.Enqueue(command);
        }
    }

    #endregion
    //----------------------------------------------------------------------------------------------------
    #region Utility methods
    private void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _undoStack.Push(command);
        StartCoroutine(CommandBuffer());
    }

    private IEnumerator CommandBuffer()
    {
        _isBufferComplete = false;
        yield return new WaitForSeconds(_bufferTime);
        _isBufferComplete = true;
    }
    #endregion
}
