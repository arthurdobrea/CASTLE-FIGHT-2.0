using System;
using UnityEngine;
using UnityEngine.AI;

public class MoveNpc : MonoBehaviour
{
    [SerializeField] private EnemyFinder enemyFinder; 
    [SerializeField] private NavMeshAgent agent;
    
    [SerializeField] private Damageable enemyBase;
    [SerializeField] private Damageable currentDestination;
    [SerializeField] private string enemyBaseName;

    public void SetDestination()
    {
        currentDestination = enemyFinder.Target;
    }

    private void Start()
    {
        enemyBase = GameObject.Find(enemyBaseName).GetComponent<Damageable>();
        currentDestination = enemyBase;
    }

    private void FixedUpdate()
    {
        
        try
        {
            agent.SetDestination(currentDestination.transform.position);
        }
        catch (Exception e)
        {
            enemyFinder.FindEnemyNpc();
            if (currentDestination == null)
            {
                currentDestination = enemyBase;
            }
            Debug.Log("Enemy is dead");
        }
    }
}