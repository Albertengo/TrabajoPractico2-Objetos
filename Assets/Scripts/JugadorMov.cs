using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jugador
{
    public class JugadorMov : MovController
    {
        #region Variables
        Vector2 Playermov;
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
            animator.SetFloat("X", Playermov.x);
            animator.SetFloat("Y", Playermov.y);
            animator.SetFloat("Speed", Playermov.sqrMagnitude);
        }


        protected override void Attack(int daño)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
