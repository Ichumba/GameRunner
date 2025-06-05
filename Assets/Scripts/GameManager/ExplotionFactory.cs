using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionFactory : MonoBehaviour
{
    public static ExplotionFactory Instance { get; private set; }

    [SerializeField] private Explosion _prefab;

    [SerializeField] private int _initialAmount;

    private ObjectPool<Explosion> _pool;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);


        _pool = new ObjectPool<Explosion>(CreateExplotion, Explosion.TurnOn, Explosion.TurnOff, _initialAmount);


        //LAMBDA
        // _pool = new ObjectPool<Bullet>(creationMethod: () => Instantiate(_prefab),
        //                                 turnOnMethod: (bullet) => bullet.gameObject.SetActive(true), 
        //                                 turnOffMethod: (bullet) => bullet.gameObject.SetActive(false), 
        //                                 _initialAmount);
    }

    public Explosion GetFromPool()
    {
        return _pool.GetObject();
    }

    public void ReturnToPool(Explosion explotion)
    {
        _pool.ReturnToPool(explotion);
    }

    Explosion CreateExplotion()
    {
        return Instantiate(_prefab);
    }
}
