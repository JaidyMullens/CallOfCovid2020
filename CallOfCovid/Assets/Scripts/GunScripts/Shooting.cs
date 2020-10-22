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

    // Use this for initialization
    void Start()
    {
        shootingPoint = GameObject.Find("shootingPoint").transform;
        // waveEffect = currentWeapon.transform.Find("WaveEffect").GetComponentInChildren<ParticleSystem>();
        distortionEffect.SetActive(false);
    }

    //[SerializeField] ParticleSystem waveEffect;

    private void Update()
    {
        if (Input.GetKeyDown(shootKey) && Input.GetMouseButton(1)) // Check if the player wants to shoot AND if the player is aiming
        {


            GameObject shot = GameObject.Instantiate(projectile, shootingPoint.position, shootingPoint.rotation * Quaternion.Euler(90f, 90f, 0f));
            shot.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);


        }


        Aim(Input.GetMouseButton(1));

    }

     public GameObject currentWeapon;

    void Aim(bool p_isAiming)
    {
        Transform t_anchor = currentWeapon.transform.parent.transform;
        Transform t_anchorAim = currentWeapon.transform.parent.parent.Find("Aim Anchor").transform;
        Transform t_hip = currentWeapon.transform.parent.parent.Find("Hip").transform;

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