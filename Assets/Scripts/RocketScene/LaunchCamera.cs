using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchCamera : MonoBehaviour
{

    public GameObject target;
    public int cameraID;
    public float panSpeed = 80f;
    public float scrollSpeed = 5;
    public float minY = 40f;
    public float maxY = 250f;
    Vector3 cameraPosition;
    bool playerInput = false;

    void Start()
    {
        cameraPosition = transform.position;
    }

    void Update()
    {

            //ground camera just looks at
            if(cameraID == 0){
                transform.LookAt(target.transform);
            //ssky camera follows on y axis and looks at
            } else if (cameraID == 1){
                Vector3 newPosition = transform.position;
                newPosition.y = target.transform.position.y + 50f;
                //cameraPosition.y = target.transform.position.y + 50f;
                gameObject.transform.position = newPosition;
                transform.LookAt(target.transform);
            }

        if(Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime,  Space.World);
        }
        if(Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime,  Space.World);
        }
        if(Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime,  Space.World);
        }
        if(Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime,  Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        
        transform.position = pos;
    }
}
