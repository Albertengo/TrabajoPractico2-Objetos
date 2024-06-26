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
        Atacar(da�o);
    }



    protected override void Movimiento()
    {
        // Las coordenadas del mouse ahora se ajustan a la c�mara
        Vector2 mouseWorldPoint = camara.ScreenToWorldPoint(Input.mousePosition);

        //Calcula la direcci�n desde la posici�n del jugador hasta el rat�n.
        Vector2 direction = mouseWorldPoint - (Vector2)transform.position;

        // apunta hacia el mouse
        transform.up = direction;
    }

    protected override void Atacar(float da�o)
    {
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
