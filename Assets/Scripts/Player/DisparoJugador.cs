using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class DisparoJugador : MovController
{
    [Header("CAMARA")]
    [SerializeField] Camera camara;

    [Header("DISPARAR")]
    [SerializeField] bool disparo;



    private void Start()
    {
        disparo = true;
    }

    void Update()
    {
        Movimiento();
    }


    protected override void Movimiento()
    {
        // Las coordenadas del mouse ahora se ajustan a la cámara
        Vector2 mouseWorldPoint = camara.ScreenToWorldPoint(Input.mousePosition);

        //Calcula la dirección desde la posición del jugador hasta el ratón.
        Vector2 direction = mouseWorldPoint - (Vector2)transform.position;

        // apunta hacia el mouse
        transform.up = direction;


        if (Input.GetMouseButtonDown(0) && disparo == true)
            StartCoroutine(TiempoParaDisparar());

    }


    public virtual IEnumerator TiempoParaDisparar()
    {
        base.Disparar(BalaPrefab, spawn, transform.up);
        disparo = false;

        yield return new WaitForSeconds(1);

        disparo = true;
    }

}
