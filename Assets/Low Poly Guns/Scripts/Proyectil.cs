using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float velocidad = 20f;
    
    void Start()
    {
        GetComponent<Rigidbody>().linearVelocity = transform.forward * velocidad;
        Destroy(gameObject, 5f);
    }
}
