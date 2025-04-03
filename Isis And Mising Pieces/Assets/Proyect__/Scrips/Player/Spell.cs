using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] private GameObject spellPrefab;
    [SerializeField] private float timeToShoot = 0.3f;
    [SerializeField] private Transform SpellSpawnPoint;

    [SerializeField] private Transform AttackController;
    [SerializeField] private float AttackRadio;
    [SerializeField] private float Attackdamage;


    private float currentTime = 0f;


    public void Shoot()
    {
        if (currentTime <= Time.timeSinceLevelLoad)
        {
            //para crear un objeto en el  momento: Instantiate (objeto que queremos instanciar, su posicion, su angulo)
            //Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            Instantiate(spellPrefab, SpellSpawnPoint.position, SpellSpawnPoint.rotation);
            currentTime = timeToShoot + Time.timeSinceLevelLoad;

            
        }
    }

}
