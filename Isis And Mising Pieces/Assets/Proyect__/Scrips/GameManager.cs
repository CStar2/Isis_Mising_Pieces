using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class GameManager : MonoBehaviour
{
    // Instancia única del GameManager para acceder desde otros scripts
    public static GameManager instance;

    public int loadedSaveId;

    [Header("Initialization")]
    // Único personaje controlado por el jugador
    public StatusCharacter playerStatus;

    [Header("Menús Activos")]
    // Banderas para verificar qué menús están activos
    public bool cutSceneActive;
    public bool gameMenuOpen;
    public bool dialogActive;
    public bool fadingBetweenAreas;
    public bool shopActive;
    public bool battleActive;
    public bool saveMenuActive;
    public bool innActive;
    public bool itemMenu;
    public bool equipMenu;
    public bool statsMenu;
    public bool skillsMenu;
    public bool SaveData;
    [Header("Control del Jugador")]
    // Bandera para verificar si el jugador puede moverse
    public bool confirmCanMove;

    [Header("Inventario del Jugador")]
    // Lista de objetos en el inventario del jugador
    public List<Item> itemsInInventory;
    public List<Item> equipmentInInventory;

    [Header("Oro del Jugador")]
    // Cantidad de oro actual del jugador
    public int currentGold;

    [Header("Configuración de Dificultad")]
    public bool easy;
    public bool normal;
    public bool hard;

    [Header("Trucos")]
    public bool infiniteHP;
    public bool infiniteSP;
    public bool infiniteGold;
    public bool noEncounters;
    internal bool mobile;

    private void Awake()
    {
        // Asegura que solo haya una instancia de GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Evita que el GameManager se destruya al cambiar de escena
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
