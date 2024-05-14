using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public abstract class MovController : MonoBehaviour
{
    [Header("Lógica")]
    [SerializeField] protected int Health;
    [SerializeField] public float velocidad;
    [SerializeField] public int daño;

    [Header("Referencias")]
    [SerializeField] protected Animator animator;
    [SerializeField] protected Transform pos;
    

    protected abstract void Movimiento(Transform pos);

    protected abstract void Attack(int daño);

    protected virtual void RecibirDaño(int DañoRecibido)
    {
        Health -= DañoRecibido;
       
    } 
}
