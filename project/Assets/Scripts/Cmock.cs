using UnityEngine;
using System.Collections;

public class Cmock : MonoBehaviour {

    public float minSpeed, maxSpeed;

    Vector2 impulse;
    Rigidbody2D body;

    public Vector2 Impulse{
        set {
            if (value.magnitude < minSpeed)
            {
                impulse = value / value.magnitude * minSpeed;
                return;
            }
            if (value.magnitude > maxSpeed)
            {
                impulse = value / value.magnitude * maxSpeed;
                return;
            }
        }
    }

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        impulse = Vector2.up * minSpeed;
    }

    void FixedUpdate()
    {
        if (body.velocity != impulse)
        {
            body.AddForce((impulse - body.velocity) * 100);
        }
    }

}
