using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jugador
{
    public class JugadorMov : MovController
    {
        #region Variables
        Vector2 Playermov;
        protected Enemy Enemigo;
        #endregion


        #region funciones basicas
        void Update()
        {
            Movimiento();
        }
        #endregion


        #region code
        protected override void Movimiento()
        {
            float movimientohorizontal = Input.GetAxis("Horizontal");
            float movimientovertical = Input.GetAxis("Vertical");

            Playermov = new Vector2(movimientohorizontal, movimientovertical).normalized;

            transform.Translate(Playermov * Time.deltaTime * velocidad, Space.World);
            

            // ANIMACION

            if (Playermov.x != 0 || Playermov.y != 0)
            {
                animator.SetFloat("X", Playermov.x);
                animator.SetFloat("Y", Playermov.y);
                animator.SetBool("IsWalking", true);
            }
            else
                animator.SetBool("IsWalking", false);
        }
        #endregion
    }
}
