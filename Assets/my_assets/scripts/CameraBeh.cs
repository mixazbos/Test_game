using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBeh : MonoBehaviour
{
    [SerializeField]
    Transform obj;

    float TargetVelocity;

    void Update()
    {
        transform.position = new Vector3(obj.position.x, obj.position.y,transform.position.z);

        SetCamView();
    }

    void SetCamView()     // размер камеры 1.3 => 1
    {
        TargetVelocity = Mathf.Abs(obj.GetComponent<Rigidbody2D>().velocity.x);

        float zoom = Mathf.Clamp(TargetVelocity, 1, 1.3f);
        gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(
            gameObject.GetComponent<Camera>().orthographicSize,
            zoom, Time.deltaTime * 2);
    }
}
