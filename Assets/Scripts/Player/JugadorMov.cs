using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jugador
{
    public class JugadorMov : MovController, IRecibirDaño
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
        protected override void Movimiento()
        {
            float movimientohorizontal = Input.GetAxis("Horizontal");
            float movimientovertical = Input.GetAxis("Vertical");

            transform.Translate(Playermov * Time.deltaTime * velocidad, Space.World);


            // ANIMACION
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


        public void TomarDaño()
        {
            vida -= daño /*Enemigo.daño*/; //CAMBIAR POR DAÑO DE ENEMIGO
            
            if (vida <= 0)
            {
                Debug.Log("MORISTE!!!!!!!!!!!!!!!");
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("Enemigo") /*|| collision.gameObject.CompareTag("BalaEnemiga")*/)
                TomarDaño();
        }
        #endregion
    }
}
