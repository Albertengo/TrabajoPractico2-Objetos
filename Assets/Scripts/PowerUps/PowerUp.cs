using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] public GameObject jugador;
    [SerializeField] protected int valorAgregado;
    [SerializeField] public bool efectoActivado;
 

    public abstract void aplicar();

}
