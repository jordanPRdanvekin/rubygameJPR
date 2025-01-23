using UnityEngine;

public class BalaMovemen : MonoBehaviour
{
    AudioSource sonido;
    public AudioClip colision;

    public float Rango = 100.0f;
    Rigidbody2D balarb;
    void Awake()
    {
        sonido = GetComponent<AudioSource>();
        balarb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (transform.position.magnitude > Rango)
        {
            sonido.PlayOneShot(colision);
            Destroy(gameObject);
        }
    }

    public void Disparo(Vector2 direccion, float fuerza)
    {
        balarb.AddForce(direccion * fuerza);
    }
    void OnTriggerEnter2D(Collider2D Victima)
    {
        EnemyMovement Enemy = Victima.GetComponent<EnemyMovement>();
        if (Enemy != null)
        {
            Enemy.arreglar();
        }
        Debug.Log("Haz disparado a " + Victima.gameObject + " !");
        sonido.PlayOneShot(colision);
        Destroy(gameObject);
    }
}
