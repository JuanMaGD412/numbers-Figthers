using System.Net;
using Unity.Properties;
using UnityEngine;

public class CameraIntro : MonoBehaviour
{
    public Transform[] points;   // puntos de recorrido
    public Transform player;
    public Transform enemy;

    public float speed = 1f;
    public float lookSpeed = 5f;
    public float waitTime = 0.5f;

    int index = 0;
    float t = 0f;
    bool waiting = false;
    bool introFin = false;

    void Start()
    {
        transform.position = points[0].position;
    }

    void Update()
    {
        if (!introFin)
            Tour();
        else
            MirarEnemigo();
    }

    void Tour()
    {
        if (index >= points.Length - 1 || waiting) return;

        t += Time.deltaTime * speed;

        float smooth = Mathf.SmoothStep(0, 1, t);

        transform.position = Vector3.Lerp(
            points[index].position,
            points[index + 1].position,
            smooth
        );

        // 🔥 SIEMPRE mirar al player
        Mirar(player);

        if (t >= 1f)
        {
            index++;
            t = 0f;
            waiting = true;
            Invoke(nameof(Next), waitTime);
        }
    }

    void Next()
    {
        waiting = false;

        // si llegó al final, cambiamos de objetivo
        if (index >= points.Length - 1)
            introFin = true;
    }

    void Mirar(Transform objetivo)
    {
        Vector3 dir = objetivo.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            rot,
            Time.deltaTime * lookSpeed
        );
    }

    void MirarEnemigo()
    {
        Mirar(enemy);
    }
}
