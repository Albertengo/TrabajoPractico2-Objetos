using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJugador : VidaYAtaque, IRecibirDa�o
{
    public GameManager gameManager;

    public void TomarDa�o(int da�o)
    {
        if (vida > 0)
        {
            vida -= da�o;
            gameManager.CambiarCorazon(vida);
        }
        else
            Debug.Log("MORISTE!!!!!!!!!!!!!!!"); // ACTIVAR PANTALLA DE DERROTA
    }
}
