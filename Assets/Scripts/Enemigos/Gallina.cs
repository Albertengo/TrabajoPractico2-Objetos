using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gallina : Enemy
{
    void Start()
    {
        Atacar(1);
    }
    

    protected override void Atacar(int daño)
    {
        base.Atacar(daño);
    }
}
