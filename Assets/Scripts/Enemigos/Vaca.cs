using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaca : Enemy
{
    protected override void Movimiento()
    {
        if (Vector2.Distance(jugador.position, transform.position) <= rangoDeDeteccion)
        {
            Perseguir(jugador);
            animator.SetBool("Caminando", true);
        }
        else
            animator.SetBool("Caminando", false);
    }
}
