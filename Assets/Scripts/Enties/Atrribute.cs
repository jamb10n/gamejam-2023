using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atrribute : MonoBehaviour
{
    private int _currentHitPoints, _maxHitPoints, _attackPower;
    private float movementSpeed;
    private enum faction{

    };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void healing(int hpIncAmmount){
        int Health= hpIncAmmount + CurrentHitPoints;
    }

    public int CurrentHitPoints{
        get{return _currentHitPoints;}
        set{_currentHitPoints=value;}
    }
    public int MaxHitPoints{
        get{return _maxHitPoints;}
        set{_maxHitPoints=value;}
    }
    public int AttackPower{
        get{return _attackPower;}
        set{_attackPower=value;}
    }
    public float movementSpeed{
        get{return movementSpeed;}
        set{movementSpeed=value;}
    }


}
