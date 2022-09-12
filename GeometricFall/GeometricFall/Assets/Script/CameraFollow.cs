using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    // Update is called once per frame
    void LateUpdate()
    {
        //Permet d'embecher � la cam�ra d'aller vers le haut
        if (target.position.y < transform.position.y)
        {
            //Fait en sorte que les mouvement de cam�ra soit plus lisse
            Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = newPos;
        }
    }
}
