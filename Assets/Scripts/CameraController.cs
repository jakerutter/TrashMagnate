using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public GameObject cam;
    public Transform playerLocation;
    public float scrollSpeed = 1f;
    private float zoomLevel;
    public float minY = 1f;
    public float maxY = 100;

    void Start()
    {
        Vector3 pos = cam.transform.position;
        Vector3 playerPos = playerLocation.position;
        pos.x = playerPos.x;
        pos.y = playerPos.y+1;
        pos.z = playerPos.z-2;

        cam.transform.position = pos;
        cam.transform.LookAt(playerLocation);           
    }

    void Update()
    {
        Vector3 pos = cam.transform.position;
        Vector3 playerPos = playerLocation.position;

        pos.x = playerPos.x;
        pos.z = playerPos.z-2;

        cam.transform.position = pos;

        // float scroll = Input.GetAxis("Mouse ScrollWheel");

        // pos.y += scroll * 1000 * scrollSpeed * Time.deltaTime;
        // pos.y = Mathf.Clamp(pos.y, maxY, minY);
        // transform.position = pos;
    }
}
