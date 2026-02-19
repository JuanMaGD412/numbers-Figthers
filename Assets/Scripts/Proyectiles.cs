using UnityEngine;

public class Proyectiles : MonoBehaviour
{
    public float velocidad = 15f;
    public GameObject efecoImpacto;
    void Start()
    {
        GetComponent<Rigidbody>().linearVelocity = transform.forward * velocidad;
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (efecoImpacto != null)
        {
            ContactPoint contacto = collision.contacts[0];
            GameObject efecto = Instantiate(efecoImpacto, contacto.point, Quaternion.LookRotation(contacto.normal));

            Destroy(efecto, 3f);
        }
        Destroy(gameObject);
    }
}
