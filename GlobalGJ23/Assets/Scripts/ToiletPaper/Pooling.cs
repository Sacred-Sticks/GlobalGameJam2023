using UnityEngine;

public class Pooling : MonoBehaviour
{
    [SerializeField] private GameObject poolingTarget;
    [SerializeField] private int poolCount;

    [SerializeField] private Vector3 poolStoragePoint;

    private void Start() {
        GeneratePool();
    }

    private void GeneratePool() {
        GameObject square = Instantiate(poolingTarget, poolStoragePoint, Quaternion.identity, transform);
        Rigidbody body = square.GetComponent<Rigidbody>();
        body.isKinematic = false;
        Rigidbody prevBody = body;
        HingeJoint joint;
        for (int i = 0; i < poolCount - 1; i++) {
            poolStoragePoint.x += 1f;
            square = Instantiate(poolingTarget, poolStoragePoint, Quaternion.identity, transform);
            body = square.GetComponent<Rigidbody>();
            joint = square.GetComponent<HingeJoint>();
            body.isKinematic = false;
            joint.connectedBody = prevBody;
            prevBody = body;
        }
    }
}
