using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float timeToFire = 0;
    public float fireRate = 0.1f;
    public float damage = 10;

    public Transform firePoint;
    public LayerMask ToHit;

    public Transform BulletTrailPrefab;
    public GameObject damageBurst;
    public AudioSource audio;

    public int reloadTime;
    public bool canShoot;
    public bool canReload;
    public int ammo;

    public List<GameObject> bullets;


    void Update()
    {
        if(Input.GetButton("Shoot") && Time.time > timeToFire && canShoot)
        {
            timeToFire = Time.time + 1/fireRate;
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && canReload)
        {
            canReload = false;
            canShoot = false;
            StartCoroutine(Reload());
        }

    }

    public void Shoot ()
    {
        if(ammo > 0)
        {
            bullets[ammo-1].SetActive(false);

            Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
            RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 1000, ToHit);

            Effect();

            if (hit.collider != null)
            {
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    hit.transform.GetComponent<Enemy>().TakeDamage(damage);

                    Vector3 hitPosition = hit.point;
                    // Damage Burst
                    GameObject dmgBurst = Instantiate(damageBurst, hitPosition, Quaternion.identity);
                    var dmgBurstMain = dmgBurst.GetComponent<ParticleSystem>().main;
                    dmgBurstMain.startColor = new Color(.13f, .47f, 0f, 1f);
                }
            }
            ammo -= 1;
        }
        else
        {
            canShoot = false;
            canReload = false;
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        audio.Play();
        yield return new WaitForSeconds(reloadTime);
        reloadSprites();
        ammo = 6;
        canShoot = true;
        canReload = true;
    }


    void Effect()
    {
        Instantiate(BulletTrailPrefab, firePoint.position, firePoint.rotation);
    }

    public void reloadSprites()
    {
        for(int i = 0; i< 6; i++)
        {
            bullets[i].SetActive(true);
        }
    }
}
