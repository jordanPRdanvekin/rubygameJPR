using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // InputAction que captura el movimiento del jugador mediante el nuevo sistema de entrada de Unity.
    public InputAction MoveAction;

    // Variable pública para ajustar la velocidad del movimiento desde el inspector de Unity.
    public float movementSpeed = 0.05f;

    // Start es llamado antes del primer frame del juego.
    void Start()
    {
        // Habilita la acción de movimiento para que pueda ser utilizada.
        MoveAction.Enable();
    }

    // Update es llamado una vez por frame.
    void Update()
    {
        // Obtiene el valor de movimiento del InputAction en formato Vector2.
        Vector2 move = MoveAction.ReadValue<Vector2>();

        // Imprime los valores del movimiento en la consola para depuración.
        Debug.Log(move);

        // Calcula la nueva posición sumando el movimiento escalado por la velocidad.
        Vector2 position = (Vector2)transform.position + move * movementSpeed * Time.deltaTime;

        // Actualiza la posición del transform del objeto en la escena.
        transform.position = position;
    }
}

