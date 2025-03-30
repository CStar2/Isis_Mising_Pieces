using UnityEngine;
using TMPro;

public class SaveLoad : MonoBehaviour
{
    
    
    public class PlayerData
    {
        public Vector3 position;
        public string SaveName;
    }
    
    
    
    public TMP_Text saveText;
    public TMP_InputField saveNameInput;

    public Transform PlayerTransform;

    public void Start()
    {
        //if (PlayerPrefs.HasKey("SaveName"))
        //{
        //    saveText.text = PlayerPrefs.GetString("SaveName2");
        //}
        //else
        //{
        //    saveText.text = "No Data";
        //}

                    //saveText.text = PlayerPrefs.GetString("SaveName", "Na Data");

                    //if (PlayerPrefs.HasKey("PlayerPosition"))
                    //{
                    //    var saveJSON = PlayerPrefs.GetString("PlayerPosition");
                    //    var position = JsonUtility.FromJson<Vector3>(saveJSON);
                    //    PlayerTransform.position = position;

                    //    var pos = JsonUtility.ToJson(PlayerTransform.position);
                    //    PlayerPrefs.SetString("PlayerPosition", pos);
                    //}
        
        if (PlayerPrefs.HasKey("SaveSlotOne"))
        {
            var saveSlotJSON = PlayerPrefs.GetString("SaveSlotOne");
            var saveSlot = JsonUtility.FromJson<PlayerData>(saveSlotJSON);
            saveText.text = saveSlot.SaveName;
            PlayerTransform.position = saveSlot.position;
        }
    }

    public void UpdateText()
    {
        if (!string.IsNullOrEmpty(saveNameInput.text) && !string.IsNullOrWhiteSpace(saveNameInput.text))
        {
            // PlayerPrefs.SetString("SaveName", saveNameInput.text); //las comillas es el nombre de la variable para guardar el texto
            var saveSlot = new PlayerData()
            {
               // position = PlayerTransform.position,
                SaveName = saveNameInput.text,
            };
            var saveSlotJSON = JsonUtility.ToJson(saveSlot);
            PlayerPrefs.SetString("SaveSlotOne", saveSlotJSON);
            
            saveText.text = saveNameInput.text;
            saveNameInput.text = "";
        }
    }

    public void DeleteSave()
    {
        //PlayerPrefs.DeleteKey("SaveName2");
        PlayerPrefs.DeleteAll();
    }
}
