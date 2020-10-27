using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shooting : MonoBehaviour
{
    public KeyCode shootKey = KeyCode.Mouse0;
    public GameObject projectile;
    public float shootForce;
    Transform shootingPoint;

    public KeyCode aimKey = KeyCode.Mouse1;

    public float aimSpeed;

    public GameObject distortionEffect;

    public ShootingManager shootingManager;

    bool hasAmmo = false;
    // Use this for initialization
    void Start()
    {
        shootingPoint = GameObject.Find("shootingPoint").transform;

        shootingManager = this.GetComponent<ShootingManager>();
    }

    void Update()
    {
        Aim(Input.GetMouseButton(1));
     
        if (Input.GetKeyDown(shootKey) && Input.GetMouseButton(1)) // Check if the player wants to shoot AND if the player is aiming
        {

                // Check if we have ammo 
                hasAmmo = shootingManager.checkAmmo();

                Shoot();

                // If we still have ammo subtract the ammo
                shootingManager.subtractAmmo();
           

        }


    }

    public void Shoot()
    {
        if (hasAmmo)
        {
            GameObject shot = GameObject.Instantiate(projectile, shootingPoint.position, shootingPoint.rotation * Quaternion.Euler(90f, 90f, 0f));
            shot.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);
        }

    }



    void Aim(bool p_isAiming)
    {
        Transform t_anchor = this.transform.parent.transform;
        Transform t_anchorAim = this.transform.parent.parent.Find("Aim Anchor").transform;
        Transform t_hip = this.transform.parent.parent.Find("Hip").transform;

        if (p_isAiming)
        {
            // Aim
            t_anchor.position = Vector3.Lerp(t_anchor.position, t_anchorAim.position, Time.deltaTime * aimSpeed);
 

        }
        else
        {
            // Back to side
            t_anchor.position = Vector3.Lerp(t_anchor.position, t_hip.position, Time.deltaTime * aimSpeed);
        }
    }

    
}