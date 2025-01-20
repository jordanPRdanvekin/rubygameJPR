using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float VelEnemy = 0.5f;
    Rigidbody2D enemyBody;
    bool verticalEnem;
    public float tiempoCambio = 3.0f;
    float temporizador;
    int direccion = 1;
    // Start is called before the first frame update
    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        temporizador = tiempoCambio;
    }
    void Update()
    {
        //esto es =  a poner temporizador = temporizador - time.deltaTime (basicamente ejecuta la operacion del simbolo sobre si mismo ( *, +, -, / ) 
        temporizador -= Time.deltaTime;
        if (temporizador < 0)
        {
            direccion = -direccion;
            temporizador = tiempoCambio;
        }
    }
    void FixedUpdate()
    {
        Vector2 position = enemyBody.position;
        if (verticalEnem)
        {
            position.y = position.y + VelEnemy * direccion * Time.deltaTime;
        }
        else
        {
            position.x = position.x + VelEnemy * direccion * Time.deltaTime;
        }
        enemyBody.MovePosition(position);
    }
    void OnTriggerEnter2D(Collider2D Otros)
    {
        PlayerController jugador = Otros.GetComponent<PlayerController>();
        if (jugador != null)
        {
            jugador.CambiarSalud(-1);
        }

    }
}
