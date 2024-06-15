using UnityEngine;

public class Bala : MonoBehaviour
{
    private Rigidbody2D _balaRB;
    [SerializeField] float velocidadDeProyectil;


    void Awake()
    {
        _balaRB = GetComponent<Rigidbody2D>();
    }

    

    public void LaunchBullet(Vector2 direction)
    {
        _balaRB.velocity = direction * velocidadDeProyectil;

        Destroy(gameObject, 3f);
    }



    private void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }
}
