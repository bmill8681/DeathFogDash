﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crates : MonoBehaviour
{
    public GameObject particles;
    public GameObject crates;
    public GameObject fire;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, Random.value * 360, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fire.SetActive(false);
            explode();
        }
    }

    public void explode()
    {
        WordHandler.instance.PlaceRandomLetter(transform);
        AudioManagerScript.instance.playCrateSound();
        StartCoroutine(blowup());
    }

    IEnumerator blowup()
    {
        particles.SetActive(true);
        crates.SetActive(false);
        yield return new WaitForSeconds(.9f);
        Destroy(this.gameObject);
        yield return null;
    }

}
