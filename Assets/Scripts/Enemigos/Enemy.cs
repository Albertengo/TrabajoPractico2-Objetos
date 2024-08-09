using Jugador;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected Transform jugador;

    [SerializeField] protected Animator animator;

    [SerializeField] protected NavMeshAgent agente;

    [SerializeField] protected float rangoDeDeteccion;

    private bool mirandoALaDerecha;



    protected void Awake()
    {
        agente = GetComponent<NavMeshAgent>();

        agente.updateRotation = false;
        agente.updateUpAxis = false;

        jugador = GameObject.FindGameObjectWithTag("Jugador").transform;
    }


    protected void Update()
    {
        Movimiento();
    }



    protected abstract void Movimiento();


    protected virtual void Perseguir(Transform objetivo)
    {
        agente.SetDestination(objetivo.position);
        MirarObjetivo(objetivo);
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
