using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuraZona : MonoBehaviour
{
    
    public float cooldownCura;
    float tiempoCura;
    private void Start()
    {
        tiempoCura = cooldownCura;
    }
    void OnTriggerStay2D(Collider2D objeto)
    {
        PlayerController jugador = objeto.GetComponent<PlayerController>();
        //comprobamos si un objeto toco el item y si la salud es menos que la maxima 
       
        if (objeto != null && tiempoCura < 0)
        {
            jugador.CambiarSalud(1);
            tiempoCura = cooldownCura;
        }
        tiempoCura = tiempoCura - Time.deltaTime;
    }
}
