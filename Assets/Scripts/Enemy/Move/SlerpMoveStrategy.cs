using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Strategy/Movement/SlerpMovement")]
public class SlerpMoveStrategy : MoveStrategy
{
    public override Vector3 Move(Vector3 _curPosition, Vector3 _targetPosition)
    {
        _curPosition = Vector3.Slerp(_curPosition, _targetPosition, _moveSpeed * Time.deltaTime);
        return _curPosition;
    }

}
