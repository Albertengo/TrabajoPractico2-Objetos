using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VidaYAtaque : MonoBehaviour
{
    [Header("VIDA Y DAÑO")]
    [SerializeField] private int vida;
    [SerializeField] private int daño;
    public int Vida { get => vida; set => vida = value; }
    public int Daño { get => daño; set => daño = value; }

    [Header("OBJETIVO DE ATAQUE")]
    [SerializeField] protected string tagObjetivoDeAtaque;

    [Header("OTROS")]
    [SerializeField] protected Animator animator;


    //ATAQUE
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagObjetivoDeAtaque) && collision.gameObject.GetComponent<IRecibirDaño>() != null)
            collision.gameObject.GetComponent<IRecibirDaño>().TomarDaño(daño);
    }
}
