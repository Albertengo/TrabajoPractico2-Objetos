using Jugador;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MovController, IRecibirDaño
{
    protected JugadorMov Jugador;

    [SerializeField] protected Transform jugador;
    [SerializeField] protected NavMeshAgent agente;

    [SerializeField] protected float rangoDeDeteccion;

    [SerializeField] protected string nombreDeObjetoColision;

    protected MovController JugadorScript;

    [Header("Patrullaje")]
    [SerializeField] protected Transform[] puntosDeMovimiento;
    [SerializeField] protected float distaciaMinima;
    [HideInInspector] protected int numeroAleatorio;

    [Header("COLECCIONABLES")]
    [SerializeField] protected GameObject recolectableRandom;
    [SerializeField] protected GameObject[] recolectable;
    [HideInInspector] protected int numeroAleatorioRecolectable;




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


    protected override void Atacar(float daño)
    {
        jugador.GetComponent<MovController>().vida -= daño;
        Debug.Log("Ataque");
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
        //sript para girar el sprite del enemigo

        if (Vector2.Distance(jugador.position, transform.position) > rangoDeDeteccion)
        {
            agente.SetDestination(puntosDeMovimiento[numeroAleatorio].position);

            if (Vector2.Distance(transform.position, puntosDeMovimiento[numeroAleatorio].position) <= distaciaMinima)
                numeroAleatorio = Random.Range(0, puntosDeMovimiento.Length);
        }
    }

    /*
    protected override void RecibirDaño(float DañoRecibido)
    {
        base.RecibirDaño(DañoRecibido);

        if (vida == 0)
        {
            numeroAleatorioRecolectable = Random.Range(0, recolectable.Length);
            recolectableRandom = recolectable[numeroAleatorioRecolectable];

            Instantiate(recolectableRandom, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
    */


    public void TomarDaño()
    {
        vida -= daño; /*JugadorScript.daño;*/ //CAMBIAR POR DAÑO DE JUGADOR

        if (vida == 0)
        {
            numeroAleatorioRecolectable = Random.Range(0, recolectable.Length);
            recolectableRandom = recolectable[numeroAleatorioRecolectable];

            Instantiate(recolectableRandom, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }


    protected void OnTriggerEnter2D(Collider2D collision)
    {
       nombreDeObjetoColision = collision.gameObject.tag;

            switch (nombreDeObjetoColision)
            { 
                case "Hacha": TomarDaño();  /*RecibirDaño(jugador.GetComponent<MovController>().daño);*/
                    break;

                case "Jugador": Atacar(daño);
                    break;
            }
    }
}
