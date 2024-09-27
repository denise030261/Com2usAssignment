using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(menuName = "Strategy/Movement/MoveTowards")]
public class MoveTowardsStrategy : MoveStrategy
{
    public override Vector3 Move(Vector3 _curPosition, Vector3 _targetPosition)
    {
        return Vector3.MoveTowards(_curPosition, _targetPosition, _moveSpeed * Time.deltaTime);
    }
}
