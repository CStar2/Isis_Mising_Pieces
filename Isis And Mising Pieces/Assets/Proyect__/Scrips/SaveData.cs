using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class SaveData : MonoBehaviour
{
    // Singleton: Permite acceder a esta clase desde otros scripts
    public static SaveData instance;

    [Header("UI Elements")]
    public GameObject saveMenu;      // Menú de guardado
    public GameObject savePrompt;    // Confirmación de guardado
    public GameObject saveSlots;     // Ranuras de guardado
    public GameObject saving;        // Mensaje de guardado en curso
    public Text savingText;          // Texto de guardado
    public int currentSaveId;        // ID de la ranura de guardado actual

    // Botones de la UI
    public Button noButton;
    public Button slot1Btn;

    // Variable para evitar múltiples ejecuciones del guardado
    private bool isSaving = false;

    void Awake()
    {
        // Implementación del patrón Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Elimina instancias duplicadas
        }
    }

    void Update()
    {
        // Cierra el menú de guardado si el jugador presiona el botón de cancelar
        if (Input.GetButtonDown("RPGCanclePC") || Input.GetButtonDown("RPGCancleJoy"))
        {
            if (saveMenu.activeInHierarchy)
            {
                if (ControlManager.instance != null && !ControlManager.instance.mobile)
                {
                    GameMenu.instance.btn = GameMenu.instance.closeButtonSave;
                    GameMenu.instance.SelectFirstButton();
                }
            }
        }
    }

    public void OpenSaveMenu()
    {
        // Desactiva los controles táctiles si están activos
        if (GameMenu.instance != null)
        {
            GameMenu.instance.touchMenuButton.SetActive(false);
            GameMenu.instance.touchController.SetActive(false);
            GameMenu.instance.touchConfirmButton.SetActive(false);
        }

        // Indica que el menú de guardado está activo
        if (GameManager.instance != null)
        {
            GameManager.instance.gameMenuOpen = true;
            GameManager.instance.saveMenuActive = true;
        }

        saveMenu.SetActive(true);
    }

    public void CloseSaveMenu()
    {
        // Reactiva los controles táctiles si es necesario
        if (GameManager.instance != null && ControlManager.instance.mobile)
        {
            GameMenu.instance.touchMenuButton.SetActive(true);
            GameMenu.instance.touchController.SetActive(true);
            GameMenu.instance.touchConfirmButton.SetActive(true);
        }

        // Indica que el menú de guardado está cerrado
        if (GameManager.instance != null)
        {
            GameManager.instance.gameMenuOpen = false;
            GameManager.instance.saveMenuActive = false;
        }

        saveMenu.SetActive(false);
    }

    public void SaveGame()
    {
        // Previene múltiples ejecuciones del guardado
        if (!isSaving)
        {
            isSaving = true;
            StartCoroutine(SavingCo());

            // Guardado de datos del juego
            if (GameManager.instance != null)
                GameManager.instance.SaveData(currentSaveId);

            if (QuestManager.instance != null)
                QuestManager.instance.SaveQuestData(currentSaveId);

            if (ChestManager.instance != null)
                ChestManager.instance.SaveChestData(currentSaveId);

            if (EventManager.instance != null)
                EventManager.instance.SaveEventData(currentSaveId);

            CloseSavePromt();
            CloseSaveMenu();
        }
    }

    public void OpenSavePromt(int slotId)
    {
        currentSaveId = slotId;
        savePrompt.SetActive(true);

        // Selecciona el botón de "No" en caso de usar control o teclado
        if (ControlManager.instance != null && !ControlManager.instance.mobile)
        {
            GameMenu.instance.btn = noButton;
            GameMenu.instance.SelectFirstButton();
        }
    }

    public void OpenSaveSlots()
    {
        // Selecciona la primera ranura de guardado si no es una versión móvil
        if (ControlManager.instance != null && !ControlManager.instance.mobile)
        {
            GameMenu.instance.btn = slot1Btn;
            GameMenu.instance.SelectFirstButton();
        }
    }

    public void CloseSavePromt()
    {
        savePrompt.SetActive(false);

        // Vuelve a seleccionar el botón de guardado en la UI
        if (ControlManager.instance != null && !ControlManager.instance.mobile)
        {
            GameMenu.instance.btn = GameMenu.instance.saveButton;
            GameMenu.instance.SelectFirstButton();
        }
    }

    public IEnumerator SavingCo()
    {
        // Muestra el mensaje "Guardando..."
        saving.SetActive(true);
        savingText.text = "Saving";
        yield return new WaitForSeconds(0.5f);
        savingText.text = "Saving .";
        yield return new WaitForSeconds(0.5f);
        savingText.text = "Saving ..";
        yield return new WaitForSeconds(0.5f);
        savingText.text = "Saving ...";
        yield return new WaitForSeconds(0.5f);
        saving.SetActive(false);

        isSaving = false; // Restablece la bandera para permitir futuros guardados
    }
}
