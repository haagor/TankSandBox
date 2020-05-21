using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    public int m_PlayerNumber = 1;              // Used to identify the different players.
    public Rigidbody m_Shell;                   // Prefab of the shell.
    public Transform m_FireTransform;           // A child of the tank where the shells are spawned.
    public float m_LaunchForce = 30f;           // The force given to the shell if the fire button is not held.
    public Rigidbody hull;
    public AudioSource shot;
    public ParticleSystem burst;


    private void Start()
    {
        // The fire axis is based on the player number.
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
            Explode();
            FireForce();
        }
    }


    private void Fire()
    {
        // Create an instance of the shell and store a reference to it's rigidbody.
        Rigidbody shellInstance =
            Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        // Set the shell's velocity to the launch force in the fire position's forward direction.
        shellInstance.velocity = m_LaunchForce * m_FireTransform.forward;
    }

    private void FireForce()
    {
        shot.Play();
        hull.AddForce(m_FireTransform.forward * (-3000000));
    }

    void Explode()
    {
        burst.Play();
    }
}