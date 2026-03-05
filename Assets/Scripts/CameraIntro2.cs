using UnityEngine;

public class CameraIntro2 : MonoBehaviour
{
    public Transform[] points;
    public Transform player;
    public Transform enemy;

    public float speed = 2.0f;
    public float lookSpeed = 5.0f;
    public float waitTime = 1.0f;

    int index = 0;
    float t = 0f;
    bool waiting = false;
    bool introFinished = false;
    void Start()
    {
        transform.position = points[0].position;
    }

    void Update()
    {
        if (!introFinished)
            Recorrido();
        else
            MirarEnemigo();
    }

    void Recorrido()
    {
        if (index >= points.Length - 1 || waiting) return;
        t += Time.deltaTime * speed;
        float smooth = Mathf.SmoothStep(0f, 1f, t);
        transform.position = Vector3.Lerp(points[index].position, points[index + 1].position, smooth);

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
        if (index >= points.Length - 1)
            introFinished = true;
    }
    void Mirar(Transform objetivo)
    {
        Vector3 direction = (objetivo.position - transform.position);
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed);
    }

    void MirarEnemigo()
    {
        Mirar(enemy);
    }
}