using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gallina : Enemy
{
    protected override void Movimiento()
    {
        base.Movimiento();
        base.Patrullaje();
    }
}
