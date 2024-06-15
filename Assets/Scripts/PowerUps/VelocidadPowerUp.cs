using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocidadPowerUp : PowerUp
{
    public override void aplicar()
    {
        //base.aplicarpowerup2(jugador.GetComponent<MovController>().velocidad);


        if (efectoActivado == true)
            jugador.GetComponent<MovController>().velocidad += valorAgregado;
        else
            jugador.GetComponent<MovController>().velocidad -= valorAgregado;  
    }
}
