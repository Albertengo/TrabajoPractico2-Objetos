using Jugador;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MovController
{
    protected JugadorMov Jugador;

    [SerializeField] protected Transform objetivo;
    [SerializeField] protected NavMeshAgent agente;

    [Header("Patrullaje")]
    [SerializeField] protected Transform[] puntosDeMovimiento;
    [SerializeField] protected float distaciaMinima;
    [SerializeField] protected float rangoDeDeteccion;
    protected int numeroAleatorio;


    protected void Awake()
    {
        agente = GetComponent<NavMeshAgent>();

        agente.updateRotation = false;
        agente.updateUpAxis = false;

        objetivo = GameObject.FindGameObjectWithTag("Jugador").transform;

        // PANTRULLAJE //
        numeroAleatorio = Random.Range(0, puntosDeMovimiento.Length);
    }

    protected void Update()
    {
        Movimiento(/*pos*/);
    }


    protected override void Atacar(int daño)
    {
        //ataca cuando el jugador se acerca demasiado
        //ataque x colision (default)
        //Jugador.Health = Jugador.Health - daño;

        //Debug.Log(daño);
    }


    protected override void Movimiento(/*Transform pos*/)
    {
        //Patrullaje
        //sript para girar el sprite del enemigo

        if (Vector2.Distance(objetivo.position, transform.position) < rangoDeDeteccion)
            Perseguir();
        else 
        {
            agente.SetDestination(puntosDeMovimiento[numeroAleatorio].position);

            if (Vector2.Distance(transform.position, puntosDeMovimiento[numeroAleatorio].position) <= distaciaMinima)
                numeroAleatorio = Random.Range(0, puntosDeMovimiento.Length);
        }
    }


    protected virtual void Perseguir()
    {
        if (objetivo != null)
            agente.SetDestination(objetivo.position);
    }


    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hacha"))
        {
            RecibirDaño(Jugador.daño);
            Atacar(daño);
        }
    }
}
