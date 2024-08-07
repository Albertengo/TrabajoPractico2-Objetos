using Jugador;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected Transform jugador;

    [SerializeField] protected NavMeshAgent agente;

    [SerializeField] protected float rangoDeDeteccion;

    private bool mirandoALaDerecha;

    [Header("PATRULLAJE")]
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


    protected virtual void Movimiento()
    {
        if (Vector2.Distance(jugador.position, transform.position) < rangoDeDeteccion && jugador != null) { }
            Perseguir();
    }


    protected virtual void Perseguir()
    {
        agente.SetDestination(jugador.position);
        MirarObjetivo(jugador);
    }


    protected virtual void Patrullaje()
    {
        if (Vector2.Distance(jugador.position, transform.position) > rangoDeDeteccion)
        {
            agente.SetDestination(puntosDeMovimiento[numeroAleatorio].position);

            if (Vector2.Distance(transform.position, puntosDeMovimiento[numeroAleatorio].position) <= distaciaMinima)
                numeroAleatorio = Random.Range(0, puntosDeMovimiento.Length);
        }
    }


    private void MirarObjetivo(Transform objetivo)
    {
        if (objetivo.position.x > transform.position.x && mirandoALaDerecha || objetivo.position.x < transform.position.x && !mirandoALaDerecha)
        {
            mirandoALaDerecha = !mirandoALaDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

}
