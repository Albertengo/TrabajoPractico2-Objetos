using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJugador : VidaYAtaque, IRecibirDa�o
{
    public GameManager gameManager;
    private bool puedeRecibirDa�o = true;


    public void TomarDa�o(int da�o)
    {
        if (Vida > 0)
        {
           if (puedeRecibirDa�o) 
           {
                Vida -= da�o;
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
        puedeRecibirDa�o = false;

        yield return new WaitForSeconds(2);

        puedeRecibirDa�o = true;
    }
}
