using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Jefe : Enemy
{
    public delegate void ActivarPantallaParaGanar();
    public static ActivarPantallaParaGanar activarPantallaParaGanar;


    protected override void RecibirDaño(float DañoRecibido)
    {
        if (vida == 0)
            activarPantallaParaGanar?.Invoke();
    }


    protected override void Movimiento()
    {
        base.Movimiento();
    }

    /*
    protected override void Disparar(Bullet balaPrefab, Transform posicionDeDisparo, Vector2 direccionDeDisparo)
    {
        base.Disparar(BalaPrefab, spawn, transform.up);
    }
    */
}
