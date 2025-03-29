using UnityEngine;

public class StatusCharacter : MonoBehaviour
{
    [Header("Caracter�sticas del Personaje")]
    public string characterName = "H�roe";
    public int level = 1;
    public int maxLevel = 10;
    public int currentHP, maxHP;
    public int currentSP, maxSP;
    public int currentEXP;
    public int nextLevelEXP = 100; // Experiencia necesaria para el pr�ximo nivel
    public float expMultiplier = 1.2f; // Aumenta la experiencia requerida en cada nivel

    [Header("Estad�sticas")]
    public int strength = 5;
    public int defense = 5;
    public int agility = 5;

    private void Start()
    {
        // Inicializa HP y SP
        maxHP = 100;
        maxSP = 50;
        currentHP = maxHP;
        currentSP = maxSP;
    }

    public void AddExp(int expToAdd)
    {
        currentEXP += expToAdd;

        while (currentEXP >= nextLevelEXP && level < maxLevel)
        {
            currentEXP -= nextLevelEXP;
            LevelUp();
        }

        if (level >= maxLevel)
            currentEXP = 0; // Evita ganar m�s EXP al m�ximo nivel
    }

    private void LevelUp()
    {
        level++;
        nextLevelEXP = Mathf.FloorToInt(nextLevelEXP * expMultiplier); // Aumenta la EXP necesaria

        // Mejora estad�sticas
        strength += 2;
        defense += 2;
        agility += 1;

        // Aumenta HP y SP
        maxHP += 10;
        maxSP += 5;
        currentHP = maxHP;
        currentSP = maxSP;

        Debug.Log(characterName + " subi� al nivel " + level + "!");
    }
}
