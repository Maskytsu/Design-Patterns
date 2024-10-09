using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemyState : EnemyState
{
    public FollowingEnemyState(EnemyStateMachine enemyStateMachine)
    {
        StateName = "Following state";
        _enemyStateMachine = enemyStateMachine;
    }

    public override void Update(LayerMask layerMask)
    {
        Transform playerTransform = ManageRayCasting(layerMask);
        FollowPlayer(playerTransform);
    }

    public override void EnterState(Material redMaterial, Material yellowMaterial, List<MeshRenderer> meshesToChange)
    {
        foreach (MeshRenderer mesh in meshesToChange)
        {
            mesh.material = redMaterial;
        }
    }

    public override void OnSpacePressed(AudioSource calmAS, AudioSource angryAS)
    {
        Debug.Log("Sound from Following State.");
        angryAS.Play();
    }

    public override void ExitState()
    {

    }

    private Transform ManageRayCasting(LayerMask layerMask)
    {
        Vector3 rayOrigin = transform.position;
        Vector3 rayDirection = transform.forward;

        RaycastHit hit;
        if (!Physics.Raycast(rayOrigin, rayDirection, out hit, _rayDistance, layerMask))
        {
            _enemyStateMachine.ChangeState(new PatrolingEnemyState(_enemyStateMachine));
            return null;
        }
        return hit.transform;
    }

    private void FollowPlayer(Transform playerTransform)
    {
        
        if (playerTransform != null)
        {
            Vector3 direction = playerTransform.position - transform.position;
            float yTargetRotation = Quaternion.LookRotation(direction).eulerAngles.y;
            Quaternion targetRotation = Quaternion.Euler(0, yTargetRotation, 0);

            transform.rotation = targetRotation;
        }

        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, 10 * Time.deltaTime);
    }
}
