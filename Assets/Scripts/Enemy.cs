using Jugador;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovController
{
    protected JugadorMov Jugador;


    protected override void Atacar(int daño)
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
        if (collision.gameObject.CompareTag("Jugador")) // cambiar para que pierda vida cuando colisiona con las hachas del jugador
        {
            RecibirDaño(Jugador.daño);
            Atacar(daño);
        }
    }
}
