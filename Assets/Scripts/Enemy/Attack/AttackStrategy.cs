using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackStrategy : ScriptableObject
{
    public abstract IEnumerator Attack(MonoBehaviour monoBehaviour);
}
