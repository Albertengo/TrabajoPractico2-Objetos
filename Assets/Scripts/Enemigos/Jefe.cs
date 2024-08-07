using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Jefe : Enemy
{
    protected override void Movimiento()
    {
        if (Vector2.Distance(jugador.position, transform.position) <= rangoDeDeteccion)
        {
            Vector2 direccionDeDisparo = jugador.position - transform.position;

            agente.SetDestination(transform.position);
            gameObject.GetComponent<DisparoJefe>().DisparoBasico(direccionDeDisparo);
        }
        else
            Perseguir();
    }
}
