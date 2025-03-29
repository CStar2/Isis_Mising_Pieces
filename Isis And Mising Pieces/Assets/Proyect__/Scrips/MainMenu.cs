using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class MainMenu : MonoBehaviour
{
    // Instancia est�tica para que otros scripts puedan acceder a este men�
    public static MainMenu instance;

    [Header("Inicializaci�n")]
    // Variables para los componentes de UI que se usan en este men�
    public Text skillDescription;  // Descripci�n de la habilidad seleccionada
    public Image itemSprite;  // Imagen del item seleccionado
    public Image equipItemSprite;  // Imagen del equipo seleccionado
    public bool itemSelected;  // Indica si un �tem ha sido seleccionado
    public GameObject menu;  // El objeto del men� principal
    public GameObject gotItemMessage;  // Mensaje cuando el jugador obtiene un �tem
    public Text gotItemMessageText;  // Texto del mensaje de �tem obtenido
    public GameObject loadPrompt;  // Mensaje de carga
    public GameObject quitPrompt;  // Mensaje para confirmar salir
    public GameObject discardPrompt;  // Mensaje para confirmar descartar
    public Text discardItemText;  // Texto para descartar �tem
    public GameObject itemWindow;  // Ventana de �tems
    public GameObject skillsWindow;  // Ventana de habilidades
    public GameObject equipWindow;  // Ventana de equipo
    public GameObject statusWindow;  // Ventana de estado
    public List<StatusCharacter> playerStats;  // Lista de estad�sticas del personaje principal
    public Text nameText, hpText, spText, lvlText, expText;  // Textos para mostrar estad�sticas en las ventanas
    public Slider expSlider, HPSlider, SPSlider;  // Barras de progreso de experiencia, salud y energ�a
    public Image charImage;  // Imagen del personaje
    public GameObject skillCharacterSlot;  // Espacio para mostrar habilidades del personaje
    public Text nameTextSkill;  // Nombre del personaje en la ventana de habilidades
    public bool skillSelected;  // Indica si se ha seleccionado una habilidad
    public Button skillCharChoice;  // Bot�n para seleccionar el personaje que usa la habilidad
    public int selectedSkillPower;  // Poder de la habilidad seleccionada
    public int selectedSkillCost;  // Coste de la habilidad seleccionada
    public int selectedSkillChar;  // �ndice del personaje que usa la habilidad
    public GameObject gold;  // Objeto para mostrar la cantidad de oro
    public Text goldText;  // Texto para mostrar la cantidad de oro
    public Button saveButton;  // Bot�n para guardar el progreso
    public Button quitButton;  // Bot�n para salir del juego
    private Item activeItem;

    // Evento para gestionar la interacci�n con la UI
    public EventSystem es;

    // Botones de interacci�n con el men�
    public Button item;  // Bot�n para acceder al inventario de �tems
    public Button equip;  // Bot�n para acceder al men� de equipamiento
    public Button skills;  // Bot�n para acceder a las habilidades
    public Button status;  // Bot�n para ver las estad�sticas del personaje
    public Button load;  // Bot�n para cargar la partida
    public Button close;  // Bot�n para cerrar el men�
    public Button useItemButton;  // Bot�n para usar un �tem
    public Button discardItemButton;  // Bot�n para descartar un �tem
    public Button quitNo;  // Bot�n para no salir del juego

    // **Funciones principales**

    // M�todo para mostrar el men� principal
    public void ShowMenu()
    {
        menu.SetActive(true);  // Muestra el men� principal
        loadPrompt.SetActive(false);  // Oculta el mensaje de carga
        quitPrompt.SetActive(false);  // Oculta el mensaje de salida
    }

    // M�todo para ocultar el men� principal
    public void HideMenu()
    {
        menu.SetActive(false);  // Oculta el men� principal
    }

    // M�todo para mostrar la ventana de �tems
    public void ShowItemWindow()
    {
        itemWindow.SetActive(true);  // Muestra la ventana de �tems
        skillsWindow.SetActive(false);  // Oculta la ventana de habilidades
        equipWindow.SetActive(false);  // Oculta la ventana de equipamiento
    }

    // M�todo para mostrar la ventana de habilidades
    public void ShowSkillsWindow()
    {
        skillsWindow.SetActive(true);  // Muestra la ventana de habilidades
        itemWindow.SetActive(false);  // Oculta la ventana de �tems
        equipWindow.SetActive(false);  // Oculta la ventana de equipamiento
    }

    // M�todo para mostrar la ventana de equipo
    public void ShowEquipWindow()
    {
        equipWindow.SetActive(true);  // Muestra la ventana de equipamiento
        itemWindow.SetActive(false);  // Oculta la ventana de �tems
        skillsWindow.SetActive(false);  // Oculta la ventana de habilidades
    }

    // M�todo para usar un �tem
    public void UseItem(Item item)
    {
        // Aqu� ir�a la l�gica para usar el �tem
        // Por ejemplo, aumentar la salud, energ�a, o lo que el �tem haga
        Debug.Log("Usando �tem: " + item.name);
    }

    // M�todo para descartar un �tem
    public void DiscardItem(Item item)
    {
        // L�gica para descartar el �tem
        Debug.Log("�tem descartado: " + item.name);
    }

    // M�todo para guardar el juego
    public void SaveGame()
    {
        // Aqu� va la l�gica para guardar la partida
        Debug.Log("Guardando partida...");
    }

    // M�todo para cargar la partida
    public void LoadGame()
    {
        // L�gica para cargar la partida
        Debug.Log("Cargando partida...");
    }

    // M�todo para salir del juego
    public void QuitGame()
    {
        // Aqu� va la l�gica para salir del juego
        Debug.Log("Saliendo del juego...");
        Application.Quit();  // Cierra la aplicaci�n
    }

    // **Funciones para gestionar las interacciones de los botones**

    // M�todo que se ejecuta cuando se presiona el bot�n de usar �tem
    public void OnUseItemButtonPressed()
    {
        // Supongamos que se usa el primer �tem
        UseItem(activeItem);  // Llamamos a la funci�n UseItem con el �tem activo
    }

    // M�todo que se ejecuta cuando se presiona el bot�n de descartar �tem
    public void OnDiscardItemButtonPressed()
    {
        // Supongamos que se descarta el primer �tem
        DiscardItem(activeItem);  // Llamamos a la funci�n DiscardItem con el �tem activo
    }

    // M�todo que se ejecuta cuando se presiona el bot�n de salir
    public void OnQuitButtonPressed()
    {
        QuitGame();  // Llamamos a la funci�n QuitGame para salir del juego
    }

    [Header("Item Selection")]
    public bool itemConfirmed = false;  // Indica si un �tem ha sido confirmado por el jugador
    public string selectedItem;  // Guarda el nombre del �tem seleccionado

    [Header("Linked Scenes")]
    public string mainMenuScene;  // Nombre de la escena del men� principal
    public string loadGameScene;  // Nombre de la escena de carga del juego

    [Header("Sound")]
    public int openMenuButtonSound;  // ID del sonido que se reproduce al abrir el men�
    public int cancelButtonSound;  // ID del sonido que se reproduce al cancelar

    public Button btn { get; private set; }

    // Use this for initialization
    void Start()
    {
        instance = this;  // Inicializa la instancia est�tica para poder acceder a esta clase desde otros scripts
    }

    // Update is called once per frame
    void Update()
    {

        // Abre el men� del juego si el jugador presiona el bot�n de men� (PC o Joypad)
        if (Input.GetButtonDown("RPGMenuPC") || Input.GetButtonDown("RPGMenuJoy"))
        {
            // Verifica si el men� se puede abrir (no se puede abrir durante un di�logo, batalla, etc.)
            if (ScreenMovement.instance.fading == false && !GameManager.instance.battleActive && !GameManager.instance.dialogActive && !GameManager.instance.shopActive && !GameManager.instance.innActive && !GameManager.instance.saveMenuActive && !GameManager.instance.cutSceneActive)
            {
                // Si el men� no est� abierto, reproduce el sonido de abrir el men�
                if (!menu.activeInHierarchy)
                {
                    MusicIndi.instance.PlaySFX(openMenuButtonSound);
                }

                // Prevenimos que el bot�n resaltado vuelva a ser el bot�n por defecto cuando se presiona el bot�n de men�
                if (!menu.activeInHierarchy)
                {
                    btn = item;  // Establece el bot�n 'item' como el seleccionado
                    SelectFirstButton();  // Selecciona el primer bot�n del men�
                }

                menu.SetActive(true);  // Muestra el men�
                UpdateMainStats();  // Actualiza las estad�sticas principales del jugador
                GameManager.instance.gameMenuOpen = true;  // Indica que el men� est� abierto
            }
        }

        // Cierra el men� del juego si el jugador presiona el bot�n de cancelar (PC o Joypad)
        if (!GameManager.instance.battleActive)  // Verifica que no est� en una batalla
        {
            if (Input.GetButtonDown("RPGCanclePC") || Input.GetButtonDown("RPGCancleJoy"))
            {
                // Si el men� est� abierto, reproduce el sonido de cancelar
                if (GameManager.instance.gameMenuOpen)
                {
                    MusicIndi.instance.PlaySFX(cancelButtonSound);
                }

                // Cierra el men� si no hay otras ventanas activas
                if (!itemWindow.activeInHierarchy && !equipWindow.activeInHierarchy && !skillsWindow.activeInHierarchy && !statusWindow.activeInHierarchy && !loadGame.activeInHierarchy && !quitPrompt.activeInHierarchy)
                {
                    if (!Save.instance.saveMenu.activeInHierarchy)  // Si el men� de guardar no est� activo, cierra el men�
                    {
                        CloseMenu();
                    }
                }

                // Si el mensaje de "confirmar salir" est� activo, lo oculta y vuelve a habilitar los botones del men�
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

                    // Selecciona el primer bot�n si no es m�vil
                    btn = item;
                    SelectFirstButton();  // Asegura que el primer bot�n sea el seleccionado
                }

                // Si el mensaje de "cargar juego" est� activo, lo oculta y habilita los botones del men�
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

                    // Selecciona el primer bot�n si no es m�vil
                    btn = item;
                    SelectFirstButton();  // Asegura que el primer bot�n sea el seleccionado
                }

                // Si la ventana de "estado" est� abierta, la cierra
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
