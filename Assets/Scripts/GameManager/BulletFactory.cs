using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    public static BulletFactory Instance { get; private set; }
    
    [SerializeField] private Bullet _prefab;
    
    [SerializeField] private int _initialAmount;
    
    private ObjectPool<Bullet> _pool;

    private void Awake()
    {
        if (Instance == null)
                Instance = this;
        else
                Destroy(gameObject);


        _pool = new ObjectPool<Bullet>(CreateBullet, Bullet.TurnOn, Bullet.TurnOff, _initialAmount);
        
        
        //LAMBDA
        // _pool = new ObjectPool<Bullet>(creationMethod: () => Instantiate(_prefab),
        //                                 turnOnMethod: (bullet) => bullet.gameObject.SetActive(true), 
        //                                 turnOffMethod: (bullet) => bullet.gameObject.SetActive(false), 
        //                                 _initialAmount);
    }

    public Bullet GetFromPool()
    {
        return _pool.GetObject();
    }

    public void ReturnToPool(Bullet bullet)
    {
        _pool.ReturnToPool(bullet);
    }
    
    Bullet CreateBullet()
    {
        return Instantiate(_prefab);
    }
}