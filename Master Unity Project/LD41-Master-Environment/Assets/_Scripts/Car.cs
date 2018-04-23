using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

    public GameObject particles;
    public GameObject carmesh;

    private void Start()
    {
        carmesh.transform.rotation = Quaternion.Euler(0, Random.value * 360, 0);
    }

    public void explode()
    {
        AudioManagerScript.instance.playDestructionSound();
        StartCoroutine(blowup());
    }

    IEnumerator blowup()
    {
        particles.SetActive(true);
        carmesh.SetActive(false);
        yield return new WaitForSeconds(.9f);
        Destroy(this.gameObject);
        yield return null;
    }
}
