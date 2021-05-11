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
    public float minZ = -1f;
    public float maxZ = -500f;

    void Start()
    {
        Vector3 pos = cam.transform.position;
        Vector3 playerPos = playerLocation.position;
        pos.x = playerPos.x;
        pos.y = playerPos.y;
        pos.z = playerPos.z-3;

        cam.transform.position = pos;
        cam.transform.LookAt(playerLocation);           
    }

    void Update()
    {
        Vector3 pos = cam.transform.position;
        Vector3 playerPos = playerLocation.position;

        pos.x = playerPos.x;
        pos.y = playerPos.y;

        cam.transform.position = pos;

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        pos.z += scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.z = Mathf.Clamp(pos.z, maxZ, minZ);
        transform.position = pos;
    }
}
