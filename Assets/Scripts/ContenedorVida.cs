using UnityEngine;
using UnityEngine.UIElements;

public class ContenedorVida : MonoBehaviour
{
    //creamos una nueva instancia del script la cual puede ser utilizada por otros scripts para obtener datos pero no para grabar 
    public static ContenedorVida instancia { get; private set; }
    VisualElement M_vidabarra;
    //awake es llamado cuando se crea el script antes de que empieze por eso es antes del start (cuando despierta el script)
    void Awake()
    {
        //el script se transforma en un objeto independiente (este objeto)
        instancia = this;
    }
    // Start is called before the first frame update (cuando se inicia el script)
    void Start()
    {
        //metemos la interfaz en una variable y tomamos el elemento visual de la interfaz llamado ''vida'' 
        UIDocument document = GetComponent<UIDocument>();
        M_vidabarra = document.rootVisualElement.Q<VisualElement>("vida");
        SetHealthValue(1.0f);
    }
    public void SetHealthValue(float value)
    {
        M_vidabarra.style.width = Length.Percent(value * 100.0f);
    }
}
