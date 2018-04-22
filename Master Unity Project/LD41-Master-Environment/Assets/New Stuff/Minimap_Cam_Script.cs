using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap_Cam_Script : MonoBehaviour {

    public Transform playerPos;
    public float cam_height = 10.0f;
    private float zoomDistance = 13f;
    private Camera miniCam;
    private void Awake()
    {
        miniCam = this.GetComponent<Camera>();
        miniCam.orthographic = true;
        setMiniCamZoom();
    }

    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(playerPos.position.x, cam_height, playerPos.position.z);
        transform.rotation = Quaternion.Euler(90f, Camera.main.transform.eulerAngles.y,0);
	}

    public void setMiniCamZoom(float zoom) // Use this to set minimap camera zoom level from settings menu
    {
        miniCam.orthographicSize = zoom;
    }

    public void setMiniCamZoom()
    {
        miniCam.orthographicSize = zoomDistance;
    }
}
