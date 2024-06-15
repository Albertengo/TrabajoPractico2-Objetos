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
            Movimiento(/*pos*/);
        }
        #endregion


        #region code
        protected override void Movimiento(/*Transform pos*/)
        {
            float movimientohorizontal = Input.GetAxis("Horizontal");
            float movimientovertical = Input.GetAxis("Vertical");
            transform.Translate(Playermov * Time.deltaTime * velocidad);


            //animacion
            Playermov = new Vector2(movimientohorizontal, movimientovertical).normalized;
            if (Playermov.x != 0 || Playermov.y != 0)
            {
                animator.SetFloat("X", Playermov.x);
                animator.SetFloat("Y", Playermov.y);
                animator.SetBool("IsWalking", true);
            }
            else
                animator.SetBool("IsWalking", false);
        }



        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("BalaEnemiga"))
            {
                RecibirDaño(Enemigo.daño);

                if (vida <= 0)
                {
                    Debug.Log("MORISTE!!!!!!!!!!!!!!!");
                }
            }
        }
        #endregion
    }
}
