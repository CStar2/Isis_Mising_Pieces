using UnityEngine;
using UnityEngine.UI;
public class ScreenMovement : MonoBehaviour
{
    // Singleton: Permite acceder a este script desde otros sin necesidad de buscarlo en la escena.
    public static ScreenMovement instance;

    [Header("Configuraci�n de la Pantalla")]
    public GameObject screenObject; // Objeto de la UI que contiene la pantalla negra.
    public Image screenImage; // Imagen que se usa para oscurecer o aclarar la pantalla.

    [Header("Configuraci�n de Transici�n")]
    public float transitionSpeed; // Velocidad de la transici�n.

    [HideInInspector] public bool transitionToBlack; // Activa el fundido a negro.
    [HideInInspector] public bool transitionFromBlack; // Activa el fundido desde negro.
    [HideInInspector] public bool isTransitioning = false; // Indica si la transici�n est� en curso.
    internal readonly bool fading;

    private void Start()
    {
        // Se asegura de que solo haya una instancia de ScreenMovement en la escena.
        instance = this;

        // No destruye este objeto al cambiar de escena, para que el efecto de transici�n persista.
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        // Si la transici�n a negro est� activada, aumenta la opacidad de la imagen hasta 1.
        if (transitionToBlack)
        {
            screenImage.color = new Color(
                screenImage.color.r,
                screenImage.color.g,
                screenImage.color.b,
                Mathf.MoveTowards(screenImage.color.a, 1f, transitionSpeed * Time.deltaTime)
            );

            // Cuando la pantalla est� completamente negra, detiene la transici�n.
            if (screenImage.color.a == 1f)
            {
                transitionToBlack = false;
            }
        }

        // Si la transici�n desde negro est� activada, reduce la opacidad de la imagen hasta 0.
        if (transitionFromBlack)
        {
            screenImage.color = new Color(
                screenImage.color.r,
                screenImage.color.g,
                screenImage.color.b,
                Mathf.MoveTowards(screenImage.color.a, 0f, transitionSpeed * Time.deltaTime)
            );

            // Cuando la pantalla ya no est� negra, detiene la transici�n.
            if (screenImage.color.a == 0f)
            {
                transitionFromBlack = false;
            }
        }
    }

    // Activa el efecto de fundido a negro.
    public void TransitionToBlack()
    {
        transitionToBlack = true;
        transitionFromBlack = false;
        isTransitioning = true;
    }

    // Activa el efecto de fundido desde negro.
    public void TransitionFromBlack()
    {
        transitionToBlack = false;
        transitionFromBlack = true;
        isTransitioning = false;
    }
}
