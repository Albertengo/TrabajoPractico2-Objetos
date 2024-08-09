using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] protected float duracionDeEfecto;
    [SerializeField] protected GameObject jugador;
    [SerializeField] protected int valorAgregado;
    [SerializeField] public bool efectoActivado;

    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected Collider2D collider;

    [SerializeField] public ParticleSystem particulas;
    [SerializeField] AudioSource audio;


    protected void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Jugador");
        efectoActivado = true;
    }


    protected abstract void aplicar();


    protected IEnumerator DuracionDePowerUp()
    {
        efectoActivado = true;
        aplicar();

        yield return new WaitForSeconds(duracionDeEfecto);

       efectoActivado = false;
       aplicar();

       Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jugador"))
        {
            collider.enabled = false;
            spriteRenderer.enabled = false;

            particulas.Play();
            audio.Play();

            StartCoroutine("DuracionDePowerUp");
        }
    }
}
    




