using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(menuName = "Strategy/Attack/LongAttack")]
public class LongAttackStrategy : AttackStrategy
{
    [SerializeField] float delaySeconds;
    [SerializeField] GameObject fireBall;
    [SerializeField] float fireballDistance;

    public override IEnumerator Attack(MonoBehaviour monoBehaviour)
    {
        yield return new WaitForSeconds(0.3f);
        FireBall fireballScript = fireBall.GetComponent<FireBall>();
        fireballScript.distance = fireballDistance;
        Instantiate(fireBall, monoBehaviour.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(delaySeconds);
    }
}
