using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class DisparoJugador : Disparo
{
    [Header("CAMARA")]
    [SerializeField] Camera camara;



    void Update()
    {
        DireccionDeDisparo();
        DispararJugador();
    }



    private void DireccionDeDisparo()
    {
        // Las coordenadas del mouse ahora se ajustan a la cámara
        Vector2 mouseWorldPoint = camara.ScreenToWorldPoint(Input.mousePosition);

        //Calcula la dirección desde la posición del jugador hasta el ratón.
        Vector2 direction = mouseWorldPoint - (Vector2)transform.position;

        // apunta hacia el mouse
        transform.up = direction;
    }

    private void DispararJugador()
    {
        if (Input.GetMouseButtonDown(0) && puedeDisparar == true)
            StartCoroutine(base.TiempoParaDisparar(transform.up));
    }
}
