using System.Collections;
using UnityEngine;

public class MovementReciver : MonoBehaviour
{
    [SerializeField] private LayerMask _obstacleLayer;

    [Header("Parameters")]
    [SerializeField] private int _tileSize = 4;
    [Space]
    [SerializeField] private float _movementSpeed = 10;
    [SerializeField] private float _rotationSpeed = 250;
    [Space]
    [SerializeField] private bool _inMotion = false;

    public void Move(Vector3 directionVector)
    {
        if (CanMove(directionVector))
        {
            StartCoroutine(MoveToDestination(directionVector));
        }
        else Debug.Log("Can't move there");
    }

    public void Rotate(Vector3 directionVector)
    {
        StartCoroutine(RotateToSide(Quaternion.Euler(directionVector)));
    }

    private IEnumerator MoveToDestination(Vector3 directionVector)
    {
        Vector3 targetPosition = transform.position + (directionVector * _tileSize);

        if (_inMotion) Debug.LogError("Previous motion not ended");
        _inMotion = true;

        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _movementSpeed * Time.deltaTime);
            yield return null;
        }

        _inMotion = false;
    }

    private IEnumerator RotateToSide(Quaternion rotationQuaternion)
    {
        Quaternion targetRotation = transform.rotation * rotationQuaternion;

        if (_inMotion) Debug.LogError("Previous motion not ended");
        _inMotion = true;

        while (transform.rotation != targetRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            yield return null;
        }

        _inMotion = false;
    }

    private bool CanMove(Vector3 directionVector)
    {
        return !Physics.Raycast(transform.position, directionVector, _tileSize, _obstacleLayer);
    }
}
