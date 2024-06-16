using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocidadPowerUp : PowerUp
{
    protected override void aplicar()
    {

        
        base.aplicarpowerup2(jugador.GetComponent<MovController>().velocidad, valorAgregado, efectoActivado);

        /*
        if (efectoActivado == true)
            jugador.GetComponent<MovController>().velocidad += valorAgregado;
        else
            jugador.GetComponent<MovController>().velocidad -= valorAgregado;  
        */
    }
}
