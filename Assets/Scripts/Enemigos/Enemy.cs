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
    protected int numeroAleatorio;


    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();

        agente.updateRotation = false;
        agente.updateUpAxis = false;

        objetivo = GameObject.FindGameObjectWithTag("Jugador").transform;

        // PANTRULLAJE //
        numeroAleatorio = Random.Range(0, puntosDeMovimiento.Length);
    }


    protected override void Atacar(int daño)
    {
        //ataca cuando el jugador se acerca demasiado
        //ataque x colision (default)
        Jugador.Health = Jugador.Health - daño;

        Debug.Log(daño);
    }


    protected override void Movimiento(Transform pos)
    {
        //Patrullaje

        //Se mueve hacia un punto
        transform.position = Vector2.MoveTowards(transform.position, puntosDeMovimiento[numeroAleatorio].position, velocidad * Time.deltaTime);

        //Si llega al punto anterior, busca una nuevo
        if (Vector2.Distance(transform.position, puntosDeMovimiento[numeroAleatorio].position) < distaciaMinima)
            numeroAleatorio = Random.Range(0, puntosDeMovimiento.Length);
    }


    protected virtual void Perseguir()
    {
        if (objetivo != null)
            agente.SetDestination(objetivo.position);
    }


    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador")) // cambiar para que pierda vida cuando colisiona con las hachas del jugador
        {
            RecibirDaño(Jugador.daño);
            Atacar(daño);
        }
    }
}
