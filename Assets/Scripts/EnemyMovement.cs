using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public ParticleSystem humo;

    AudioSource sonido;
    public AudioClip arreglado;
    bool roto = true;
    Animator eneminacion;
    public float VelEnemy = 0.5f;
    Rigidbody2D enemyBody;
    bool verticalEnem;
    public float tiempoCambio = 3.0f;
    float temporizador;
    int direccion = 1;

    void Start()
    { //la logica es que por cada enemigo se ejecute el contador addenemy por lo que lo logico seria que se ejecute una unica ves por enemigo
        EnemiesContairner.instanciaEnem.AddEnemie();
        sonido = GetComponent<AudioSource>();
        eneminacion = GetComponent<Animator>();
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
        //comprobamos si no esta roto(!roto), si no lo esta saldremos de este script evitando que se mueva el enemigo
        if (!roto)
        {
            return;
        }
        // si esta roto (sin la !) continua el script haciendo en este caso que se mueva el enemigo
        Vector2 position = enemyBody.position;
        if (verticalEnem)
        {
            position.y = position.y + VelEnemy * direccion * Time.deltaTime;
            eneminacion.SetFloat("moveX", 0);
            eneminacion.SetFloat("moveY", direccion);
        }
        else
        {
            position.x = position.x + VelEnemy * direccion * Time.deltaTime;
            eneminacion.SetFloat("moveX", direccion);
            eneminacion.SetFloat("moveY", 0);
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
    public void arreglar()
    {
        //repara el enemigo y lo hace ''atrabesable'' ya que ya no es enemigo 
        roto = false;
        enemyBody.simulated = false;
        eneminacion.SetTrigger("arreglado");
        sonido.Stop();
        sonido.PlayOneShot(arreglado);
        humo.Stop();
        EnemiesContairner.instanciaEnem.RemoveEnemie();
    }
}
