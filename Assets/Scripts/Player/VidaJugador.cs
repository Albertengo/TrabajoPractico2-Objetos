using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJugador : VidaYAtaque, IRecibirDa�o
{
    public void TomarDa�o(float da�o)
    {
        Debug.Log("Da�o recibido: " + da�o);

        vida -= da�o;

        if (vida <= 0)
        {
            Debug.Log("MORISTE!!!!!!!!!!!!!!!"); // ACTIVAR PANTALLA DE DERROTA
        }
    }
}
