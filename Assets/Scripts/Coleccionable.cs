using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    public static event Action<int> Punto;

    [SerializeField] int ValorDePunto;
    [SerializeField] AudioSource audio;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            Punto?.Invoke(ValorDePunto);

            //audio.Play();
            Destroy(gameObject, 0.3f);
        }
    }
}
