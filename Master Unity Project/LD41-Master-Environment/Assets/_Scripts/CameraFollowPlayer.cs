using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollowPlayer : MonoBehaviour {



    //bool top_down = true;
    Transform player;
    
    float target_rotate = 0f;
    float current_rotate = 0f;
    private bool isRotating = false;
    public Text debug_text;

    List<GameObject> current_buildings;
    RaycastHit rch;
    Ray tocam;
    public LayerMask building_mask;
    Transform PlayerFollower;


    private void Start()
    {
        player = GameController.instance.player;
        transform.parent = new GameObject("PlayerFollower-CamerHolder").transform;
        PlayerFollower = transform.parent;
        transform.localPosition = new Vector3(45, 95, -45);
        transform.LookAt(player, Vector3.up);
        target_rotate = 90f;
        current_buildings = new List<GameObject>();
    }

    //public void SetTopDown(bool td)
    //{
    //    if (top_down)
    //    {
    //        if (!td)
    //        {
    //            Camera.main.orthographic = false;

    //            top_down = false;
    //        }
    //    }
    //    else
    //    {

    //    }

    //}

    void Update () {

        transform.parent.position = player.position;
        if (Input.GetKeyDown("q"))
            target_rotate -= 90f;
        else if (Input.GetKeyDown("e"))
            target_rotate += 90f;

        if(target_rotate != current_rotate)
        {
            if(target_rotate > current_rotate)
            {
                if(target_rotate - current_rotate > 5) { transform.parent.RotateAround(player.position, Vector3.up, 5f); current_rotate += 5; }
                else { transform.parent.RotateAround(player.position, Vector3.up, target_rotate - current_rotate); current_rotate += target_rotate - current_rotate; }
            }
            else if (target_rotate < current_rotate)
            {
                if (current_rotate - target_rotate > 5) { transform.parent.RotateAround(player.position, Vector3.up, -5f); current_rotate -= 5; }
                else { transform.parent.RotateAround(player.position, Vector3.up, -(current_rotate - target_rotate)); current_rotate -= current_rotate - target_rotate; }
            }

            transform.LookAt(player, Vector3.up);
            if(debug_text != null)debug_text.text = "Target: " + target_rotate + " Current: " + current_rotate;
        }

        tocam = new Ray(player.position - (Vector3.up*5f) + (player.forward * 5),transform.position - player.position);
        if (Physics.Raycast(tocam,out rch,150f,building_mask))
        {
            rch.collider.gameObject.BroadcastMessage("pingFade");
        }
        else
        {
            tocam = new Ray(player.position - (Vector3.up * 5f) - (player.forward * 5), transform.position - player.position);
            if (Physics.Raycast(tocam, out rch, 150f, building_mask))
            {
                rch.collider.gameObject.BroadcastMessage("pingFade");
            }
        }




    }




}
