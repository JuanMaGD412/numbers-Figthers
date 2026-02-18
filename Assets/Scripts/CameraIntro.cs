using UnityEngine;

public class CameraIntro : MonoBehaviour
{

    public Transform startPoint;
    public Transform endPoint;
    public float duration = 3.0f;
    float t = 0.0f;
    bool moving = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = startPoint.position;
        transform.rotation = startPoint.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!moving) return;
        t += Time.deltaTime / duration;
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, t);
        transform.rotation = Quaternion.Slerp(startPoint.rotation, endPoint.rotation, t);
        if (t >= 1.0f)
        {
            moving = false;
        }
    }
}
