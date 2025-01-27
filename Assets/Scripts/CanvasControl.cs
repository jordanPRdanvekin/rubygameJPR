using UnityEngine;
using UnityEngine.InputSystem;


public class CanvasControl : MonoBehaviour
{
    public InputAction DesplegarMenu;
    public GameObject cavas;
    bool menuactivo = false;
    public float duracion = 5f;
    public AudioClip activo;
    AudioSource altavoz;
    // Start is called before the first frame update
    void Start()
    {
        altavoz = GetComponent<AudioSource>();
        DesplegarMenu.Enable();
        cavas.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //primero mirar si se a pulsado el boton de abrir menu y luego ve si esta abierto o no para abrir o cerrar 
        if (DesplegarMenu.triggered)
        {
            if (menuactivo == false)
            {

                menuactivo = true;
                altavoz.PlayOneShot(activo);
                LeanTween.scale(cavas, new Vector3(1, 1, 1), duracion).setEase(LeanTweenType.easeInExpo).setOnComplete(() => { Time.timeScale = 0; });
            }
            else
            {
                Time.timeScale = 1;
                LeanTween.scale(cavas, new Vector3(0, 0, 0), duracion).setEase(LeanTweenType.easeInExpo);
                menuactivo = false;
                altavoz.PlayOneShot(activo);
            }
        }

    }
}
