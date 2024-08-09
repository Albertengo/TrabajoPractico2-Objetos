using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gallina : Enemy
{
    [Header("PATRULLAJE")]
    [SerializeField] protected Transform[] puntosDeMovimiento;
    [SerializeField] protected float distaciaMinima;
    [HideInInspector] protected int numeroAleatorio;


    private void Start()
    {
        numeroAleatorio = Random.Range(0, puntosDeMovimiento.Length);
    }

    protected override void Movimiento()
    {
        Patrullaje();
    }

    private void Patrullaje()
    {
        if (Vector2.Distance(jugador.position, transform.position) > rangoDeDeteccion)
        {
            Perseguir(puntosDeMovimiento[numeroAleatorio]);

            if (Vector2.Distance(transform.position, puntosDeMovimiento[numeroAleatorio].position) <= distaciaMinima)
                numeroAleatorio = Random.Range(0, puntosDeMovimiento.Length);
        }
        else
            Perseguir(jugador);
    }
}
