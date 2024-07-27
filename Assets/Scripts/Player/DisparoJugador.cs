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
        // Las coordenadas del mouse ahora se ajustan a la c�mara
        Vector2 mouseWorldPoint = camara.ScreenToWorldPoint(Input.mousePosition);

        //Calcula la direcci�n desde la posici�n del jugador hasta el rat�n.
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
