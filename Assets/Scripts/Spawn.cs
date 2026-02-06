using NUnit.Framework;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform spawnPlayer;
    public Transform spawnEnemy;

    private void Start()
    {
        int id = GameManager.Instance.personajeSeleccionado;
        Instantiate(GameManager.Instance.personajes[id], spawnPlayer.position, spawnPlayer.rotation);

        int EnemyId = GameManager.Instance.personajeRival; ;
        Instantiate(GameManager.Instance.personajes[EnemyId], spawnEnemy.position, spawnEnemy.rotation);
    }

}
