using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public abstract class Disparo : MonoBehaviour

{
    [Header("SPAWN DE BALAS")]
    [SerializeField] protected Bala BalaPrefab;
    [SerializeField] protected Transform spawn;

     
    protected virtual void Disparar(Bala balaPrefab, Transform posicionDeDisparo, Vector2 direccionDeDisparo)
    {
        Bala projectile = Instantiate(balaPrefab, posicionDeDisparo.position, transform.rotation);
        projectile.LaunchBullet(direccionDeDisparo);
    }
}
