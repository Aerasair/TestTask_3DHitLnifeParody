using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int _numBulletPref;

    [SerializeField] protected Transform _shootPoint;

    [SerializeField] protected float _speed;

    [SerializeField] ObjectPool _objectPool;

    public virtual void Shoot()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Vector3 hitPoint = ray.GetPoint(1000);
        Vector3 mouseDirection = hitPoint - gameObject.transform.position;
        mouseDirection = mouseDirection.normalized;

        //последняя цифра  - номер нужного префаба, для пушки 0, для меча 1 
        GameObject bulletclone = _objectPool.GetBullet(_shootPoint.position, mouseDirection, _speed, _numBulletPref);
    }
}
