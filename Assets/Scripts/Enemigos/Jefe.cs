using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Jefe : Enemy
{
    [SerializeField] private float rotateSpeed = 0.1f;


    new void Update()
    {
        if (Vector2.Distance(jugador.position, transform.position) <= rangoDeDeteccion)
        {
            Vector2 direccionDeDisparo = jugador.position - transform.position;

            agente.SetDestination(transform.position);
            gameObject.GetComponent<DisparoJefe>().DisparoDeJefe(direccionDeDisparo);
        } 
        else
            Perseguir();
    }
}
