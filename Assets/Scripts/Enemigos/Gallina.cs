using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gallina : Enemy
{
    void Start()
    {
        Atacar(1);
    }

    protected override void Movimiento(Transform pos)
    {
        base.Movimiento(pos);
        base.Perseguir();
    }


    protected override void Atacar(int daño)
    {
        base.Atacar(daño);
    }
}
