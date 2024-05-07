using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovController : MonoBehaviour
{
    [SerializeField] protected float velocidad;
    [SerializeField] protected Animator animator;
    [SerializeField] protected Transform pos;
    

    protected abstract void Movimiento(Transform pos);

    protected abstract void Attack(int daño);
}
