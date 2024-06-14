using Jugador;
using UnityEngine;
using UnityEngine.AI;

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

    protected override void RecibirDaño(int DañoRecibido)
    {
        base.RecibirDaño(DañoRecibido);

        if (Health == 0)
        {
            numeroAleatorioRecolectable = Random.Range(0, recolectable.Length);
            recolectableRandom = recolectable[numeroAleatorioRecolectable];

            Instantiate(recolectableRandom, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
        
        // si la vida del enemigo es 0, destruye el enemigo y suelta un punto o power up
    }


    protected void OnTriggerEnter2D(Collider2D collision)
    {
       nombreDeObjetoColision = collision.gameObject.tag;

            switch (nombreDeObjetoColision)
            { 
                case "Hacha": RecibirDaño(objetivo.GetComponent<MovController>().daño);
                    break;

                case "Jugador": Atacar(daño);
                    break;
            }
    }
}
