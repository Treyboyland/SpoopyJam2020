using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ConstantFowardSpeed : MonoBehaviour
{
    [SerializeField]
    float speed;

    Rigidbody2D body = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        if (body == null)
        {
            body = GetComponent<Rigidbody2D>();
        }
        if (gameObject.activeInHierarchy && body != null)
        {
            body.velocity = Vector3.RotateTowards(speed * Vector3.up, speed * transform.up, 2 * Mathf.PI, 2 * Mathf.PI);
            //Debug.LogWarning(body.velocity);
        }
    }
}
