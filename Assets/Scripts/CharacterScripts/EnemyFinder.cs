using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyFinder : MonoBehaviour
{
    [SerializeField] private int range;

    private List<Damageable> listOfEnemy = new List<Damageable>();
    private Damageable closestEnemy;
    private Damageable target;

    public UnityEvent targetWasFound;

    public Damageable Target
    {
        get => target;
        set => target = value;
    }

    public void FindEnemyNpc()
    {
        CastSphereToFindEnemies();
        FindClosestEnemy();
        SetTargetToClosestEnemy();
        ClearEnemyList();
    }

    private void ClearEnemyList()
    {
        listOfEnemy.Clear();
    }

    private void SetTargetToClosestEnemy()
    {
        target = closestEnemy;
        targetWasFound.Invoke();
    }

    private void FindClosestEnemy()
    {
        float minrange = 99999;
        closestEnemy = null;
        foreach (Damageable it in listOfEnemy)
        {
            if (it == null)
            {
                continue;
            }
            
            if (Vector3.Distance(gameObject.transform.position, it.transform.position) < minrange)
            {
                closestEnemy = it;
            }
        }
        SetTargetToClosestEnemy();
    }
    
    private bool NpcInDifferentTeam(Collider it)
    {
        return !it.tag.Equals(gameObject.tag) && !it.tag.Equals("Other");
    }

    private void AddNpcIfItEnemy(Collider it)
    {
        if (NpcInDifferentTeam(it))
        {
            listOfEnemy.Add(it.GetComponent<Damageable>()); 
        } 
    }

    private void CastSphereToFindEnemies()
    {
        Collider[] overlapSphere = Physics.OverlapSphere(transform.position, range);
        foreach (Collider it in overlapSphere)
        {
            AddNpcIfItEnemy(it);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (NpcInDifferentTeam(other))
        {
            closestEnemy = other.GetComponent<Damageable>();
            target = closestEnemy;
            targetWasFound.Invoke();
        }
    }
}