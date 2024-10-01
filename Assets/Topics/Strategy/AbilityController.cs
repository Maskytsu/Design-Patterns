using UnityEngine;

public class AbilityController : MonoBehaviour
{
    public IAbilityStrategy CurrentAbility;

    private void Awake()
    {
        CurrentAbility = new AbilityStrategy1();
    }

    public void UseAbility()
    {
        CurrentAbility.UseAbility();
    }
}

public interface IAbilityStrategy
{
    public void UseAbility();
}

public class AbilityStrategy1 : IAbilityStrategy
{
    public void UseAbility()
    {
        Debug.Log("Ability 1 used!");
    }
}

public class AbilityStrategy2 : IAbilityStrategy
{
    public void UseAbility()
    {
        Debug.Log("Ability 2 used!");
    }
}

public class AbilityStrategy3 : IAbilityStrategy
{
    public void UseAbility()
    {
        Debug.Log("Ability 3 used!");
    }
}

public class AbilityStrategy4 : IAbilityStrategy
{
    public void UseAbility()
    {
        Debug.Log("Ability 4 used!");
    }
}