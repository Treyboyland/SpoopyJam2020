using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookTowardsMouse : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = mainCamera.nearClipPlane;
        var mousePosWorld = mainCamera.ScreenToWorldPoint(mousePos);
        //mousePos.z = transform.position.z;
        //Assumes running on player object
        var target = mousePosWorld - transform.position;
        //var newDirection = Vector3.RotateTowards(transform.forward, target, 2 * Mathf.PI, 2 * Mathf.PI);

        var rotation = Quaternion.LookRotation(target, Vector3.forward).eulerAngles;
        //TODO: I frankly have no idea why this works
        rotation.x = 0;
        rotation.y = 0;
        rotation.z *= -1;


        transform.rotation = Quaternion.Euler(rotation);
    }
}
