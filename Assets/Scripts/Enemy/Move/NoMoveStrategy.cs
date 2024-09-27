using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Strategy/Movement/NoMovement")]
public class NoMoveStrategy : MoveStrategy
{
    public override Vector3 Move(Vector3 _curPosition, Vector3 _targetPosition)
    {
        return _curPosition;
    }

    public override void Turn(MonoBehaviour _gameObject, ref Vector3 _targetPosition, Vector3 _originPosition,
        Vector3 _endPosition, ref bool isEndPoint)
    {
        return;
    }
}
