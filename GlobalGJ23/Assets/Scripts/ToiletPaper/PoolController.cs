using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    [SerializeField] private List<Pooling> pools;
    [SerializeField] private GameObject pooler;

    private void Start() {
        AddToPool();
    }

    public void AssignPool(GameObject origin) {
        foreach(Pooling pool in pools) {
            if (!pool.currectlyActive) {
                pool.origin = origin;
                pool.CommitPool();
                return;
            }
        }
        Pooling newPool = AddToPool().GetComponent<Pooling>();
        newPool.origin = origin;
        newPool.CommitPool();
    }

    private GameObject AddToPool() {
        GameObject newPooler = Instantiate(pooler, new(0, -10, 0), Quaternion.identity, transform);
        pools.Add(newPooler.GetComponent<Pooling>());
        return newPooler;
    }
}
