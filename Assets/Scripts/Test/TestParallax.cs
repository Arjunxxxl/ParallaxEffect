using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestParallax : MonoBehaviour
{
    [SerializeField] private float paralaxMul;
    [SerializeField] private float repeatOffset;
    [SerializeField] private GameObject cam;
    private Vector3 camPos;

    private void Start()
    {
        camPos = cam.transform.position;
    }

    private void LateUpdate()
    {
        Vector3 camMovement = cam.transform.position - camPos;
        transform.position += camMovement * paralaxMul;
        camPos = cam.transform.position;

        if(Mathf.Abs(cam.transform.position.x - transform.position.x) >= repeatOffset)
        {
            float offSetX = (cam.transform.position.x - transform.position.x) % repeatOffset;
            transform.position = new Vector3(cam.transform.position.x + offSetX, transform.position.y, transform.position.z);
        }
    }
}
