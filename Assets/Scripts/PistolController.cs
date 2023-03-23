using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PistolController : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _SpawnPointTF;
    [SerializeField] private float bulletSpeed = 20; 
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable pistolGrabbable = GetComponent<XRGrabInteractable>();
        pistolGrabbable.activated.AddListener(FireBullet);
    }

    private void FireBullet(ActivateEventArgs arg0)
    {
       GameObject bullet = Instantiate(_bulletPrefab,_SpawnPointTF.position,_SpawnPointTF.rotation);
       bullet.GetComponent<Rigidbody>().velocity = _SpawnPointTF.forward * bulletSpeed;
       Destroy(bullet, 4f);
    }

}
