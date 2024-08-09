using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    public static event Action<int> Punto;

    [SerializeField] int ValorDePunto;

    [SerializeField] AudioSource audio;
    [SerializeField] ParticleSystem particulas;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            Punto?.Invoke(ValorDePunto);

            //audio.Play();
            particulas.Play();
            Destroy(gameObject, 0.3f);
        }
    }
}
