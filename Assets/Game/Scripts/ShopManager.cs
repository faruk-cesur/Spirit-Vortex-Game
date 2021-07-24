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
    public GameObject redBall;
    public GameObject blueBall;
    public GameObject pinkBall;
    public Material ballMaterial;
    private bool isRedBall = false;
    private bool isBlueBall = false;
    private bool isPinkBall = false;
    public PlayerController player;

    public void Start()
    {
        SetBallPlayerPrefs();
    }

    // Open Shop Window OnClick
    public void ShopUI()
    {
        GameManager.Instance.shopUI.SetActive(true);
    }

    // Return To Game Menu OnClick
    public void ShopBackButton()
    {
        GameManager.Instance.shopUI.SetActive(false);
    }

    // Defining ball skins on shop for keeping on HDD. 
    public void SetBallPlayerPrefs()
    {
        

        if (!PlayerPrefs.HasKey("isRedBall"))
        {
            PlayerPrefs.SetInt("isRedBall", isRedBall ? 1 : 0);
        }

        if (PlayerPrefs.GetInt("isRedBall") == 1 ? true : false)
        {
            redBall.SetActive(true);
        }

        if (!PlayerPrefs.HasKey("isBlueBall"))
        {
            PlayerPrefs.SetInt("isBlueBall", isBlueBall ? 1 : 0);
        }

        if (PlayerPrefs.GetInt("isBlueBall") == 1 ? true : false)
        {
            blueBall.SetActive(true);
        }
        

        if (!PlayerPrefs.HasKey("isPinkBall"))
        {
            PlayerPrefs.SetInt("isPinkBall", isPinkBall ? 1 : 0);
        }

        if (PlayerPrefs.GetInt("isPinkBall") == 1 ? true : false)
        {
            pinkBall.SetActive(true);
        }
        
    }

    // Change the ball skin to Default (black)
    public void BuyDefaultBall()
    {
        ballMaterial.color = Color.black;
        //AudioSource.PlayClipAtPoint(GameManager.Instance.multipleScoreSound,GameManager.Instance.camera.transform.position);
    }
    
    // Change the ball skin color to Red 
    // Checks If The Player has already bought the skin before. If not, purchase it and keep it on HDD.
    public void BuyRedBall()
    {
        if (PlayerPrefs.GetInt("DiamondScore") >= 100)
        {
            if (PlayerPrefs.GetInt("isRedBall") == 0 ? true : false)
            {
                isRedBall = true;
                PlayerPrefs.SetInt("isRedBall", isRedBall ? 1 : 0);
                PlayerPrefs.SetInt("DiamondScore", PlayerPrefs.GetInt("DiamondScore") - 100);
            }
        }

        if (PlayerPrefs.GetInt("isRedBall") == 1 ? true : false)
        {
            redBall.SetActive(true);
            ballMaterial.color = new Color(1, 0, 0, 1);
            //AudioSource.PlayClipAtPoint(GameManager.Instance.multipleScoreSound,GameManager.Cam.transform.position);
        }
    }

    // Change the ball skin color to Blue 
    // Checks If The Player has already bought the skin before. If not, purchase it and keep it on HDD.
    public void BuyBlueBall()
    {
        if (PlayerPrefs.GetInt("DiamondScore") >= 100)
        {
            if (PlayerPrefs.GetInt("isBlueBall") == 0 ? true : false)
            {
                isBlueBall = true;
                PlayerPrefs.SetInt("isBlueBall", isBlueBall ? 1 : 0);
                PlayerPrefs.SetInt("DiamondScore", PlayerPrefs.GetInt("DiamondScore") - 100);
            }
        }

        if (PlayerPrefs.GetInt("isBlueBall") == 1 ? true : false)
        {
            blueBall.SetActive(true);
            ballMaterial.color = new Color(0, 1, 1, 1);
            //AudioSource.PlayClipAtPoint(GameManager.Instance.multipleScoreSound, GameManager.Instance.camera.transform.position);
        }
    }

    

    // Change the ball skin color to Pink 
    // Checks If The Player has already bought the skin before. If not, purchase it and keep it on HDD.
    public void BuyPinkBall()
    {
        if (PlayerPrefs.GetInt("DiamondScore") >= 100)
        {
            if (PlayerPrefs.GetInt("isPinkBall") == 0 ? true : false)
            {
                isPinkBall = true;
                PlayerPrefs.SetInt("isPinkBall", isPinkBall ? 1 : 0);
                PlayerPrefs.SetInt("DiamondScore", PlayerPrefs.GetInt("DiamondScore") - 100);
            }
        }

        if (PlayerPrefs.GetInt("isPinkBall") == 1 ? true : false)
        {
            pinkBall.SetActive(true);
            ballMaterial.color = new Color(1, 0, 1, 1);
           // AudioSource.PlayClipAtPoint(GameManager.Instance.multipleScoreSound, GameManager.Instance.camera.transform.position);
        }
    }
}
