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
                animator.SetTrigger("RecibiendoDa�o");
            }
        }
        else
            gameManager.CambiarEscena(4);
    }


    IEnumerator Inmunidad()
    {
        puedeRecibirDa�o = false;

        yield return new WaitForSeconds(2);

        puedeRecibirDa�o = true;
    }
}
