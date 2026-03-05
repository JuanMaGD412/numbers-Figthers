
using UnityEngine;

public class FightersSpawner : MonoBehaviour
{
    public Transform spawnPlayer;
    public Transform spawnEnemy;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int Playerid = GameManager.instance.personajeElegido;
        Instantiate(GameManager.instance.personajes[Playerid], spawnPlayer.position, spawnPlayer.rotation);

        int EnemyId = GameManager.instance.personajeRival;
        Instantiate(GameManager.instance.personajes[EnemyId], spawnEnemy.position, spawnEnemy.rotation);

    }
}
