using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottonReset : MonoBehaviour
{
    
    public void Start()
    {

    }
    public void Reinicio()
    {
        Time.timeScale = 1;
        //es una funcion que me permite reiniciar la escena activa desde 0 reejecutandola
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Cerrar()
    {
        Application.Quit();
    }

}
