using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJugador : VidaYAtaque, IRecibirDaño
{
    public GameManager gameManager;

    public void TomarDaño(int daño)
    {
        if (Vida > 0)
        {
            Vida -= daño;
            gameManager.CambiarCorazon(Vida);
            //Animacion de recibir daño
        }
        else
            Debug.Log("MORISTE!!!!!!!!!!!!!!!"); // ACTIVAR PANTALLA DE DERROTA
    }
}
