using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJugador : VidaYAtaque, IRecibirDaño
{
    public GameManager gameManager;
    private bool puedeRecibirDaño = true;


    public void TomarDaño(int daño)
    {
        if (Vida > 0)
        {
           if (puedeRecibirDaño) 
           {
                Vida -= daño;
                StartCoroutine(Inmunidad());
                gameManager.CambiarCorazon(Vida);
           }
        }
        else
        {
            //gameManager.CambiarEscena(3);
            Debug.Log("MORISTE!!!!!!!!!!!!!!!"); // ACTIVAR PANTALLA DE DERROTA
        }
    }

    IEnumerator Inmunidad()
    {
        puedeRecibirDaño = false;

        yield return new WaitForSeconds(2);

        puedeRecibirDaño = true;
    }
}
