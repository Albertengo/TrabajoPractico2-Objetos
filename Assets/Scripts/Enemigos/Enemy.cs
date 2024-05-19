using Jugador;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovController
{
    protected JugadorMov Jugador;


    protected override void Atacar(int da�o)
    {
        //ataca cuando el jugador se acerca demasiado
        //ataque x colision (default)
        Jugador.Health = Jugador.Health - da�o;

        Debug.Log(da�o);
    }


    protected override void Movimiento(Transform pos)
    {
        //Patrullaje
    }


    protected virtual void Perseguir()
    {
        // L�gica para seguir al jugador
    }


    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador")) // cambiar para que pierda vida cuando colisiona con las hachas del jugador
        {
            RecibirDa�o(Jugador.da�o);
            Atacar(da�o);
        }
    }
}
