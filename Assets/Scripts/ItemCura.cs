using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCura : MonoBehaviour
{
    public int cantidad;
    void OnTriggerEnter2D(Collider2D objeto)
    {
        PlayerController jugador = objeto.GetComponent<PlayerController>();
        //comprobamos si un objeto toco el item y si la salud es menos que la maxima 
        if (objeto != null && jugador.salud < jugador.vidamax) 
         {
            Debug.Log("fui tocado por " + objeto + " D:");
            jugador.CambiarSalud(cantidad);
            Destroy(gameObject);
        }
         }
}
