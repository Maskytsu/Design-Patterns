using UnityEngine;

public class DebugObserver : MonoBehaviour
{
    [SerializeField] private Publisher _publisherToObserve;
    private int _buttonPressedCount = 0;

    private void Awake()
    {
        _publisherToObserve.MoveForwardPressedA += OnMoveForwardPressedAction;
    }

    private void OnDestroy()
    {
        _publisherToObserve.MoveForwardPressedA -= OnMoveForwardPressedAction;
    }

    private void OnMoveForwardPressedAction(int pressedCount)
    {
        Debug.Log("From Action: "+ pressedCount);
    }

    public void OnMoveForwardPressedUnityEvent(int pressedCount)
    {
        Debug.Log("From Unity Event: " + pressedCount);
    }

    public void OnButtonClick()
    {
        _buttonPressedCount++;
        Debug.Log("From Button: " + _buttonPressedCount);
    }
}
