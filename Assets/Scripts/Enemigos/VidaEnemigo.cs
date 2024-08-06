using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : VidaYAtaque, IRecibirDaño
{
    [Header("DROP ENEMIGO")]

    [SerializeField] protected GameObject[] recolectable;
    protected GameObject recolectableRandom;
    protected int numeroAleatorioRecolectable;



    public void TomarDaño(int daño)
    {
        Vida -= daño;

        if (Vida <= 0)
        {
            numeroAleatorioRecolectable = Random.Range(0, recolectable.Length);
            recolectableRandom = recolectable[numeroAleatorioRecolectable];

            Instantiate(recolectableRandom, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}