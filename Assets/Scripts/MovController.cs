using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovController : MonoBehaviour
{
    [SerializeField] protected int Health;
    [SerializeField] protected string Collision;
    [SerializeField] public float velocidad;
    [SerializeField] protected Animator animator;
    [SerializeField] protected Transform pos;
    

    protected abstract void Movimiento(Transform pos);

    protected abstract void Attack(int daño);

    protected virtual void RecibirDaño(int DañoRecibido)
    {
        
    } 
}
