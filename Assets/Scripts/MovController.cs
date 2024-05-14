using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public abstract class MovController : MonoBehaviour
{
    [Header("L�gica")]
    [SerializeField] protected int Health;
    [SerializeField] public float velocidad;
    [SerializeField] public int da�o;

    [Header("Referencias")]
    [SerializeField] protected Animator animator;
    [SerializeField] protected Transform pos;
    

    protected abstract void Movimiento(Transform pos);

    protected abstract void Attack(int da�o);

    protected virtual void RecibirDa�o(int Da�oRecibido)
    {
        Health -= Da�oRecibido;
       
    } 
}
