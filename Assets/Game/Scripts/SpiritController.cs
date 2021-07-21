using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritController : MonoBehaviour
{
    public int spiritFragment;
    public bool isSpiritPower;
    public AudioClip spiritCollectSound;
    public GameObject spiritShield1;
    public GameObject spiritShield2;
    public GameObject spiritShield3;
    public GameObject spiritShield4;
    public GameObject spiritPower;

    private void OnTriggerEnter(Collider other)
    {
        CollectSpiritFragment collectSpiritFragment = other.gameObject.GetComponentInParent<CollectSpiritFragment>();

        if (collectSpiritFragment)
        {
            spiritFragment++;
            AudioSource.PlayClipAtPoint(spiritCollectSound, GameManager.Cam.transform.position);
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        SpiritChange();
    }

    private void SpiritChange()
    {
        if (spiritFragment == 0)
        {
            spiritShield1.SetActive(false);
            spiritShield2.SetActive(false);
            spiritShield3.SetActive(false);
            spiritShield4.SetActive(false);
            spiritPower.SetActive(false);
            isSpiritPower = false;
        }

        if (spiritFragment == 1)
        {
            spiritShield1.SetActive(true);
            spiritShield2.SetActive(false);
            spiritShield3.SetActive(false);
            spiritShield4.SetActive(false);
            spiritPower.SetActive(false);
            isSpiritPower = false;
        }

        if (spiritFragment == 2)
        {
            spiritShield1.SetActive(true);
            spiritShield2.SetActive(true);
            spiritShield3.SetActive(false);
            spiritShield4.SetActive(false);
            spiritPower.SetActive(false);
            isSpiritPower = false;
        }

        if (spiritFragment == 3)
        {
            spiritShield1.SetActive(true);
            spiritShield2.SetActive(true);
            spiritShield3.SetActive(true);
            spiritShield4.SetActive(false);
            spiritPower.SetActive(false);
            isSpiritPower = false;
        }

        if (spiritFragment == 4)
        {
            spiritShield1.SetActive(true);
            spiritShield2.SetActive(true);
            spiritShield3.SetActive(true);
            spiritShield4.SetActive(true);
            spiritPower.SetActive(false);
            isSpiritPower = false;
        }

        if (spiritFragment >= 5)
        {
            spiritShield1.SetActive(true);
            spiritShield2.SetActive(true);
            spiritShield3.SetActive(true);
            spiritShield4.SetActive(true);
            spiritPower.SetActive(true);
            isSpiritPower = true;
        }
    }
}