using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityInputController : MonoBehaviour
{
    [SerializeField] private AbilityController _abilityController;

    private AbilityInputActions.PlayerAbilityMapActions _abilityMap;

    private void Awake()
    {
        _abilityMap = new AbilityInputActions().PlayerAbilityMap;
        _abilityMap.Enable();
    }

    private void Update()
    {
        ManageInput();
    }

    private void ManageInput()
    {
        if (_abilityMap.ChooseAbility1.WasPerformedThisFrame()) 
            _abilityController.CurrentAbility = new AbilityStrategy1();
        if (_abilityMap.ChooseAbility2.WasPerformedThisFrame()) 
            _abilityController.CurrentAbility = new AbilityStrategy2();
        if (_abilityMap.ChooseAbility3.WasPerformedThisFrame()) 
            _abilityController.CurrentAbility = new AbilityStrategy3();
        if (_abilityMap.ChooseAbility4.WasPerformedThisFrame()) 
            _abilityController.CurrentAbility = new AbilityStrategy4();

        if (_abilityMap.UseAbility.WasPerformedThisFrame())
            _abilityController.CurrentAbility.UseAbility();
    }
}
