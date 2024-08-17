using System.Collections.Generic;
using UnityEngine;

public class PatrolingEnemyState : EnemyState
{
    private Vector3 _rotationSpeed = new Vector3(0, 60, 0);
    private float _randomDirection;

    public PatrolingEnemyState(EnemyStateMachine enemyStateMachine)
    {
        _enemyStateMachine = enemyStateMachine;
        _randomDirection = Random.Range(0, 2) == 1 ? 1 : -1;
    }

    public override void Update(LayerMask layerMask)
    {
        PatrolMovement();
        ManageRayCasting(layerMask);
    }

    public override void EnterState(Material redMaterial, Material yellowMaterial, List<MeshRenderer> meshesToChange)
    {
        foreach(MeshRenderer mesh in meshesToChange)
        {
            mesh.material = yellowMaterial;
        }
    }

    public override void OnSpacePressed(AudioSource calmAS, AudioSource angryAS)
    {
        Debug.Log("Sound from Patroling State.");
        calmAS.Play();
    }

    public override void ExitState()
    {

    }

    private void PatrolMovement()
    {
        transform.Rotate(_randomDirection * _rotationSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, 10 * Time.deltaTime);
    }

    private void ManageRayCasting(LayerMask layerMask)
    {
        Vector3 rayOrigin = transform.position;
        Vector3 rayDirection = transform.forward;

        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, _rayDistance, layerMask))
        {
            _enemyStateMachine.ChangeState(new FollowingEnemyState(_enemyStateMachine));
        }
    }
}
