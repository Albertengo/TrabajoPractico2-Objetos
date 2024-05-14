using Jugador;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovController
{
    protected JugadorMov Jugador;
    protected override void Attack(int daño)
    {
        //ataque x colision (default)
        Jugador.Health = Jugador.Health - daño;
        
        //BOSS: + tirar zanahorias
        //disparos();
    }
    //void disparos() { }
    protected override void Movimiento(Transform pos)
    {
        //patrullaje
        throw new System.NotImplementedException();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            RecibirDaño(Jugador.daño); //cambiar desp en base a lo q pongamos en el ataque del jugador
            Attack(daño);
        }
    }
}
