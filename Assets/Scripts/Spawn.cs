using NUnit.Framework;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform spawnPlayer;
    public Transform spawnEnemy;

    private void Start()
    {
        int id = GameManager.instance.personajeElegido;
        Instantiate(GameManager.instance.personajes[id], spawnPlayer.position, spawnPlayer.rotation);

        int EnemyId = GameManager.instance.personajeRival; ;
        Instantiate(GameManager.instance.personajes[EnemyId], spawnEnemy.position, spawnEnemy.rotation);
    }

}
