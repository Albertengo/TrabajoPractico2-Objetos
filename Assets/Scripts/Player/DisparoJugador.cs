using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class DisparoJugador : MovController
{
    [Header("CAMARA")]
    [SerializeField] Camera cam;

    [Header("DISPARAR")]
    [SerializeField] bool disparo;



    private void Start()
    {
        disparo = true;
    }

    void Update()
    {
        Movimiento(spawn);
    }


    protected override void Movimiento(Transform pos)
    {
        // Las coordenadas del mouse ahora se ajustan a la c�mara
        Vector2 mouseWorldPoint = cam.ScreenToWorldPoint(Input.mousePosition);

        //Calcula la direcci�n desde la posici�n del jugador hasta el rat�n.
        Vector2 direction = mouseWorldPoint - (Vector2)transform.position;

        // apunta hacia el mouse
        transform.up = direction;


        if (Input.GetMouseButtonDown(0) && disparo == true)
            StartCoroutine(TiempoParaDisparar());

    }


    public virtual IEnumerator TiempoParaDisparar()
    {
        base.Disparar();
        disparo = false;

        yield return new WaitForSeconds(1);

        disparo = true;
    }

}
