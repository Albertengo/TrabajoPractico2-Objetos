using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI puntajeTexto;
    int cantidadDePuntos;


    public void CambiarEscena(int escena)
    {
        SceneManager.LoadScene(escena);
    }


    // EVENTOS //

    void ActualizarPuntaje(int ValorDePunto)
    {
        cantidadDePuntos += ValorDePunto;

        puntajeTexto.text = "Puntaje: " + cantidadDePuntos;
    }

    public void Ganar()
    {
       
    }


    private void OnEnable()
    {
        Coleccionable.Punto += ActualizarPuntaje;
        Jefe.activarPantallaParaGanar += Ganar;
    }

    private void OnDisable()
    {
        Coleccionable.Punto -= ActualizarPuntaje;
        Jefe.activarPantallaParaGanar -= Ganar;
    }
}
