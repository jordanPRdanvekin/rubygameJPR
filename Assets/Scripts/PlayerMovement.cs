using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction Hablar;
    public GameObject preBala;
    Animator animaJugador;
    Vector2 animaVector = new Vector2(1, 0);
    //variables invencibilidad
    public float tiempoinv = 2.0f;
    bool esInvencible;
    float damaCooldown;
    //variables de salud
    public int vidamax = 5;
    int vidact;
    public int salud { get { return vidact; } }
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
        Hablar.Enable();
        animaJugador = GetComponent<Animator>();
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
        if (Hablar.triggered)
        {
            Conversar();
        }
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            animaVector.Set(move.x, move.y);
            animaVector.Normalize();
        }
        //mandas valores al animator para que ejecute la accion correspondiente al movimiento vertical(y) u horizontal(x), y la velocidad
        animaJugador.SetFloat("Look X", move.x);
        animaJugador.SetFloat("Look Y", move.y);
        animaJugador.SetFloat("Speed", move.magnitude);

        // Imprime los valores del movimiento en la consola para depuración.
        //Debug.Log(move);
        // cuando el personaje es invencible empieza el cooldown para dejar de serlo 
        if (esInvencible)
        {
            damaCooldown = damaCooldown - Time.deltaTime;
            if (damaCooldown < 0)
            {
                esInvencible = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Disparo();
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
            animaJugador.SetTrigger("Hit");
        }

        //con esta linea actualizamos la salud. clamp sirve para mantener la cantidad entre un valor minimo(0) y maximo(vidamax)
        vidact = Mathf.Clamp(vidact + amount, 0, vidamax);
        ContenedorVida.instancia.SetHealthValue(vidact / (float)vidamax);
        //devuelve en la consola el valor
        Debug.Log(vidact + "/" + vidamax);

    }
    void Disparo()
    {
        GameObject bala = Instantiate(preBala, rb.position + Vector2.up * 0.5f, Quaternion.identity);
        BalaMovemen projectile = bala.GetComponent<BalaMovemen>();
        projectile.Disparo(animaVector, 300);
        animaJugador.SetTrigger("Launch");
    }
    void Conversar()
    {
        //el jugador ''busca'' a los npcs segun la posicion, hacia donde se esta moviendo, la distancia que hay, y la capa en la que esta 
        RaycastHit2D hit = Physics2D.Raycast(rb.position + Vector2.up * 0.2f, move, 1.5f, LayerMask.GetMask("NPC"));
        if (hit.collider != null)
        {
            ContenedorVida.instancia.Dialogando();
        }
    }
}

