using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI puntaje;
    int puntos;


    public void actualizarPuntos(int puntosGanados)
    {
        puntos = puntos + puntosGanados;

        puntaje.text = puntos.ToString();

    }

    public void CambiarEscena(int escena)
    {
        SceneManager.LoadScene(escena);
    }
}
