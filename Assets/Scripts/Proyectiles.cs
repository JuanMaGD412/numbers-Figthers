using UnityEngine;

public class Proyectiles : MonoBehaviour
{
    public float velocidad = 15f;
    void Start()
    {
        GetComponent<Rigidbody>().linearVelocity = transform.forward * velocidad;
        Destroy(gameObject, 5f);
        
    }
}
