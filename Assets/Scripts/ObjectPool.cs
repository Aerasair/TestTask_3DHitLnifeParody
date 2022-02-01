using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private List<Pool> _pools;

    private void Start()
    {
        foreach (Pool pool in _pools)
        {
            for (int i = 0; i <= pool.PoolSize; i++)
            {
                GameObject bullet = Instantiate(pool.prefabBullet);
                bullet.SetActive(false);
                pool.poolBullets.Add(bullet);
            }
        }
    }

   public GameObject GetBullet(Vector3 shootPoint,Vector3 mouseDirection, float speed, int numPool)
    {
        int curInd = _pools[numPool].currentIndex;

        _pools[numPool].poolBullets[curInd].GetComponent<Rigidbody>().velocity = Vector3.zero;
        _pools[numPool].poolBullets[curInd].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        _pools[numPool].poolBullets[curInd].SetActive(true);
        _pools[numPool].poolBullets[curInd].transform.position = shootPoint;
        _pools[numPool].poolBullets[curInd].GetComponent<Rigidbody>().AddForce(mouseDirection * speed, ForceMode.Impulse);
        _pools[numPool].currentIndex++;
        if (_pools[numPool].currentIndex == _pools[numPool].PoolSize) _pools[numPool].currentIndex = 0;
        return _pools[numPool].poolBullets[curInd];
    }
}

[Serializable]
public class Pool
{
    public int PoolSize;
    public GameObject prefabBullet;
    public List<GameObject> poolBullets;
    public int currentIndex;
}
