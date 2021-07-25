using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpiritController : MonoBehaviour
{
    [HideInInspector] public int spiritFragment;
    [HideInInspector] public int diamondScore;
    [HideInInspector] public bool isSpiritPower;
    public AudioClip spiritCollectSound;
    public AudioClip electricSound;
    public AudioClip diamondCollectSound;
    public GameObject spiritShield1;
    public GameObject spiritShield2;
    public GameObject spiritShield3;
    public GameObject spiritShield4;
    public GameObject spiritPower;
    public GameObject diamondImageUI;
    public Animator animator;
    public TMP_Text diamondScoreText;
    public TMP_Text finishGameDiamondText;
    public TMP_Text shopDiamondText;



    private void OnTriggerEnter(Collider other)
    {
        CollectSpiritFragment collectSpiritFragment = other.gameObject.GetComponentInParent<CollectSpiritFragment>();

        if (collectSpiritFragment)
        {
            spiritFragment++;
            AudioSource.PlayClipAtPoint(spiritCollectSound, GameManager.Cam.transform.position);
            Destroy(other.gameObject);
        }
        
        NoGhostObstacle noGhostObstacle = other.gameObject.GetComponentInParent<NoGhostObstacle>();
    
        if (noGhostObstacle)
        {
            if (spiritFragment>0)
            {
                spiritFragment--;
            }
            AudioSource.PlayClipAtPoint(electricSound,GameManager.Cam.transform.position);
        }
        
        CollectDiamond collectDiamond = other.gameObject.GetComponentInParent<CollectDiamond>();
    
        if (collectDiamond)
        {
            diamondScore++;
            StartCoroutine(DiamondScoreAnimation());
            diamondImageUI.GetComponent<Image>().enabled = true;
            Destroy(other.gameObject);
            animator.SetTrigger("DiamondUI");
            
                if (!PlayerPrefs.HasKey("DiamondScore"))
                {
                    PlayerPrefs.SetInt("DiamondScore", diamondScore);
                }

                if (true)
                {
                    PlayerPrefs.SetInt("DiamondScore", 1 + PlayerPrefs.GetInt("DiamondScore"));
                }
        }
    }

    IEnumerator DiamondScoreAnimation()
    {
        yield return new WaitForSeconds(0.2f);
        diamondScoreText.text = diamondScore.ToString();
        finishGameDiamondText.text = diamondScoreText.text;
        AudioSource.PlayClipAtPoint(diamondCollectSound,GameManager.Cam.transform.position);
    }


    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetInt("DiamondScore",5000);
    }


    private void Update()
    {
        SpiritChange();
        shopDiamondText.text = PlayerPrefs.GetInt("DiamondScore").ToString();
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
        if (spiritFragment < 5)
        {
            isSpiritPower = false;
        }
    }
}