using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocidadPowerUp : PowerUp
{
    public override void aplicar()
    {
        if (efectoActivado == true)
            jugador.GetComponent<MovController>().velocidad += valorAgregado;
        else
        {
            jugador.GetComponent<MovController>().velocidad -= valorAgregado;
            //Debug.Log("PowerUp cancelado");
        }
            
    }

}
