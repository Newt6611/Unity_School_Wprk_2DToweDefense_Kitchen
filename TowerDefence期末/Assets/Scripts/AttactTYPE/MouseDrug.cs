using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrug : MonoBehaviour
{
    [SerializeField] private float maxX;
    [SerializeField] private float minX;
    [SerializeField] private float maxY;
    [SerializeField] private float minY;

    [SerializeField] private float throwSpeed;
    private Vector2 throwPoint;

    void Start()
    {
        throwPoint = new Vector2(Random.Range(minX, maxX), Random.Range(maxY, minY));
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, throwPoint, throwSpeed * Time.deltaTime);
    }

}
