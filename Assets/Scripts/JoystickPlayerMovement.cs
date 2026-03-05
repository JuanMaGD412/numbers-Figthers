using UnityEngine;

public class JoystickPlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Joystick joystick;

    private Rigidbody rb;
    private Vector3 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (CompareTag("Player"))
        {
            GameObject joystickObj = GameObject.FindGameObjectWithTag("Joystick");
            if (joystickObj != null)
            {
                joystick = joystickObj.GetComponent<Joystick>();
            }
            else
            {
                Debug.LogError("Joystick object not found in the scene. Please ensure it has the 'Joystick' tag.");
            }
        }
    }
    void Update()
    {
       if (!CompareTag("Player") || joystick == null) return;

        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        movement = new Vector3(horizontal, 0f, vertical);
    }

    void FixedUpdate()
    {
        if (!CompareTag("Player")) return;
        rb.linearVelocity = movement * speed;
    }
}
