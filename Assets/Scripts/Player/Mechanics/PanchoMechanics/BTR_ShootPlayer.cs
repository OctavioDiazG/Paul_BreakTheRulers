using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class BTR_ShootPlayer : MonoBehaviour
{
    //En este codigo se instancian balas en la linea 47 y 64. se destruye en la linea 53
    //Importante congelar la rotacion en Y de el prefab de la bala
    [FormerlySerializedAs("poit")] public Transform point; //punto donde se originan las balas
    public GameObject pryectilPrefab; //Prefab del proyectil
    public float velocidad; //velocidad del proyectil
    private int cantidadDeProyectiles = 4; //cantidad de disparo para la funcion de disparo multiples
    private float angle = 45; //angulo de las balas
    private List<Quaternion> pellets; //lista de los quarteniones del disparo multiple

    private void Awake()
    {

        pellets = new List<Quaternion>(cantidadDeProyectiles); //crea una lista de los quearteiones con la cantidad de proyectiles
        for (int i = 0; i < cantidadDeProyectiles; i++)
        {
            pellets.Add(Quaternion.Euler(Vector3.zero)); //les agrega el Euler en zero (no se no hablo quartetion)
        }
    }

    public void shooting()
    {
        //Se instacia la bala en el punto de fuego
        GameObject proyectilTemporal = Instantiate(pryectilPrefab, point.position, Quaternion.identity);

        Rigidbody rb = proyectilTemporal.GetComponent<Rigidbody>();
        //les pone la velocidad a las balas
        rb.AddForce(transform.forward * velocidad);
        //Se destruye la bala 
        Destroy(proyectilTemporal, 5.0f);
    }

    public void multishoot()
    {
            //for que se genera la cantidad de balas
            for (int i = 0; i < cantidadDeProyectiles; i++)
            {
                //ponenmos la rotacion aleatoria de cada bala
                pellets[i] = Random.rotation;
                //Se instacia la bala en el punto de fuego
                GameObject proyectilTemporal = Instantiate(pryectilPrefab, point.position, point.rotation);
                //le da la rotacion random a cada balas
                proyectilTemporal.transform.rotation = Quaternion.RotateTowards(proyectilTemporal.transform.rotation, pellets[i], angle);
                //le aplica la fuerza a cada bala
                proyectilTemporal.GetComponent<Rigidbody>().AddForce(proyectilTemporal.transform.forward*velocidad);
            }
    }
}
