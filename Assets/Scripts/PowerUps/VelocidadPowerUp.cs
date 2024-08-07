using Jugador;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocidadPowerUp : PowerUp
{
    protected override void aplicar()
    {

        
        //aplicarpowerup2(jugador.GetComponent<JugadorMov>().velocidad, valorAgregado);

        
        if (efectoActivado == true)
            jugador.GetComponent<JugadorMov>().velocidad += valorAgregado;
        else
            jugador.GetComponent<JugadorMov>().velocidad -= valorAgregado;  
        
    }
}
