using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class ContenedorVida : MonoBehaviour
{
    public float tiempo = 4.0f;
    private VisualElement Dialogo;
    private float TiempoMuestra;
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
        //abrimos (la interfaz) el documento ui y buscamos un componente llamado ''conversacion'' y lo almacenamos en dialogo
        Dialogo = document.rootVisualElement.Q<VisualElement>("Conversacion");
        //cambiamos el estilo de mostrar a mostrar nada(displayStyle.none;)
        Dialogo.style.display = DisplayStyle.None;
        TiempoMuestra = -1.0f;
    }
    public void Update()
    {
        if(TiempoMuestra > 0)
        {
            TiempoMuestra -= Time.deltaTime;
            if (TiempoMuestra < 0)
            {

                Dialogo.style.display = DisplayStyle.None;
            }
        }

    }
    public void Dialogando()
    {
        Dialogo.style.display = DisplayStyle.Flex;
        TiempoMuestra = tiempo;
    }
    
    public void SetHealthValue(float value)
    {
        M_vidabarra.style.width = Length.Percent(value * 100.0f);
    }
}
