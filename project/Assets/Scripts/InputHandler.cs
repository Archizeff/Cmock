using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class InputHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public Rigidbody2D cmock;
    public float speed = 1f;

    Vector2 startPosition;

    public void OnPointerDown(PointerEventData eventData)
    {
        startPosition = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        cmock.GetComponent<Cmock>().Impulse = (eventData.position - startPosition) * speed;
    }
}
