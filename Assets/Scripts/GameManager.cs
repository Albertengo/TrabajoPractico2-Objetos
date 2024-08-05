using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI puntajeTexto;
    int cantidadDePuntos;

    [SerializeField] private List<GameObject> corazones = new List<GameObject>();
    [SerializeField] private Sprite corazonDesactivado;



    public void CambiarCorazon(int indice)
    {
        Image imagenCorazon = corazones[indice].GetComponent<Image>();
        imagenCorazon.sprite = corazonDesactivado;
    }


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
       // Jefe.activarPantallaParaGanar += Ganar;
    }

    private void OnDisable()
    {
        Coleccionable.Punto -= ActualizarPuntaje;
       // Jefe.activarPantallaParaGanar -= Ganar;
    }
}
