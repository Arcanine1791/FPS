using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorSystem 
{

    int _currentArmor;
    int _maxArmor;


    public int Armor
    {
        get { return _currentArmor; }
        set { _currentArmor = value; }
    }

    public int MaxArmor
    {
        get { return _maxArmor; }
        set { _maxArmor = value; }
    }


    public ArmorSystem(int armor, int maxarmor)
    {
        _currentArmor = armor;
        _maxArmor = maxarmor;
    }


    public void DmgUnit(int dmgAmount)
    {
        if (_currentArmor > 0)
        {
            _currentArmor -= dmgAmount;
        }
    }

    public void HealUnit(int healAmount)
    {
        if (_currentArmor < _maxArmor)
        {
            _currentArmor += healAmount;
        }
        if(_currentArmor > _maxArmor)
        {
            _currentArmor = _maxArmor;
        }
    }





}
