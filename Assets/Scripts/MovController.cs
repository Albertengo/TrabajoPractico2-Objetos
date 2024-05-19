using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public abstract class MovController : MonoBehaviour
{
    [Header("Lógica")]
    [SerializeField] public int Health;
    [SerializeField] public float velocidad;
    [SerializeField] public int daño;

    [Header("SPAWN DE BALAS")]
    [SerializeField] protected Bullet BalaPrefab;
    [SerializeField] protected Transform spawn;
    [SerializeField] public int cantidadDeBalas = 0;
    //[SerializeField] protected float fireRate;
    //[SerializeField] protected float timeToFire;

    [Header("Referencias")]
    [SerializeField] protected Animator animator;
    [SerializeField] protected Transform pos;
    


    protected abstract void Movimiento(Transform pos);


    protected virtual void Atacar(int daño)
    {

    }


    protected virtual void Disparar()
    {
        Bullet projectile = Instantiate(BalaPrefab, spawn.position, transform.rotation);
        projectile.LaunchBullet(transform.up);
    }

 
    protected virtual void RecibirDaño(int DañoRecibido)
    {
        Health -= DañoRecibido;
       
    } 
}
