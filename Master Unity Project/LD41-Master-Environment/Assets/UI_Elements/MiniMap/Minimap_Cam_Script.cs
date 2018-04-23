using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap_Cam_Script : MonoBehaviour {

    
    Transform playerPos;
    public float cam_height = 10.0f;
    private float zoomDistance = 13f;
    public float dist_forward = 6f;
    private Camera miniCam;
    private void Awake()
    {
        miniCam = this.GetComponent<Camera>();
        miniCam.orthographic = true;
        setMiniCamZoom();
        playerPos = GameController.instance.player;
    }

    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(playerPos.position.x, cam_height, playerPos.position.z) + (playerPos.forward*dist_forward);
        //transform.rotation = Quaternion.Euler(90f, Camera.main.transform.eulerAngles.y,0);
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
