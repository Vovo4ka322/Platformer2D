using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private HealthStealer _healthStealer;

    public void UseAbility()
    {
        List<Enemy> targets = _healthStealer.FindTargets();
        IEnumerator healthStealer = _healthStealer.StealHealth(targets);

        _healthStealer.StartCoroutine(healthStealer);
    }
}
