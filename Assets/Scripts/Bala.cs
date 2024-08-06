using UnityEngine;

public class Bala : VidaYAtaque
{
    [Header("BALA")]
    [SerializeField] float velocidadDeProyectil;
    [SerializeField] string nombreDePersonaje;
    private Rigidbody2D _balaRB;
    private GameObject personaje;



    void Awake()
    {
        personaje = GameObject.Find(nombreDePersonaje);

        _balaRB = GetComponent<Rigidbody2D>();
    }


    public void LaunchBullet(Vector2 direction)
    {
        Daño = personaje.GetComponent<VidaYAtaque>().Daño;

        _balaRB.velocity = direction * velocidadDeProyectil;
        Destroy(gameObject, 3f);
    }


    private void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }
}
