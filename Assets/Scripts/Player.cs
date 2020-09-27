using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        this.body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float forceX = Input.GetAxis("Horizontal") * speed;
        float forceZ = Input.GetAxis("Vertical") * speed;
        body.AddForce(forceX, 0, forceZ, ForceMode.Impulse);
    }
}
