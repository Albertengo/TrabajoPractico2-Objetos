using Jugador;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MovController, IRecibirDa�o
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


    protected override void Atacar(float da�o)
    {
        jugador.GetComponent<MovController>().vida -= da�o;
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
    protected override void RecibirDa�o(float Da�oRecibido)
    {
        base.RecibirDa�o(Da�oRecibido);

        if (vida == 0)
        {
            numeroAleatorioRecolectable = Random.Range(0, recolectable.Length);
            recolectableRandom = recolectable[numeroAleatorioRecolectable];

            Instantiate(recolectableRandom, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
    */


    public void TomarDa�o()
    {
        vida -= da�o; /*JugadorScript.da�o;*/ //CAMBIAR POR DA�O DE JUGADOR

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
                case "Hacha": TomarDa�o();  /*RecibirDa�o(jugador.GetComponent<MovController>().da�o);*/
                    break;

                case "Jugador": Atacar(da�o);
                    break;
            }
    }
}
