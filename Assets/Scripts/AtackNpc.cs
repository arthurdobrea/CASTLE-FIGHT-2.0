using System;
using UnityEngine;

public class AttackNpc : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackSpeed;
    [SerializeField] private EnemyFinder enemyFinder;
    private float counter = 0;

    private void FixedUpdate()
    {
        counter += Time.deltaTime;
        
        if (enemyFinder.Target == null)
        {
            return;
        }

        try
        {
            if (counter >= attackSpeed)
            {
                counter = 0;
                enemyFinder.Target.Health = damage;
            }
        }
        catch (Exception e)
        {
            Debug.Log("Enemy is dead");
        }
    }
}