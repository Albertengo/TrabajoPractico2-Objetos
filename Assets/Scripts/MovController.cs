using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public abstract class MovController : MonoBehaviour

{
    [Header("Lógica")] //aplicar get y set
    [SerializeField] public float vida;
    [SerializeField] public float velocidad;
    [SerializeField] public float daño;

    [Header("SPAWN DE BALAS")]
    [SerializeField] protected Bala BalaPrefab;
    [SerializeField] protected Transform spawn;


    [Header("Referencias")]
    [SerializeField] protected Animator animator;
    


    protected abstract void Movimiento();

    protected virtual void Atacar(float daño) { }

    protected virtual void Disparar(Bala balaPrefab, Transform posicionDeDisparo, Vector2 direccionDeDisparo)
    {
        Bala projectile = Instantiate(balaPrefab, posicionDeDisparo.position, transform.rotation);
        projectile.LaunchBullet(direccionDeDisparo); //transform.up
    }

    protected virtual void RecibirDaño(float DañoRecibido)
    {
        vida -= daño;
    }
}
