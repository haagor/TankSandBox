using System;
using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    public Rigidbody shell;
    public Transform fireTransform;
    public float launchForce = 1000f;
    public Rigidbody hull;
    public AudioSource shot;
    public ParticleSystem burst;
    public ReloadBar reloadBar;

    private bool reload;
    private float startingTimeReload;

    private void Start()
    {
        reload = false;
        reloadBar.SetMaxReload(300);
        reloadBar.SetReloadLevel(0);
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !reload)
        {
            Fire();
            Explode();
            FireForce();
        }
        if (reload)
        {
            if (Time.time - startingTimeReload > 3)
            {
                reload = false;
            }
            reloadBar.SetReloadLevel(Convert.ToInt32((Time.time - startingTimeReload) * 100));
        } 
    }

    private void Fire()
    {
        Rigidbody shellInstance =
            Instantiate(shell, fireTransform.position, fireTransform.rotation) as Rigidbody;

        shellInstance.velocity = launchForce * fireTransform.forward;

        reload = true;
        startingTimeReload = Time.time;
        reloadBar.SetReloadLevel(300);
    }

    private void FireForce()
    {
        shot.Play();
        hull.AddForce(fireTransform.forward * (-3000000));
    }

    void Explode()
    {
        burst.Play();
    }
}