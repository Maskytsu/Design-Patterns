using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;

public class MovementCommands
{
    public class MoveCommand : ICommand
    {
        private Vector3 _movementVector;
        private MovementReciver _movementReciver;
        public MoveCommand(MovementReciver movementReciver, Vector3 movementVector)
        {
            _movementReciver = movementReciver;
            _movementVector = movementVector;
        }
        public void Execute()
        {
            _movementReciver.Move(_movementVector);
        }
        public void Undo()
        {
            _movementReciver.Move(-_movementVector);
        }
    }

    public class RotateLeftCommand : ICommand
    {
        private MovementReciver _movementReciver;
        public RotateLeftCommand(MovementReciver movementReciver)
        {
            _movementReciver = movementReciver;
        }
        public void Execute()
        {
            _movementReciver.RotateLeft();
        }
        public void Undo()
        {
            _movementReciver.RotateRight();
        }
    }

    public class RotateRightCommand : ICommand
    {
        private MovementReciver _movementReciver;
        public RotateRightCommand(MovementReciver movementReciver)
        {
            _movementReciver = movementReciver;
        }
        public void Execute()
        {
            _movementReciver.RotateRight();
        }
        public void Undo()
        {
            _movementReciver.RotateLeft();
        }
    }
}
