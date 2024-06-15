using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gallina : Enemy
{



    void Start()
    {
        Atacar(1);


    }


    protected override void Movimiento()
    {
        base.Movimiento();
        base.Patrullaje();
    }

    protected override void Atacar(float daño)
    {
        base.Atacar(daño);
    }
}
