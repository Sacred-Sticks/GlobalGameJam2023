using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour {
    [SerializeField] private GameObject poolingTarget;
    [SerializeField] private int poolCount;

    [SerializeField] private Vector3 poolStoragePoint;
    [SerializeField] private float poolingDelay;
    [SerializeField] private GameObject origin;

    [SerializeField] private List<GameObject> pool;
    [SerializeField] private Material lineRendererMaterial;
    [SerializeField] private float maxMagnitude;

    private Vector3 currentVelocity;
    private int currentIndex;
    private Rigidbody first;
    private Rigidbody last;
    Vector3 zero = new(0, 0, 0);

    private void Start() {
        GeneratePool();
    }

    public void CommitPool() {
        StartCoroutine(RunPooling());
    }

    private IEnumerator RunPooling() {
        yield return new WaitForSeconds(poolingDelay);
        while (currentIndex < poolCount) {
            PullFromPool();
            yield return new WaitForSeconds(poolingDelay);
        }
        while (first.velocity.magnitude > maxMagnitude || last.velocity.magnitude > maxMagnitude) {
            yield return new WaitForFixedUpdate();
        }

        ResetPool();
    }

    private void GeneratePool() {
        GameObject square = Instantiate(poolingTarget, poolStoragePoint, Quaternion.identity, transform);
        Rigidbody body = square.GetComponent<Rigidbody>();
        Rigidbody prevBody = body;
        first = body;
        Joint joint = square.GetComponent<Joint>();
        Destroy(joint);
        pool.Add(square);
        square.SetActive(false);
        for (int i = 0; i < poolCount - 1; i++) {
            poolStoragePoint.x -= 1;
            square = Instantiate(poolingTarget, poolStoragePoint, Quaternion.identity, transform);
            body = square.GetComponent<Rigidbody>();
            joint = square.GetComponent<Joint>();
            joint.connectedBody = prevBody;
            prevBody = body;
            pool.Add(square);
            square.SetActive(false);
        }
        last = body;
    }

    private void PullFromPool() {
        GameObject square = pool[currentIndex];
        square.SetActive(true);
        Rigidbody body = square.GetComponent<Rigidbody>();
        if (currentIndex == 0) {
            body.position = origin.transform.position;
            body.velocity = origin.GetComponent<Rigidbody>().velocity;
        }
        else {
            body.position = pool[currentIndex - 1].transform.position - pool[currentIndex - 1].transform.forward * 0.1f;
            body.velocity = currentVelocity;
        }
        currentVelocity = pool[0].GetComponent<Rigidbody>().velocity;
        currentIndex++;
    }

    private void ResetPool() {
        GameObject go = new("Toilet Paper Renderer");
        LineRenderer lr = go.AddComponent<LineRenderer>();
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.positionCount = 0;
        lr.material = lineRendererMaterial;
        lr.generateLightingData = true;
        currentIndex = 0;

        foreach (var point in pool) {
            lr.positionCount++;
            lr.SetPosition(lr.positionCount - 1, point.transform.position);

            point.transform.rotation = Quaternion.identity;
            point.SetActive(false);
            point.GetComponent<Rigidbody>().velocity = new();
        }
    }
}
