using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject shootingPoint;

    [SerializeField]
    private float shootRate;

    [SerializeField]
    private String layerName;

    private float _lastShotTime;

    public bool ShootGun()
    {
        if (Time.timeScale > 0)
        {
            var timeSinceLastShoot = Time.time - _lastShotTime;
            if (timeSinceLastShoot < shootRate)
            {
                return false;
            }
            
            _lastShotTime = Time.time;
            Invoke("FireBullet", 0.0f);
            return true;
        }

        return false;
    }

    void FireBullet()
    {
        GameObject bullet = BulletPooling.Instance.GetFirstAvailable();
        if (bullet) {
            bullet.transform.position = shootingPoint.transform.position;
            bullet.transform.rotation = shootingPoint.transform.rotation;
            bullet.layer = LayerMask.NameToLayer($"{layerName}");
            bullet.SetActive(true);
        }
    }
}
