using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    public GameManager actualizarPuntaje;
    [SerializeField] int cantidadDePuntos;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jugador"))
        {
            actualizarPuntaje.actualizarPuntos(cantidadDePuntos);
            Destroy(gameObject);
        }
    }
}
