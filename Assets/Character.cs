using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
   [SerializeField] private float damage;
   [SerializeField] private float attackRange;
   [SerializeField] private float attackSpeed;
   [SerializeField] private SetDestination destinationSetter;
   [SerializeField] private List<Damageable> enemy;
   [SerializeField] private Damageable currentTarget;
   private float counter = 0;

   public float Damage
   {
      get => damage;
      set => damage = value;
   }

   public float AttackRange
   {
      get => attackRange;
      set => attackRange = value;
   }

   public float AttackSpeed
   {
      get => attackSpeed;
      set => attackSpeed = value;
   }

   public void Attack()
   {
      currentTarget.Health = damage;
   }

   private void Start()
   {
      destinationSetter.SetInitialDestination();
   }

   private void FixedUpdate()
   {
      if (counter >= attackSpeed)
      {
         if (enemy.Count != 0)
         {
            if (currentTarget == null)
            {
               FindClosestTarget();
            }
            else
            {
               if (Vector3.Distance(gameObject.transform.position, currentTarget.transform.position) >= AttackRange)
               {
                  enemy.Remove(currentTarget);
                  currentTarget = null;
               }
               else
               {
                  Attack();
               }
            }
            counter = 0;
         }
         if (enemy.Count ==0)
         {
            destinationSetter.SetInitialDestination();
         }
      }
      else
      {
         counter += Time.deltaTime;
      }
   }

   private void FindClosestTarget()
   {
      float nearestTarget = float.MaxValue;
      Damageable temp = null;
      
      for (int i = 0; i < enemy.Count; i++)
      {
         if (enemy[i] == null)
         {
            enemy.Remove(enemy[i]);
         }
         else if(Vector3.Distance(enemy[i].transform.position,gameObject.transform.position) < nearestTarget)
         {
            temp = enemy[i];
         }
      }
      if (temp != null)
      {
         currentTarget = temp;
      }
   }

   private void OnTriggerEnter(Collider other)
   {
      if (!other.tag.Equals(gameObject.tag) && !other.tag.Equals("Other"))
      {
         Damageable enemyTarget = other.GetComponent<Damageable>();
         destinationSetter.Destination = enemyTarget;
         if (!enemy.Contains(enemyTarget))
         {
            enemy.Add(enemyTarget);
         }
      }
   }

   private void OnTriggerExit(Collider other)
   {
      enemy.Remove(other.GetComponent<Damageable>());
   }
}
