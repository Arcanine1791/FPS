using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem 
{
    int _currentHealth;
    int _maxHealth;


    public int Health
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }

    public int MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }


    public HealthSystem(int health,int maxhealth)
    {
        _currentHealth = health;
        _maxHealth = maxhealth;
    }


    public void DmgUnit(int dmgAmount)
    {
        if(_currentHealth>0)
        {
            _currentHealth -= dmgAmount;
        }
    }

    public void HealUnit(int healAmount)
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth += healAmount;
        }
        if(_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }



}
