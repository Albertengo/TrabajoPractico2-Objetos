using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJugador : VidaYAtaque, IRecibirDaño
{
    public void TomarDaño(float daño)
    {
        Debug.Log("Daño recibido: " + daño);

        vida -= daño;

        if (vida <= 0)
        {
            Debug.Log("MORISTE!!!!!!!!!!!!!!!"); // ACTIVAR PANTALLA DE DERROTA
        }
    }
}
