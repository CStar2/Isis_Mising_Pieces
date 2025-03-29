using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class SaveData : MonoBehaviour
{
    // Singleton: Permite acceder a esta clase desde otros scripts
    public static SaveData instance;

    [Header("UI Elements")]
    public GameObject saveMenu;      // Men� de guardado
    public GameObject savePrompt;    // Confirmaci�n de guardado
    public GameObject saveSlots;     // Ranuras de guardado
    public GameObject saving;        // Mensaje de guardado en curso
    public Text savingText;          // Texto de guardado
    public int currentSaveId;        // ID de la ranura de guardado actual

    // Botones de la UI
    public Button noButton;
    public Button slot1Btn;

    // Variable para evitar m�ltiples ejecuciones del guardado
    private bool isSaving = false;

    void Awake()
    {
        // Implementaci�n del patr�n Singleton
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
        // Cierra el men� de guardado si el jugador presiona el bot�n de cancelar
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
        // Desactiva los controles t�ctiles si est�n activos
        if (GameMenu.instance != null)
        {
            GameMenu.instance.touchMenuButton.SetActive(false);
            GameMenu.instance.touchController.SetActive(false);
            GameMenu.instance.touchConfirmButton.SetActive(false);
        }

        // Indica que el men� de guardado est� activo
        if (GameManager.instance != null)
        {
            GameManager.instance.gameMenuOpen = true;
            GameManager.instance.saveMenuActive = true;
        }

        saveMenu.SetActive(true);
    }

    public void CloseSaveMenu()
    {
        // Reactiva los controles t�ctiles si es necesario
        if (GameManager.instance != null && ControlManager.instance.mobile)
        {
            GameMenu.instance.touchMenuButton.SetActive(true);
            GameMenu.instance.touchController.SetActive(true);
            GameMenu.instance.touchConfirmButton.SetActive(true);
        }

        // Indica que el men� de guardado est� cerrado
        if (GameManager.instance != null)
        {
            GameManager.instance.gameMenuOpen = false;
            GameManager.instance.saveMenuActive = false;
        }

        saveMenu.SetActive(false);
    }

    public void SaveGame()
    {
        // Previene m�ltiples ejecuciones del guardado
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

        // Selecciona el bot�n de "No" en caso de usar control o teclado
        if (ControlManager.instance != null && !ControlManager.instance.mobile)
        {
            GameMenu.instance.btn = noButton;
            GameMenu.instance.SelectFirstButton();
        }
    }

    public void OpenSaveSlots()
    {
        // Selecciona la primera ranura de guardado si no es una versi�n m�vil
        if (ControlManager.instance != null && !ControlManager.instance.mobile)
        {
            GameMenu.instance.btn = slot1Btn;
            GameMenu.instance.SelectFirstButton();
        }
    }

    public void CloseSavePromt()
    {
        savePrompt.SetActive(false);

        // Vuelve a seleccionar el bot�n de guardado en la UI
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
