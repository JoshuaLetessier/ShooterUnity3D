using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    // Start is called before the first frame update

    public float currentHP;
    public float maxHP;

    public bool isDead;

    private void Update()
    {
        if(isDead)
        {
            Destroy(gameObject);
        }
    }

    void TakeDammage(float dommage)
    { 
        currentHP -= dommage;
        if(currentHP <= 0 )
            isDead = true;
    }

    void Heal(float bonusHP) 
    {
        currentHP += bonusHP;
        if(currentHP > maxHP) 
            currentHP = maxHP;
    }
}
