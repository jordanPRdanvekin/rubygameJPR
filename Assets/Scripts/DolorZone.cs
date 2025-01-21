using UnityEngine;

public class DolorZone : MonoBehaviour
{
    public int damage;
    void OnTriggerStay2D(Collider2D objeto)
    {
        PlayerController jugador = objeto.GetComponent<PlayerController>();
        //comprobamos si un objeto toco el item y si la salud es menos que la maxima 
        if (objeto != null)
        {
            jugador.CambiarSalud(-damage);
        }
    }
}
