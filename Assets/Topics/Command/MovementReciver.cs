using UnityEngine;

public class MovementReciver : MonoBehaviour
{
    [SerializeField] private LayerMask _obstacleLayer;

    private int _tileSize = 4;
    private bool _inMotion = false;

    //POPRAWIÆ TO---------------------------------------------------
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float startTime;
    private float speed = 10f;
    private float journeyLength;
    private bool moving = false;

    private void Update()
    {
        if (moving) ManageMovement();

    }

    private void ManageMovement()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;

        transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);
        if (transform.position == targetPosition) moving = false;
    }

    public void Move(Vector3 movementVector)
    {
        if (CanMove(movementVector))
        {
            Debug.Log("Moving to: " + movementVector);
            //transform.position += movementVector * _tileSize;
            if (moving) Debug.LogError("KRUWAAAA");
            startPosition = transform.position;
            targetPosition = transform.position + (movementVector * _tileSize);
            startTime = Time.time;
            journeyLength = Vector3.Distance(startPosition, targetPosition);
            moving = true;
        }
        else
        {
            Debug.Log("Can't move there");
        }
    }
    //PONI¯EJ DODAÆ P£YNNE PRZEJŒCIA---------------------------------------------------------------
    public void RotateLeft()
    {
        Debug.Log("Rotating Left");
        transform.Rotate(0, -90, 0);
        if (_inMotion) Debug.Log("Previous motion not ended");
    }

    public void RotateRight()
    {
        Debug.Log("Rotating Right");
        transform.Rotate(0, 90, 0);
    }

    private bool CanMove(Vector3 movementVector)
    {
        return !Physics.Raycast(transform.position, movementVector, _tileSize/2, _obstacleLayer);
    }

    private bool CanRotate()
    {
        return true;
    }
}
