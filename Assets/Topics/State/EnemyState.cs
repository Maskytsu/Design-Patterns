using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class EnemyState
{
    protected EnemyStateMachine _enemyStateMachine;
    protected float _rayDistance = 5f;
    protected Transform transform => _enemyStateMachine.transform;

    public abstract void Update(LayerMask layerMask);
    public abstract void EnterState(Material redMaterial, Material yellowMaterial, List<MeshRenderer> meshesToChange);
    public abstract void OnSpacePressed(AudioSource calmAS, AudioSource angryAS);
    public abstract void ExitState();
}