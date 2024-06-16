using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoPowerUp : PowerUp
{
    protected override void aplicar()
    {
        if (efectoActivado == true)
            jugador.GetComponent<MovController>().daño += valorAgregado;
        else
            jugador.GetComponent<MovController>().daño -= valorAgregado;
    }
}
