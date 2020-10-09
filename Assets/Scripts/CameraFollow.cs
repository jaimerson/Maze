using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public GameObject target;

    public float speed = 2.0f;

    void Update()
    {
        float interpolation = speed * Time.deltaTime;

        Vector3 position = this.transform.position;
        position.x = Mathf.Lerp(this.transform.position.x, target.transform.position.x, interpolation);
        position.z = Mathf.Lerp(this.transform.position.z, target.transform.position.z, interpolation);

        this.transform.position = position;
    }
}