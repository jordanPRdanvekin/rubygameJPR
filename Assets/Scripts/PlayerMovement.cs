using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //variables invencibilidad
    public float tiempoinv = 2.0f;
    bool esInvencible;
    float damaCooldown;
    //variables de salud
    public int vidamax = 5;
    int vidact;
    public int salud { get{ return vidact;}}
    // creamos variable de movimiento
    Vector2 move;
    //creamos el ribidbody de ruby
    Rigidbody2D rb;
    // InputAction que captura el movimiento del jugador mediante el nuevo sistema de entrada de Unity.
    public InputAction MoveAction;
    // Variable pública para ajustar la velocidad del movimiento desde el inspector de Unity.
    public float movementSpeed = 0.05f;
    // Start es llamado antes del primer frame del juego.
    void Start()
    {
        //actualizamos la vida actual
        vidact = vidamax;
        //obtenemos el rigidbody
        rb = GetComponent<Rigidbody2D>();
        // Habilita la acción de movimiento para que pueda ser utilizada.
        MoveAction.Enable();
    }

    // para cosas que cambian pocas veces durante el juego
    void Update()
    {
        // Obtiene el valor de movimiento del InputAction en formato Vector2.
        move = MoveAction.ReadValue<Vector2>();
        // Imprime los valores del movimiento en la consola para depuración.
        //Debug.Log(move);
        // cuando el personaje es invencible empieza el cooldown para dejar de serlo 
        if (esInvencible)
        {
            damaCooldown = damaCooldown - Time.deltaTime;
            if(damaCooldown < 0)
            {
                esInvencible = false;
            }
        }


    }
    //para cosas que cambian continuamente durante el juego 
    void FixedUpdate()
    {
        // Calcula la nueva posición sumando el movimiento escalado por la velocidad.
        Vector2 position = (Vector2)rb.position + move * movementSpeed * Time.deltaTime;

        // Actualiza la posición del transform del objeto en la escena.
        rb.position = position;
    }
    public void CambiarSalud(int amount)
    {
        //si la cantidad recibida es negativa se trata de daño por lo tanto el personaje pasa a ser invencible durante un tiempo
        if (amount < 0)
        {
            if (esInvencible)
            { 
                return;
            }

            esInvencible = true;
            damaCooldown = tiempoinv;
        }
        //con esta linea actualizamos la salud. clamp sirve para mantener la cantidad entre un valor minimo(0) y maximo(vidamax)
        vidact = Mathf.Clamp(vidact + amount, 0, vidamax);
        ContenedorVida.instancia.SetHealthValue(vidact / (float)vidamax);
        //devuelve en la consola el valor
        Debug.Log(vidact + "/" + vidamax);

    }
}

