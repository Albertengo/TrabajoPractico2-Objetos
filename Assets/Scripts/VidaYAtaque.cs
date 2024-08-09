using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VidaYAtaque : MonoBehaviour
{
    [Header("VIDA Y DA�O")]
    [SerializeField] private int vida;
    [SerializeField] private int da�o;
    public int Vida { get => vida; set => vida = value; }
    public int Da�o { get => da�o; set => da�o = value; }

    [Header("OBJETIVO DE ATAQUE")]
    [SerializeField] protected string tagObjetivoDeAtaque;

    [Header("OTROS")]
    [SerializeField] protected Animator animator;


    //ATAQUE
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagObjetivoDeAtaque) && collision.gameObject.GetComponent<IRecibirDa�o>() != null)
            collision.gameObject.GetComponent<IRecibirDa�o>().TomarDa�o(da�o);
    }
}
