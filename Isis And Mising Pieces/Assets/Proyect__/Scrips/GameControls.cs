using UnityEngine;
using UnityEngine.UI;

public class GameControls : MonoBehaviour
{
    // Singleton: Permite acceder a esta clase desde otros scripts sin necesidad de instanciarlo varias veces
    public static GameControls instance;

    // Indica si el juego está en una plataforma móvil
    public bool mobile = false;
    internal Button closeButtonSave;

    void Awake()
    {
        // Implementación del patrón Singleton para evitar múltiples instancias
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // No destruir este objeto al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Si ya existe una instancia, eliminar la nueva
        }
    }
}

