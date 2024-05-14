using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AplicarPowerUp : MonoBehaviour
{
    [SerializeField] public ParticleSystem particulas;

    [SerializeField] AudioSource audio;


    public PowerUp powerUp;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jugador"))
        {
            StartCoroutine("temporizadorPowerUp");

            audio.Play();
            particulas.Play();
            Destroy(this.gameObject, 0.5f);
            //other.gameObject.SetActive(false);
        }
    }


    
    protected IEnumerator temporizadorPowerUp()
    {
        powerUp.efectoActivado = true;
        powerUp.aplicar();

        yield return new WaitForSeconds(2);

        powerUp.efectoActivado = false;
        powerUp.aplicar();

       particulas.Stop();
    }
    

}
