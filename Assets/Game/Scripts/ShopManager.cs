using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    // Using Singleton Design Pattern to reach this script everywhere.
    public static ShopManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Variables Defined.
    public PlayerController player;

    public GameObject blackWingSkin;
    public Material blackWingMaterial;

    public GameObject rotorSkin;
    public Material rotorMaterial;

    public GameObject headsetSkin;
    public Material headsetMaterial;

    public Material defaultMaterial;

    private bool _isBlackWingSkin = false;
    private bool _isRotorSkin = false;
    private bool _isHeadsetSkin = false;

    private bool _useBlackWingSkin = false;
    private bool _useRotorSkin = false;
    private bool _useHeadsetSkin = false;
    private bool _useDefaultSkin = false;

    [SerializeField] private GameObject useButton1;
    [SerializeField] private GameObject useButton2;
    [SerializeField] private GameObject useButton3;
    [SerializeField] private GameObject buyButton1;
    [SerializeField] private GameObject buyButton2;
    [SerializeField] private GameObject buyButton3;

    [SerializeField] private AudioClip shopBuySound;
    [SerializeField] private AudioClip shopUseSound;
    [SerializeField] private AudioClip shopBackSound;
    [SerializeField] private AudioClip shopLowCurrencySound;



    public void Start()
    {
        SetPlayerPrefs();
        GetPlayerPrefs();
    }

    // Open Shop Window OnClick
    public void OpenShopUI()
    {
        GameManager.Instance.shopUI.SetActive(true);
        AudioSource.PlayClipAtPoint(shopBuySound, GameManager.Cam.transform.position);
    }

    // Return To Game Menu OnClick
    public void CloseShopUI()
    {
        GameManager.Instance.shopUI.SetActive(false);
        AudioSource.PlayClipAtPoint(shopBackSound, GameManager.Cam.transform.position);
    }

    // Defining ball skins on shop for keeping on HDD. 
    public void SetPlayerPrefs()
    {
        if (!PlayerPrefs.HasKey("isBlackWingSkin"))
        {
            PlayerPrefs.SetInt("isBlackWingSkin", _isBlackWingSkin ? 1 : 0);
        }

        if (PlayerPrefs.GetInt("isBlackWingSkin") == 1 ? true : false)
        {
            if (_useBlackWingSkin)
            {
                blackWingSkin.SetActive(true);
                player.spiritModel.GetComponent<MeshRenderer>().material = blackWingMaterial;
            }
        }

        if (!PlayerPrefs.HasKey("isRotorSkin"))
        {
            PlayerPrefs.SetInt("isRotorSkin", _isRotorSkin ? 1 : 0);
        }

        if (PlayerPrefs.GetInt("isRotorSkin") == 1 ? true : false)
        {
            if (_useRotorSkin)
            {
                rotorSkin.SetActive(true);
                player.spiritModel.GetComponent<MeshRenderer>().material = rotorMaterial;
            }
        }


        if (!PlayerPrefs.HasKey("isHeadsetSkin"))
        {
            PlayerPrefs.SetInt("isHeadsetSkin", _isHeadsetSkin ? 1 : 0);
        }

        if (PlayerPrefs.GetInt("isHeadsetSkin") == 1 ? true : false)
        {
            Debug.Log("1");
            if (_useHeadsetSkin)
            {
                Debug.Log("2");
                headsetSkin.SetActive(true);
                player.spiritModel.GetComponent<MeshRenderer>().material = headsetMaterial;
            }
        }
    }

    public void GetPlayerPrefs()
    {
        if (PlayerPrefs.GetInt("UseDefaultSkin") == 1 ? true : false)
        {
            headsetSkin.SetActive(false);
            rotorSkin.SetActive(false);
            blackWingSkin.SetActive(false);
            player.spiritModel.GetComponent<MeshRenderer>().material = defaultMaterial;
        }

        if (PlayerPrefs.GetInt("UseHeadsetSkin") == 1 ? true : false)
        {
            buyButton1.SetActive(false);
            useButton1.SetActive(true);
            headsetSkin.SetActive(true);
            rotorSkin.SetActive(false);
            blackWingSkin.SetActive(false);
            player.spiritModel.GetComponent<MeshRenderer>().material = headsetMaterial;
        }

        if (PlayerPrefs.GetInt("UseRotorSkin") == 1 ? true : false)
        {
            buyButton2.SetActive(false);
            useButton2.SetActive(true);
            headsetSkin.SetActive(false);
            rotorSkin.SetActive(true);
            blackWingSkin.SetActive(false);
            player.spiritModel.GetComponent<MeshRenderer>().material = rotorMaterial;
        }

        if (PlayerPrefs.GetInt("UseBlackWingSkin") == 1 ? true : false)
        {
            buyButton3.SetActive(false);
            useButton3.SetActive(true);
            headsetSkin.SetActive(false);
            rotorSkin.SetActive(false);
            blackWingSkin.SetActive(true);
            player.spiritModel.GetComponent<MeshRenderer>().material = blackWingMaterial;
        }
        
        if (PlayerPrefs.GetInt("isHeadsetSkin") == 1 ? true : false)
        {
            buyButton1.SetActive(false);
            useButton1.SetActive(true);
        }
        if (PlayerPrefs.GetInt("isRotorSkin") == 1 ? true : false)
        {
            buyButton2.SetActive(false);
            useButton2.SetActive(true);
        }
        if (PlayerPrefs.GetInt("isBlackWingSkin") == 1 ? true : false)
        {
            buyButton3.SetActive(false);
            useButton3.SetActive(true);
        }
    }

    // Change the spirit skin to Default
    public void BuyDefaultMaterial()
    {
        _useHeadsetSkin = false;
        _useRotorSkin = false;
        _useBlackWingSkin = false;
        _useDefaultSkin = true;
        player.spiritModel.GetComponent<MeshRenderer>().material = defaultMaterial;
        blackWingSkin.SetActive(false);
        rotorSkin.SetActive(false);
        headsetSkin.SetActive(false);
        AudioSource.PlayClipAtPoint(shopUseSound, GameManager.Cam.transform.position);
        PlayerPrefs.SetInt("UseHeadsetSkin", _useHeadsetSkin ? 1 : 0);
        PlayerPrefs.SetInt("UseRotorSkin", _useRotorSkin ? 1 : 0);
        PlayerPrefs.SetInt("UseBlackWingSkin", _useBlackWingSkin ? 1 : 0);
        PlayerPrefs.SetInt("UseDefaultSkin", _useDefaultSkin ? 1 : 0);
    }

    // Change the ball skin color to Red 
    // Checks If The Player has already bought the skin before. If not, purchase it and keep it on HDD.
    public void BuyBlackWingSkin()
    {
        if (PlayerPrefs.GetInt("DiamondScore") >= 300)
        {
            if (PlayerPrefs.GetInt("isBlackWingSkin") == 0 ? true : false)
            {
                _isBlackWingSkin = true;
                PlayerPrefs.SetInt("isBlackWingSkin", _isBlackWingSkin ? 1 : 0);
                PlayerPrefs.SetInt("DiamondScore", PlayerPrefs.GetInt("DiamondScore") - 300);
                AudioSource.PlayClipAtPoint(shopBuySound, GameManager.Cam.transform.position);
            }
        }
        else
        {
            AudioSource.PlayClipAtPoint(shopLowCurrencySound, GameManager.Cam.transform.position);
        }

        if (PlayerPrefs.GetInt("isBlackWingSkin") == 1 ? true : false)
        {
            buyButton3.SetActive(false);
            useButton3.SetActive(true);
            _useHeadsetSkin = false;
            _useRotorSkin = false;
            _useBlackWingSkin = true;
            _useDefaultSkin = false;
            blackWingSkin.SetActive(true);
            headsetSkin.SetActive(false);
            rotorSkin.SetActive(false);
            player.spiritModel.GetComponent<MeshRenderer>().material = blackWingMaterial;
            AudioSource.PlayClipAtPoint(shopUseSound, GameManager.Cam.transform.position);

            PlayerPrefs.SetInt("UseHeadsetSkin", _useHeadsetSkin ? 1 : 0);
            PlayerPrefs.SetInt("UseRotorSkin", _useRotorSkin ? 1 : 0);
            PlayerPrefs.SetInt("UseBlackWingSkin", _useBlackWingSkin ? 1 : 0);
            PlayerPrefs.SetInt("UseDefaultSkin", _useDefaultSkin ? 1 : 0);
        }
    }

    // Change the ball skin color to Blue 
    // Checks If The Player has already bought the skin before. If not, purchase it and keep it on HDD.
    public void BuyRotorSkin()
    {
        if (PlayerPrefs.GetInt("DiamondScore") >= 200)
        {
            if (PlayerPrefs.GetInt("isRotorSkin") == 0 ? true : false)
            {
                _isRotorSkin = true;
                PlayerPrefs.SetInt("isRotorSkin", _isRotorSkin ? 1 : 0);
                PlayerPrefs.SetInt("DiamondScore", PlayerPrefs.GetInt("DiamondScore") - 200);
                AudioSource.PlayClipAtPoint(shopBuySound, GameManager.Cam.transform.position);
            }
        }
        else
        {
            AudioSource.PlayClipAtPoint(shopLowCurrencySound, GameManager.Cam.transform.position);
        }

        if (PlayerPrefs.GetInt("isRotorSkin") == 1 ? true : false)
        {
            buyButton2.SetActive(false);
            useButton2.SetActive(true);
            _useHeadsetSkin = false;
            _useBlackWingSkin = false;
            _useRotorSkin = true;
            _useDefaultSkin = false;
            rotorSkin.SetActive(true);
            blackWingSkin.SetActive(false);
            headsetSkin.SetActive(false);
            player.spiritModel.GetComponent<MeshRenderer>().material = rotorMaterial;
            AudioSource.PlayClipAtPoint(shopUseSound, GameManager.Cam.transform.position);


            PlayerPrefs.SetInt("UseHeadsetSkin", _useHeadsetSkin ? 1 : 0);
            PlayerPrefs.SetInt("UseRotorSkin", _useRotorSkin ? 1 : 0);
            PlayerPrefs.SetInt("UseBlackWingSkin", _useBlackWingSkin ? 1 : 0);
            PlayerPrefs.SetInt("UseDefaultSkin", _useDefaultSkin ? 1 : 0);
        }
    }


    // Change the ball skin color to Pink 
    // Checks If The Player has already bought the skin before. If not, purchase it and keep it on HDD.
    public void BuyHeadsetSkin()
    {
        if (PlayerPrefs.GetInt("DiamondScore") >= 100)
        {
            if (PlayerPrefs.GetInt("isHeadsetSkin") == 0 ? true : false)
            {
                _isHeadsetSkin = true;
                PlayerPrefs.SetInt("isHeadsetSkin", _isHeadsetSkin ? 1 : 0);
                PlayerPrefs.SetInt("DiamondScore", PlayerPrefs.GetInt("DiamondScore") - 100);
                AudioSource.PlayClipAtPoint(shopBuySound, GameManager.Cam.transform.position);
            }
        }
        else
        {
            AudioSource.PlayClipAtPoint(shopLowCurrencySound, GameManager.Cam.transform.position);
        }

        if (PlayerPrefs.GetInt("isHeadsetSkin") == 1 ? true : false)
        {
            buyButton1.SetActive(false);
            useButton1.SetActive(true);
            _useHeadsetSkin = true;
            _useRotorSkin = false;
            _useBlackWingSkin = false;
            _useDefaultSkin = false;
            headsetSkin.SetActive(true);
            rotorSkin.SetActive(false);
            blackWingSkin.SetActive(false);
            player.spiritModel.GetComponent<MeshRenderer>().material = headsetMaterial;
            AudioSource.PlayClipAtPoint(shopUseSound, GameManager.Cam.transform.position);

            PlayerPrefs.SetInt("UseHeadsetSkin", _useHeadsetSkin ? 1 : 0);
            PlayerPrefs.SetInt("UseRotorSkin", _useRotorSkin ? 1 : 0);
            PlayerPrefs.SetInt("UseBlackWingSkin", _useBlackWingSkin ? 1 : 0);
            PlayerPrefs.SetInt("UseDefaultSkin", _useDefaultSkin ? 1 : 0);
        }
    }
}