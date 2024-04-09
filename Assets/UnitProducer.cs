using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitProducer : MonoBehaviour
{
   [SerializeField] private GameObject prefab;
   [SerializeField] private GameObject spawnPoint;
   [SerializeField] private float spawnRate;
   [SerializeField] private bool infiniteProducer;
   private float counter;

   private void FixedUpdate()
   {
      if(!infiniteProducer) return;
      
      counter += Time.deltaTime;

      if (counter >= spawnRate)
      {
         Instantiate(prefab, spawnPoint.transform.position, Quaternion.identity);
         counter = 0;
      }
   }

   public void ProduceUnit()
   {
      Instantiate(prefab, spawnPoint.transform.position, Quaternion.identity);
   }
}
