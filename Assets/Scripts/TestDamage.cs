using UnityEngine;

public class TestDamage : MonoBehaviour
{
    public Health vida;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            vida.RecibirDano(10);
        }
    }
}
