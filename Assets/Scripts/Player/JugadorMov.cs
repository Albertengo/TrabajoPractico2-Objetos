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
            Movimiento(pos);
        }
        #endregion


        #region code
        protected override void Movimiento(Transform pos)
        {
            float movimientohorizontal = Input.GetAxis("Horizontal");
            float movimientovertical = Input.GetAxis("Vertical");
            pos.Translate(Playermov * Time.deltaTime * velocidad);


            //animacion
            Playermov = new Vector2(movimientohorizontal, movimientovertical).normalized;
            if (Playermov.x != 0 || Playermov.y != 0)
            {
                animator.SetFloat("X", Playermov.x);
                animator.SetFloat("Y", Playermov.y);
                animator.SetFloat("Speed", Playermov.sqrMagnitude);
                animator.SetBool("IsWalking", true);
            }
            else
                animator.SetBool("IsWalking", false);
        }



        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Jugador"))
            {
                RecibirDaño(Enemigo.daño);

                if (Health < 0)
                {
                    Debug.Log("MORISTE!!!!!!!!!!!!!!!");
                }
            }
        }
        #endregion
    }
}
