using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    // Update is called once per frame
    void LateUpdate()
    {
        //Permet d'embecher à la caméra d'aller vers le haut
        if (target.position.y < transform.position.y)
        {
            //Fait en sorte que les mouvement de caméra soit plus lisse
            Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = newPos;
        }
    }
}
