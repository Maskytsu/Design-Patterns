using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeB : MonoBehaviour, ICube
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private TextMeshProUGUI _textObject;
    private string _cubeName = "B";
    private bool _rotate = false;

    public void Update()
    {
        if (_rotate) _cube.transform.Rotate(new Vector3(0f, 20f, 0f) * Time.deltaTime);
    }

    public void SayHi()
    {
        _textObject.text = "Hi, I'm " + _cubeName;
    }

    public void SayHello()
    {
        _textObject.text = "Hello, I'm " + _cubeName;
    }

    public void StartRotation()
    {
        _rotate = true;
    }
}
