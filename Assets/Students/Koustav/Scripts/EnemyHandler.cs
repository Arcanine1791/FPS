using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{

    public float health;
    public void HealthControl(float ReductionAmount)
    {
        health -= ReductionAmount;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
