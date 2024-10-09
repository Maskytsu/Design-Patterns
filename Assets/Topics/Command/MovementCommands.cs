using UnityEngine;
using static UnityEngine.GridBrushBase;

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

    public class RotateCommand : ICommand
    {
        private MovementReciver _movementReciver;
        private RotationDirection _rotationDirection;

        public RotateCommand(MovementReciver movementReciver, RotationDirection rotationDirection)
        {
            _movementReciver = movementReciver;
            _rotationDirection = rotationDirection;
        }

        public void Execute()
        {
            Vector3 directionVector = DirectionToVector(_rotationDirection);
            _movementReciver.Rotate(directionVector);
        }

        public void Undo()
        {
            Vector3 directionVector = -DirectionToVector(_rotationDirection);
            _movementReciver.Rotate(directionVector);
        }

        public string ReturnInfoString()
        {
            return "Rotation";
        }

        private Vector3 DirectionToVector(RotationDirection rotationDirection)
        {
            Vector3 vector = Vector3.zero;

            if (rotationDirection == RotationDirection.LEFT) vector = new Vector3(0, -90, 0);
            else if (rotationDirection == RotationDirection.RIGHT) vector = new Vector3(0, 90, 0);

            return vector;
        }
    }
}

public enum MovementDirection
{
    FORWARD,
    BACK,
    LEFT,
    RIGHT
}

public enum RotationDirection
{
    LEFT,
    RIGHT
}