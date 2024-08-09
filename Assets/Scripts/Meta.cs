using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta : MonoBehaviour
{
    [SerializeField] int numeroDeEscena;
    public GameManager gameManager;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
            gameManager.CambiarEscena(numeroDeEscena);
    }


}
