using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jefe : Enemy
{
    public delegate void ActivarPantallaParaGanar();
    public static ActivarPantallaParaGanar activarPantallaParaGanar;



    void Start()
    {
        Atacar(4);
    }

    private void Update()
    {
        if (Health == 0)
            activarPantallaParaGanar?.Invoke();
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
}
