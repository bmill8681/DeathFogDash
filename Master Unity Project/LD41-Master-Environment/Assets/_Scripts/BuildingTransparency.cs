using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTransparency : MonoBehaviour {

    Material building_mat;
    Material building_tp_mat;
    Material instance_material;
    public bool type1 = false;

    Color color;

    float alpha = 1;
    Coroutine isFading = null;
    MeshRenderer mr;
    public Transform search_transform;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        if (type1)
        {
            int rand = Random.Range(0, 2);
            building_mat = GameController.instance.housecolors[rand];
            building_tp_mat = GameController.instance.housecolors[rand + 3];
            mr.material = building_mat;
        }
        else
        {
            building_mat = GameController.instance.housecolors[2];
            building_tp_mat = GameController.instance.housecolors[5];
            mr.material = building_mat;
        }
    }

    private void Start()
    {
        bool foundroot = false;
        search_transform = transform.parent; 
        while (search_transform.parent != search_transform.root && !foundroot)
        {
            //Debug.Log();
            TileSlot slot = search_transform.parent.GetComponent<TileSlot>();
            if (slot != null && slot.isRoot)
            {
                slot.blocker.houses.Add(this);
                foundroot = true;
            }
            else { search_transform = search_transform.parent; }
        }

        
    }

    public void pingFade()
    {
        if (isFading == null)
        {
            mr.material = building_tp_mat;
            instance_material = mr.material;
            color = instance_material.color;
            isFading = StartCoroutine(Fade());
        }
        alpha -= .03f;
    }


    IEnumerator Fade()
    {
        while (alpha < 1)
        {
            color.a = alpha;
            instance_material.SetColor("_Color", color);
            alpha = Mathf.Clamp(alpha + .01f, 0.4f, 1f);
            yield return null;
            
        }
        mr.material = building_mat;
        isFading = null;
    }

}
