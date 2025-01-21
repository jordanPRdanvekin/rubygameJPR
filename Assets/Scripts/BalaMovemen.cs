using UnityEngine;

public class BalaMovemen : MonoBehaviour
{
    Rigidbody2D balarb;
    void Awake()
    {
        balarb = GetComponent<Rigidbody2D>();
    }

    public void Disparo(Vector2 direccion, float fuerza)
    {
        balarb.AddForce(direccion * fuerza);
    }
    void OnTriggerEnter2D(Collider2D Victima)
    {
        Debug.Log("Haz disparado a " + Victima.gameObject + " !");
        Destroy(gameObject);
    }
}
