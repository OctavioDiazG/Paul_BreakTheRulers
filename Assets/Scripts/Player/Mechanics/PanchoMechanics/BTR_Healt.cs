using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTR_Healt : MonoBehaviour
{
    public float healt = 100f; //Cantidad de vida del personaje
    public bool isPlayer;
    
    private BTR_HealtUI salud;
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Awake()
    {
        if (isPlayer)
        {
            salud = GetComponent<BTR_HealtUI>();
            playerAnimator = GetComponentInChildren<Animator>();
        }
    }
    
    public void ApplyDamage(float _damage)
    {
        healt -= _damage;
        if (isPlayer)
        {
            salud.DisplayHealth(healt);
        }
        else
        {
            
        }

        if (healt <= 0)
        {
            playerAnimator.SetTrigger("Death");
        }
    }
}
