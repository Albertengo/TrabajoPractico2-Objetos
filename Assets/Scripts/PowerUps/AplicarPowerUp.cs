using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AplicarPowerUp : MonoBehaviour
{
    //[SerializeField] ParticleSystem particulas;

    //[SerializeField] AudioSource audio;


    public PowerUp powerUp;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jugador"))
        {
            StartCoroutine("temporizadorPowerUp");

            //audio.Play();
            //particulas.Play();
            //Destroy(gameObject, 0.5f); //cuando el objeto se destruye deja de funcionar el temporizador
        }
    }


    protected IEnumerator temporizadorPowerUp()
    {
        powerUp.efectoActivado = true;
        powerUp.aplicar();

        yield return new WaitForSeconds(7);

        powerUp.efectoActivado = false;
        powerUp.aplicar();

        //particulas.Stop();
    }

}
