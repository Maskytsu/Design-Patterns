using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public EnemyState CurrentState { get; private set; }

    [Header("Color fields")]
    [SerializeField] private List<MeshRenderer> _coloredMeshes = new List<MeshRenderer>();
    [SerializeField] private Material _redMaterial;
    [SerializeField] private Material _yellowMaterial;
    [Header("Audio")]
    [SerializeField] private AudioSource _calmBirdAS;
    [SerializeField] private AudioSource _angryBirdAS;
    [Header("Other")]
    [SerializeField] private PlayerController _player;
    [SerializeField] private LayerMask _playerLayer;

    private void Awake()
    {
        InitializeState();
    }

    private void Start()
    {
        _player.SpacePressed += OnSpacePressed;
    }

    private void Update()
    {
        CurrentState.Update(_playerLayer);
    }

    public void ChangeState(EnemyState givenState)
    {
        CurrentState.ExitState();
        CurrentState = givenState;
        CurrentState.EnterState(_redMaterial, _yellowMaterial, _coloredMeshes);
    }

    public void OnSpacePressed()
    {
        CurrentState.OnSpacePressed(_calmBirdAS, _angryBirdAS);
    }

    private void InitializeState()
    {
        CurrentState = new PatrolingEnemyState(this);
        CurrentState.EnterState(_redMaterial, _yellowMaterial, _coloredMeshes);
    }
}