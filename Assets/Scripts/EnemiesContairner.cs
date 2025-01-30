using UnityEngine;
using TMPro;

public class EnemiesContairner : MonoBehaviour
{
    [SerializeField]
    int EnemigosRestantes = 0;
    [SerializeField]
    int EnemigosTotal = 0;
    [SerializeField]
    string Contador;
    [SerializeField]
    TextMeshProUGUI contador;
    public static EnemiesContairner instanciaEnem { get; private set; }
    private void Awake()
    {
        instanciaEnem = this;
        EnemigosRestantes = EnemigosTotal;
    } 

    /// <summary>
    /// dos funciones una que suma y una que resta dichas funcciones se llamaran cuando se detecte cambios en los enemigos 
    /// uno suma en total ya que es el contador de cuantos enemigos hay
    /// el otro resta en restantes ya que cuenta cuantos quedan sin ''eliminar''
    /// Es importante que los enemigos restantes se actualize y sume tambien
    /// </summary>
    public void AddEnemie()
    {
        EnemigosTotal += 1;
        EnemigosRestantes += 1;
        Debug.Log("hay " + EnemigosRestantes + " de " + EnemigosTotal);
        //el toString convierte numeros en texto (String) la variable de letras. 
        contador.text = EnemigosRestantes.ToString() + "/" + EnemigosTotal.ToString();

    }
    public void RemoveEnemie()
    {
        EnemigosRestantes -= 1;
        Debug.Log("hay " + EnemigosRestantes + " de " + EnemigosTotal);
        //el toString convierte numeros en texto (String) la variable de letras. 
        contador.text = EnemigosRestantes.ToString() + "/" + EnemigosTotal.ToString();

    }
}
