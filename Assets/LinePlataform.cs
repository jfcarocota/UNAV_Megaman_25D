using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePlataform : MonoBehaviour {

    public Transform from;
    public Transform to;

    private void OnDrawGizmosSelected()
    {
        if (from != null && to != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(from.position, to.position);

        }
    }
}
