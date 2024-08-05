using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VidaYAtaque : MonoBehaviour
{
    //Get Y set
    [SerializeField] public int vida;
    [SerializeField] public int daño;

    [Header("OBJETIVO DE ATAQUE")]
    [SerializeField] protected string tagObjetivoDeAtaque;



    //ATAQUE
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagObjetivoDeAtaque))
            collision.gameObject.GetComponent<IRecibirDaño>().TomarDaño(daño);
    }
}
