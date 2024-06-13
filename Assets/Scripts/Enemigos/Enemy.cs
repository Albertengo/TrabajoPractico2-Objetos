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

    [SerializeField] protected float rangoDeDeteccion;

    [SerializeField] protected string nombreDeObjetoColision;

    [Header("Patrullaje")]
    [SerializeField] protected Transform[] puntosDeMovimiento;
    [SerializeField] protected float distaciaMinima;
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
        Movimiento();
    }


    protected override void Atacar(int daño)
    {
        objetivo.GetComponent<MovController>().Health -= daño;


        Debug.Log("Ataque");

        //ataca cuando el jugador se acerca demasiado
        //ataque x colision (default)
        //Jugador.Health = Jugador.Health - daño;


    }


    protected override void Movimiento()
    {
        if (Vector2.Distance(objetivo.position, transform.position) < rangoDeDeteccion)
            Perseguir();
    }


    protected virtual void Perseguir()
    {
        agente.SetDestination(objetivo.position);
    }

    protected virtual void Patrullaje()
    {
        //sript para girar el sprite del enemigo

        if (Vector2.Distance(objetivo.position, transform.position) > rangoDeDeteccion)
        {
            agente.SetDestination(puntosDeMovimiento[numeroAleatorio].position);

            if (Vector2.Distance(transform.position, puntosDeMovimiento[numeroAleatorio].position) <= distaciaMinima)
                numeroAleatorio = Random.Range(0, puntosDeMovimiento.Length);
        }
    }


    protected void OnTriggerEnter2D(Collider2D collision)
    {
       nombreDeObjetoColision = collision.gameObject.tag;

            switch (nombreDeObjetoColision)
            { 
                case "Hacha": Debug.Log("Recibi daño"); /*RecibirDaño(Jugador.daño);*/
                    break;

                case "Jugador": Atacar(daño);
                    break;
            }
    }
}
