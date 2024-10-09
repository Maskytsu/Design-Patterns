using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StateDescriptionUI : MonoBehaviour
{
    [SerializeField] private EnemyStateMachine _enemy;
    [SerializeField] private TextMeshProUGUI _descriptionTMP;

    private void Update()
    {
        _descriptionTMP.text = "Enemy state:\n" + _enemy.CurrentState.StateName;
    }
}
