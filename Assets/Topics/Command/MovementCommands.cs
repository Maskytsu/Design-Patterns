using UnityEngine;

public class MovementCommands
{
    public class MoveCommand : ICommand
    {
        private MovementReciver _movementReciver;
        private Transform _playerTransform;
        private MovementDirection _movementDirection;

        public MoveCommand(MovementReciver movementReciver, Transform playerTransform, MovementDirection movementDirection)
        {
            _movementReciver = movementReciver;
            _playerTransform = playerTransform;
            _movementDirection = movementDirection;
        }

        public void Execute()
        {
            Vector3 directionVector = DirectionToVector(_movementDirection);
            _movementReciver.Move(directionVector);
        }

        public void Undo()
        {
            Vector3 directionVector = -DirectionToVector(_movementDirection);
            _movementReciver.Move(directionVector);
        }

        public string ReturnInfoString()
        {
            return "Movement";
        }

        private Vector3 DirectionToVector(MovementDirection movementDirection)
        {
            Vector3 vector = _playerTransform.position;

            if (movementDirection == MovementDirection.FORWARD) vector = _playerTransform.forward;
            else if (movementDirection == MovementDirection.BACK) vector = -_playerTransform.forward;
            else if (movementDirection == MovementDirection.LEFT) vector = -_playerTransform.right;
            else if (movementDirection == MovementDirection.RIGHT) vector = _playerTransform.right;

            return vector;
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

        public string ReturnInfoString()
        {
            return "Rotation";
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

        public string ReturnInfoString()
        {
            return "Rotation";
        }
    }
}
