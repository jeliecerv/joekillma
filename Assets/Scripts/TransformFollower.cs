using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformFollower : MonoBehaviour {

    [SerializeField]
    private Transform target;
    
    private void Update()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (target == null)
        {
            Debug.LogWarning("Missing target ref !", this);

            return;
        }

        transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);
    }
}
