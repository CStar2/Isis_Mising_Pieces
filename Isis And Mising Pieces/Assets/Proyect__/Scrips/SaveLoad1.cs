using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SaveLoadData : MonoBehaviour
{
    
    
    public class PlayerData
    {
        public Vector3 position;
        
    }
    

    public Transform PlayerTransform;
    [SerializeField] public GameObject saveload;
    public Button save;

    public void Start()
    {
        
        if (PlayerPrefs.HasKey("SaveSlotOne"))
        {
            var saveSlotJSON = PlayerPrefs.GetString("SaveSlotOne");
            var saveSlot = JsonUtility.FromJson<PlayerData>(saveSlotJSON);
            PlayerTransform.position = saveSlot.position;
        }
    }

    public void UpdateText()
    {
        
       
            // PlayerPrefs.SetString("SaveName", saveNameInput.text); //las comillas es el nombre de la variable para guardar el texto
            var saveSlot = new PlayerData()
            {
                position = PlayerTransform.position,
               
            };
            var saveSlotJSON = JsonUtility.ToJson(saveSlot);
            PlayerPrefs.SetString("SaveSlotOne", saveSlotJSON);
            
            
      
    }

    public void DeleteSave()
    {
        //PlayerPrefs.DeleteKey("SaveName2");
        PlayerPrefs.DeleteAll();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        saveload.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        saveload.SetActive(false);
    }
}
