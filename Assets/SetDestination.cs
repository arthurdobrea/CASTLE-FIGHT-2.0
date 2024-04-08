using System;
using UnityEngine;
using UnityEngine.AI;

public class SetDestination : MonoBehaviour
{
    [SerializeField] private Damageable destination;
    [SerializeField] private Damageable enemyBase;
    [SerializeField] private NavMeshAgent agent;

    public Damageable Destination
    {
        get => destination;
        set => destination = value;
    }

    public Damageable EnemyBase => enemyBase;

    private void Start()
    {
        SetInitialDestination();
    }

    void FixedUpdate()
    {
        try
        {
            agent.destination = destination.transform.position;
        }
        catch (Exception e)
        {
            SetInitialDestination();
        }
            
       
    }

    public void SetInitialDestination()
    {
        destination = enemyBase;
    }


}