using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTR_AttackStats : MonoBehaviour
{
    public bool AOE;
    public float damage;
    public SphereCollider SpinArea;

    public bool isSphere;

    private void OnCollisionEnter(Collision collision)
    {
        if (isSphere)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!AOE && other.gameObject.tag == "Enemy")
        {
            //Llamar a la funcion para hacerle daño al enemigo
        }

        if (isSphere)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(AOE && other.gameObject.tag == "Enemy")
        {
            //Llamar a la funcion para hacerle daño al enemigo,
            //es necesario que el enemigo tenga un pequeño tiempo invulnerable
        }
    }
}