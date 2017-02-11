using UnityEngine;
using System.Collections;

public class CmockHead : MonoBehaviour {

    public float speed;
    public float maxAngle;

    Vector2 impulse;
    Rigidbody2D body;

    public Vector2 Impulse{
        set {
            impulse = value / value.magnitude * speed;
        }
    }

    void Awake()
    {
        impulse = Vector2.up * speed;
    }

    void Start()
    {

    }

    void FixedUpdate()
    {

        transform.Translate(Vector2.up * Time.deltaTime * speed);

        float impulseAngle = Mathf.Atan2(-impulse.x, impulse.y) / Mathf.PI * 180;
        float currentAngle = transform.rotation.eulerAngles.z;

        if (impulseAngle != currentAngle) {
            float deltaAngle = impulseAngle - currentAngle;

            if (deltaAngle > 180)
                deltaAngle -= 360;

            if (deltaAngle < -180)
                deltaAngle += 360;

            if (Mathf.Abs(deltaAngle) > maxAngle)
                deltaAngle = deltaAngle / Mathf.Abs(deltaAngle) * maxAngle;

        	transform.Rotate(0, 0, deltaAngle);
        }

    }

}
