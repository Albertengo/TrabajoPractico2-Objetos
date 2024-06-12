using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jefe : Enemy
{
    void Start()
    {
        Atacar(4);
    }


    protected override void Movimiento(/*Transform pos*/)
    {
        base.Movimiento(/*pos*/);
        base.Perseguir();
    }

    protected override void Disparar()
    {
        base.Disparar();
    }

    protected override void Atacar(int daño)
    {
        base.Atacar(daño);
    }



    void ganar()
    {
        if (Health <= 0) 
        {
            Debug.Log("GANASTEEEEEE!!!!!!");
        }
    }

}
