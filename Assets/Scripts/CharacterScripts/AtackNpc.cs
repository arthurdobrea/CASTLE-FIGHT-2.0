using System;
using UnityEngine;

public class AttackNpc : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackSpeed;
    [SerializeField] private EnemyFinder enemyFinder;
    
    private LineRenderer lineRenderer;
    
    private float counter = 0;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2; // Two points for start and end
    }

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
                lineRenderer.SetPosition(0, gameObject.transform.position);
                lineRenderer.SetPosition(1, enemyFinder.Target.gameObject.transform.position);
                enemyFinder.Target.Health = damage;
            }
        }
        catch (Exception e)
        {
            Debug.Log("Enemy is dead");
        }
    }
}