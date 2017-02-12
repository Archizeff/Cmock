using UnityEngine;
using System.Collections;

public class CmockHead : MonoBehaviour {

    public float speed;
    public float maxAngle;

    Vector2 impulse;
    Rigidbody2D body;

    Transform[] Parts;

    public Vector2 Impulse{
        set {
            impulse = value / value.magnitude * speed;
        }
    }

    void Awake()
    {
        impulse = Vector2.up * speed;
        Parts = transform.parent.GetComponentsInChildren<Transform>();
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

        for (int i = 2; i < Parts.Length; i++)
        {
            Transform currPart = Parts[i];
            Transform prevPart = Parts[i-1];

            float dis = Vector3.Distance(prevPart.position, currPart.position);

            Vector3 newPos = prevPart.position;

            float T = (float)(Time.deltaTime * dis / 0.8 * speed);

            currPart.position = Vector3.Slerp(currPart.position, newPos, T);
            currPart.rotation = Quaternion.Slerp(currPart.rotation, prevPart.rotation, T);
        }

    }

}
