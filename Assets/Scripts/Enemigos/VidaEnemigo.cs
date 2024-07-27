using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : VidaYAtaque, IRecibirDaño
{
    [Header("DROP ENEMIGO")]

    [SerializeField] protected GameObject recolectableRandom;
    [SerializeField] protected GameObject[] recolectable;
    [HideInInspector] protected int numeroAleatorioRecolectable;



    public void TomarDaño(float daño)
    {
        vida -= daño;

        if (vida <= 0)
        {
            numeroAleatorioRecolectable = Random.Range(0, recolectable.Length);
            recolectableRandom = recolectable[numeroAleatorioRecolectable];

            Instantiate(recolectableRandom, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}