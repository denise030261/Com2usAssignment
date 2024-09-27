using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Strategy/Attack/NoAttack")]
public class NoAttackStrategy : AttackStrategy
{
    public override IEnumerator Attack(MonoBehaviour monoBehaviour)
    {
        yield return null;
    }
}
