using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoPowerUp : PowerUp
{
    protected override void aplicar()
    {
        //aplicarpowerup2(jugador.GetComponent<VidaJugador>().Daño, valorAgregado);

        
        if (efectoActivado == true)
            jugador.GetComponent<VidaJugador>().Daño += valorAgregado;
        else
            jugador.GetComponent<VidaJugador>().Daño -= valorAgregado;
        
    }
}
