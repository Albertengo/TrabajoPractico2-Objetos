using Jugador;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MovController/*, IRecibirDaño*/
{
    [SerializeField] protected Transform jugador;

    [SerializeField] protected NavMeshAgent agente;

    [SerializeField] protected float rangoDeDeteccion;

    [Header("Patrullaje")]
    [SerializeField] protected Transform[] puntosDeMovimiento;
    [SerializeField] protected float distaciaMinima;
    [HideInInspector] protected int numeroAleatorio;



    protected void Awake()
    {
        agente = GetComponent<NavMeshAgent>();

        agente.updateRotation = false;
        agente.updateUpAxis = false;

        jugador = GameObject.FindGameObjectWithTag("Jugador").transform;

        // PANTRULLAJE //
        numeroAleatorio = Random.Range(0, puntosDeMovimiento.Length);
    }


    protected void Update()
    {
        Movimiento();
    }


    protected override void Movimiento()
    {
        if (Vector2.Distance(jugador.position, transform.position) < rangoDeDeteccion && jugador != null)
            Perseguir();
    }


    protected virtual void Perseguir()
    {
        agente.SetDestination(jugador.position);
    }


    protected virtual void Patrullaje()
    {
        //script para girar el sprite del enemigo

        if (Vector2.Distance(jugador.position, transform.position) > rangoDeDeteccion)
        {
            agente.SetDestination(puntosDeMovimiento[numeroAleatorio].position);

            if (Vector2.Distance(transform.position, puntosDeMovimiento[numeroAleatorio].position) <= distaciaMinima)
                numeroAleatorio = Random.Range(0, puntosDeMovimiento.Length);
        }
    }              
}
