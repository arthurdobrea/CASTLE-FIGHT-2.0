using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float team;
    
    public float Health
    {
        get => health;
        set
        {
            if ((health - value)<=0)
            {
                Destroy(gameObject);
            }
            else
            {
                health -= value;
            }
        }
    }

    public float Team => team;
}
