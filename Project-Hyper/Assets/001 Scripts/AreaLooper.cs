using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaLooper : MonoBehaviour
{
    [SerializeField] private AreaSpawner areaSpawner;
    private float areaWidth;
    private float deadPosition;

    private void Awake()
    {
        areaSpawner = FindObjectOfType<AreaSpawner>();

        BoxCollider boxCollider = GetComponent<BoxCollider>();
        areaWidth = boxCollider.size.z;
        deadPosition = areaWidth * areaSpawner.count;
    }

    private void Update()
    {
        if(transform.position.z >= deadPosition)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        Vector3 reposition = Vector3.zero;
        transform.position = reposition;
    }
}
