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

    private void OnEnable()
    {
        Coleccionable.Punto += ActualizarPuntaje;
    }

    private void OnDisable()
    {
        Coleccionable.Punto -= ActualizarPuntaje;
    }
}
