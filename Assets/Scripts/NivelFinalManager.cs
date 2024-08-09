using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NivelFinalManager : MonoBehaviour
{
    [SerializeField] GameObject jefe;
    public GameManager gameManager;


    void Update()
    {
        if (jefe == null)
            gameManager.CambiarEscena(0);
    }
}
