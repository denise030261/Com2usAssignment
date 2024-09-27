using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public abstract class MoveStrategy : ScriptableObject
{
    public float _moveSpeed;
    public abstract Vector3 Move(Vector3 _curPosition, Vector3 _targetPosition);
    virtual public void Turn(MonoBehaviour _gameObject, ref Vector3 _targetPosition, Vector3 _originPosition,
        Vector3 _endPosition, ref bool isEndPoint)
    {
        if (isEndPoint)
        {
            _targetPosition = _originPosition; 
        }
        else
        {
            _targetPosition = _endPosition; 
        }

        _gameObject.transform.localScale = new Vector3(-_gameObject.transform.localScale.x, _gameObject.transform.localScale.y,
            _gameObject.transform.localScale.z);
        isEndPoint = !isEndPoint;
    }
}
