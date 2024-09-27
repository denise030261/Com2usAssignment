using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Strategy/Movement/LerpMovement")]
public class LerpMoveStrategy : MoveStrategy
{
    public override Vector3 Move(Vector3 _curPosition, Vector3 _targetPosition)
    {
        _curPosition = Vector3.Lerp(_curPosition, _targetPosition, _moveSpeed * Time.deltaTime);
        return _curPosition;
    }
}
