using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnderTrigger : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;

    public event Action GameOver;
    void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & _playerLayer) != 0)
        {
            GameOver?.Invoke();
        }
    }
}
