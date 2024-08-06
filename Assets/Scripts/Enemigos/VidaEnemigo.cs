using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : VidaYAtaque, IRecibirDa�o
{
    [Header("DROP ENEMIGO")]

    [SerializeField] protected GameObject[] recolectable;
    protected GameObject recolectableRandom;
    protected int numeroAleatorioRecolectable;



    public void TomarDa�o(int da�o)
    {
        Vida -= da�o;

        if (Vida <= 0)
        {
            numeroAleatorioRecolectable = Random.Range(0, recolectable.Length);
            recolectableRandom = recolectable[numeroAleatorioRecolectable];

            Instantiate(recolectableRandom, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}