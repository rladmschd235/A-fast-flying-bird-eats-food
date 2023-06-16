using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    private void Update()
    {
        if(gameObject.transform.position.z > 95f)
        {
            gameObject.SetActive(false);
        }
    }
}
