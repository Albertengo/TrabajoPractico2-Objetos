using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJefe : Disparo
{
    public void DisparoBasico(Vector2 direccionDeDisparo)
    {
        if(puedeDisparar)
            StartCoroutine(TiempoParaDisparar(direccionDeDisparo));
    }
}
