using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] protected GameObject jugador;
    [SerializeField] protected float valorAgregado;
    [SerializeField] public bool efectoActivado;

    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected Collider2D collider;

    [SerializeField] public ParticleSystem particulas;
    [SerializeField] AudioSource audio;


    protected void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Jugador");
    }


    protected abstract void aplicar();

    
    protected virtual void aplicarpowerup2(float atributo, float ValorAgregado, bool estadoDeEfecto)
    {
        if (estadoDeEfecto == true)
            atributo += ValorAgregado;
        else
            atributo -= ValorAgregado;
    }
    

    protected IEnumerator temporizadorPowerUp()
    {
        efectoActivado = true;
        aplicar();

        yield return new WaitForSeconds(2);

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

            StartCoroutine("temporizadorPowerUp");
        }
    }
}
    




