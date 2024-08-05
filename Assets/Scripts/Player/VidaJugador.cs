using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJugador : VidaYAtaque, IRecibirDaño
{
    public GameManager gameManager;

    public void TomarDaño(int daño)
    {
        if (vida > 0)
        {
            vida -= daño;
            gameManager.CambiarCorazon(vida);
        }
        else
            Debug.Log("MORISTE!!!!!!!!!!!!!!!"); // ACTIVAR PANTALLA DE DERROTA
    }
}
