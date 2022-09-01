using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    public HealthSystem _healthSystem = new HealthSystem(100,100);

   
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerTakeDmg(10);
            Debug.Log("Health : " + _healthSystem.Health);
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlayerHeal(15);
            Debug.Log("Health : " + _healthSystem.Health);
        }
    }

    private void PlayerTakeDmg(int dmg)
    {
        _healthSystem.DmgUnit(dmg);
        
    }

    private void PlayerHeal(int heal)
    {
        _healthSystem.HealUnit(heal);
        
    }
}
