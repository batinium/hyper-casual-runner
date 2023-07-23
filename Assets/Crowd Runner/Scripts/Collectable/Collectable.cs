using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject collectable;
    public float rotationSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        collectable.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
