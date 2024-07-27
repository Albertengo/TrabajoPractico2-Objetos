using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class DisparoJugador : Disparo
{
    [Header("CAMARA")]
    [SerializeField] Camera camara;

    [Header("DISPARAR")]
    [SerializeField] bool puedeDisparar;



    private void Start()
    {
        puedeDisparar = true;
    }

    void Update()
    {
        DireccionDeDisparo();
        Disparar();
    }


    //direccion de disparo en base al mouse
    private void DireccionDeDisparo()
    {
        // Las coordenadas del mouse ahora se ajustan a la cámara
        Vector2 mouseWorldPoint = camara.ScreenToWorldPoint(Input.mousePosition);

        //Calcula la dirección desde la posición del jugador hasta el ratón.
        Vector2 direction = mouseWorldPoint - (Vector2)transform.position;

        // apunta hacia el mouse
        transform.up = direction;
    }

    private void Disparar()
    {
        if (Input.GetMouseButtonDown(0) && puedeDisparar == true)
            StartCoroutine(TiempoParaDisparar());
    }

    public virtual IEnumerator TiempoParaDisparar()
    {
        base.Disparar(BalaPrefab, spawn, transform.up);
        puedeDisparar = false;

        yield return new WaitForSeconds(1);

        puedeDisparar = true;
    }
}
