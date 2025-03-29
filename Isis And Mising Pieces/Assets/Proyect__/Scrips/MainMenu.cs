using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class MainMenu : MonoBehaviour
{
    // Instancia estática para que otros scripts puedan acceder a este menú
    public static MainMenu instance;

    [Header("Inicialización")]
    // Variables para los componentes de UI que se usan en este menú
    public Text skillDescription;  // Descripción de la habilidad seleccionada
    public Image itemSprite;  // Imagen del item seleccionado
    public Image equipItemSprite;  // Imagen del equipo seleccionado
    public bool itemSelected;  // Indica si un ítem ha sido seleccionado
    public GameObject menu;  // El objeto del menú principal
    public GameObject gotItemMessage;  // Mensaje cuando el jugador obtiene un ítem
    public Text gotItemMessageText;  // Texto del mensaje de ítem obtenido
    public GameObject loadPrompt;  // Mensaje de carga
    public GameObject quitPrompt;  // Mensaje para confirmar salir
    public GameObject discardPrompt;  // Mensaje para confirmar descartar
    public Text discardItemText;  // Texto para descartar ítem
    public GameObject itemWindow;  // Ventana de ítems
    public GameObject skillsWindow;  // Ventana de habilidades
    public GameObject equipWindow;  // Ventana de equipo
    public GameObject statusWindow;  // Ventana de estado
    public List<StatusCharacter> playerStats;  // Lista de estadísticas del personaje principal
    public Text nameText, hpText, spText, lvlText, expText;  // Textos para mostrar estadísticas en las ventanas
    public Slider expSlider, HPSlider, SPSlider;  // Barras de progreso de experiencia, salud y energía
    public Image charImage;  // Imagen del personaje
    public GameObject skillCharacterSlot;  // Espacio para mostrar habilidades del personaje
    public Text nameTextSkill;  // Nombre del personaje en la ventana de habilidades
    public bool skillSelected;  // Indica si se ha seleccionado una habilidad
    public Button skillCharChoice;  // Botón para seleccionar el personaje que usa la habilidad
    public int selectedSkillPower;  // Poder de la habilidad seleccionada
    public int selectedSkillCost;  // Coste de la habilidad seleccionada
    public int selectedSkillChar;  // Índice del personaje que usa la habilidad
    public GameObject gold;  // Objeto para mostrar la cantidad de oro
    public Text goldText;  // Texto para mostrar la cantidad de oro
    public Button saveButton;  // Botón para guardar el progreso
    public Button quitButton;  // Botón para salir del juego
    private Item activeItem;

    // Evento para gestionar la interacción con la UI
    public EventSystem es;

    // Botones de interacción con el menú
    public Button item;  // Botón para acceder al inventario de ítems
    public Button equip;  // Botón para acceder al menú de equipamiento
    public Button skills;  // Botón para acceder a las habilidades
    public Button status;  // Botón para ver las estadísticas del personaje
    public Button load;  // Botón para cargar la partida
    public Button close;  // Botón para cerrar el menú
    public Button useItemButton;  // Botón para usar un ítem
    public Button discardItemButton;  // Botón para descartar un ítem
    public Button quitNo;  // Botón para no salir del juego

    // **Funciones principales**

    // Método para mostrar el menú principal
    public void ShowMenu()
    {
        menu.SetActive(true);  // Muestra el menú principal
        loadPrompt.SetActive(false);  // Oculta el mensaje de carga
        quitPrompt.SetActive(false);  // Oculta el mensaje de salida
    }

    // Método para ocultar el menú principal
    public void HideMenu()
    {
        menu.SetActive(false);  // Oculta el menú principal
    }

    // Método para mostrar la ventana de ítems
    public void ShowItemWindow()
    {
        itemWindow.SetActive(true);  // Muestra la ventana de ítems
        skillsWindow.SetActive(false);  // Oculta la ventana de habilidades
        equipWindow.SetActive(false);  // Oculta la ventana de equipamiento
    }

    // Método para mostrar la ventana de habilidades
    public void ShowSkillsWindow()
    {
        skillsWindow.SetActive(true);  // Muestra la ventana de habilidades
        itemWindow.SetActive(false);  // Oculta la ventana de ítems
        equipWindow.SetActive(false);  // Oculta la ventana de equipamiento
    }

    // Método para mostrar la ventana de equipo
    public void ShowEquipWindow()
    {
        equipWindow.SetActive(true);  // Muestra la ventana de equipamiento
        itemWindow.SetActive(false);  // Oculta la ventana de ítems
        skillsWindow.SetActive(false);  // Oculta la ventana de habilidades
    }

    // Método para usar un ítem
    public void UseItem(Item item)
    {
        // Aquí iría la lógica para usar el ítem
        // Por ejemplo, aumentar la salud, energía, o lo que el ítem haga
        Debug.Log("Usando ítem: " + item.name);
    }

    // Método para descartar un ítem
    public void DiscardItem(Item item)
    {
        // Lógica para descartar el ítem
        Debug.Log("Ítem descartado: " + item.name);
    }

    // Método para guardar el juego
    public void SaveGame()
    {
        // Aquí va la lógica para guardar la partida
        Debug.Log("Guardando partida...");
    }

    // Método para cargar la partida
    public void LoadGame()
    {
        // Lógica para cargar la partida
        Debug.Log("Cargando partida...");
    }

    // Método para salir del juego
    public void QuitGame()
    {
        // Aquí va la lógica para salir del juego
        Debug.Log("Saliendo del juego...");
        Application.Quit();  // Cierra la aplicación
    }

    // **Funciones para gestionar las interacciones de los botones**

    // Método que se ejecuta cuando se presiona el botón de usar ítem
    public void OnUseItemButtonPressed()
    {
        // Supongamos que se usa el primer ítem
        UseItem(activeItem);  // Llamamos a la función UseItem con el ítem activo
    }

    // Método que se ejecuta cuando se presiona el botón de descartar ítem
    public void OnDiscardItemButtonPressed()
    {
        // Supongamos que se descarta el primer ítem
        DiscardItem(activeItem);  // Llamamos a la función DiscardItem con el ítem activo
    }

    // Método que se ejecuta cuando se presiona el botón de salir
    public void OnQuitButtonPressed()
    {
        QuitGame();  // Llamamos a la función QuitGame para salir del juego
    }

    [Header("Item Selection")]
    public bool itemConfirmed = false;  // Indica si un ítem ha sido confirmado por el jugador
    public string selectedItem;  // Guarda el nombre del ítem seleccionado

    [Header("Linked Scenes")]
    public string mainMenuScene;  // Nombre de la escena del menú principal
    public string loadGameScene;  // Nombre de la escena de carga del juego

    [Header("Sound")]
    public int openMenuButtonSound;  // ID del sonido que se reproduce al abrir el menú
    public int cancelButtonSound;  // ID del sonido que se reproduce al cancelar

    public Button btn { get; private set; }

    // Use this for initialization
    void Start()
    {
        instance = this;  // Inicializa la instancia estática para poder acceder a esta clase desde otros scripts
    }

    // Update is called once per frame
    void Update()
    {

        // Abre el menú del juego si el jugador presiona el botón de menú (PC o Joypad)
        if (Input.GetButtonDown("RPGMenuPC") || Input.GetButtonDown("RPGMenuJoy"))
        {
            // Verifica si el menú se puede abrir (no se puede abrir durante un diálogo, batalla, etc.)
            if (ScreenMovement.instance.fading == false && !GameManager.instance.battleActive && !GameManager.instance.dialogActive && !GameManager.instance.shopActive && !GameManager.instance.innActive && !GameManager.instance.saveMenuActive && !GameManager.instance.cutSceneActive)
            {
                // Si el menú no está abierto, reproduce el sonido de abrir el menú
                if (!menu.activeInHierarchy)
                {
                    MusicIndi.instance.PlaySFX(openMenuButtonSound);
                }

                // Prevenimos que el botón resaltado vuelva a ser el botón por defecto cuando se presiona el botón de menú
                if (!menu.activeInHierarchy)
                {
                    btn = item;  // Establece el botón 'item' como el seleccionado
                    SelectFirstButton();  // Selecciona el primer botón del menú
                }

                menu.SetActive(true);  // Muestra el menú
                UpdateMainStats();  // Actualiza las estadísticas principales del jugador
                GameManager.instance.gameMenuOpen = true;  // Indica que el menú está abierto
            }
        }

        // Cierra el menú del juego si el jugador presiona el botón de cancelar (PC o Joypad)
        if (!GameManager.instance.battleActive)  // Verifica que no esté en una batalla
        {
            if (Input.GetButtonDown("RPGCanclePC") || Input.GetButtonDown("RPGCancleJoy"))
            {
                // Si el menú está abierto, reproduce el sonido de cancelar
                if (GameManager.instance.gameMenuOpen)
                {
                    MusicIndi.instance.PlaySFX(cancelButtonSound);
                }

                // Cierra el menú si no hay otras ventanas activas
                if (!itemWindow.activeInHierarchy && !equipWindow.activeInHierarchy && !skillsWindow.activeInHierarchy && !statusWindow.activeInHierarchy && !loadGame.activeInHierarchy && !quitPrompt.activeInHierarchy)
                {
                    if (!Save.instance.saveMenu.activeInHierarchy)  // Si el menú de guardar no está activo, cierra el menú
                    {
                        CloseMenu();
                    }
                }

                // Si el mensaje de "confirmar salir" está activo, lo oculta y vuelve a habilitar los botones del menú
                if (quitPrompt.activeInHierarchy)
                {
                    quitPrompt.SetActive(false);  // Oculta el mensaje de "confirmar salir"

                    // Rehabilita los botones que se deshabilitaron
                    item.interactable = true;
                    equip.interactable = true;
                    skills.interactable = true;
                    status.interactable = true;
                    load.interactable = true;
                    close.interactable = true;
                    quit.interactable = true;

                    // Selecciona el primer botón si no es móvil
                    btn = item;
                    SelectFirstButton();  // Asegura que el primer botón sea el seleccionado
                }

                // Si el mensaje de "cargar juego" está activo, lo oculta y habilita los botones del menú
                if (loadGame.activeInHierarchy)
                {
                    loadGame.SetActive(false);  // Oculta el mensaje de "cargar juego"

                    // Rehabilita los botones que se deshabilitaron
                    item.interactable = true;
                    equip.interactable = true;
                    skills.interactable = true;
                    status.interactable = true;
                    load.interactable = true;
                    close.interactable = true;
                    quit.interactable = true;

                    // Selecciona el primer botón si no es móvil
                    btn = item;
                    SelectFirstButton();  // Asegura que el primer botón sea el seleccionado
                }

                // Si la ventana de "estado" está abierta, la cierra
                if (statusWindow.activeInHierarchy)
                {
                    statusWindow.SetActive(false);  // Cierra la ventana de estado

                    // Desactiva los personajes en la ventana de estado
                    statusMenuCharacterSlots[0].SetActive(false);
                    statusMenuCharacterSlots[1].SetActive(false);
                    statusMenuCharacterSlots[2].SetActive(false);
                }
            }
        }
    }

    private void UpdateMainStats()
    {
        throw new NotImplementedException();
    }

    private void SelectFirstButton()
    {
        throw new NotImplementedException();
    }
}
