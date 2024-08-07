using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJefe : Disparo
{
    //private int tipoDeDisparo;

    
    public void DisparoBasico(Vector2 direccionDeDisparo)
    {
        if(puedeDisparar)
            StartCoroutine(TiempoParaDisparar(direccionDeDisparo));
    }

    /*
    private void DisparoDoble()
    {
        //por cada punto de spawn  dentro de un arreglo, ejecutar un disparo
    }


    private void CambiarDisparo()
    {
        if (puedeDisparar)
        {
            //Vector2 direccionDeDisparo = jugador.position - transform.position;

            switch (tipoDeDisparo)
            {
                case 0:
                    {
                        //DisparoBasico(direccionDeDisparo);
                        tipoDeDisparo = 1;
                    }
                    break;

                case 1:
                    {
                        DisparoDoble();
                        tipoDeDisparo = 0;
                    }
                    break;
            }
        }

    }
    */
}
