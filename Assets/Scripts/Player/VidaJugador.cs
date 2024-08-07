using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJugador : VidaYAtaque, IRecibirDa�o
{
    public GameManager gameManager;

    public void TomarDa�o(int da�o)
    {
        if (Vida > 0)
        {
            Vida -= da�o;
            gameManager.CambiarCorazon(Vida);


            //Animacion de recibir da�o
        }
        else
        {
            //gameManager.CambiarEscena(3);
            Debug.Log("MORISTE!!!!!!!!!!!!!!!"); // ACTIVAR PANTALLA DE DERROTA
        }
    }
}
