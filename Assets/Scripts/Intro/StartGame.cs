using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Text[] PlayerKey;

    public GameObject Title;
    public GameObject Lobby;
    public GameObject[] Players;
    public GameObject CountDown;

    public Sprite[] TankSprite;
    public Image[] TankImage;
    public int[] Key;
    public int[] WhichTank;

    private int WhichPlayer;
    private float DelayTime;

    void Start()
    {
        Player.currentPlayers = new List<Player>();

        PlayerPrefs.DeleteAll();
        Players[0].SetActive(true);
        Players[1].SetActive(false);
        Players[2].SetActive(false);
        Players[3].SetActive(false);

        WhichPlayer = 1;
        DelayTime = 0;

        PlayerKey[0].text = "";
        PlayerKey[1].text = "";
        PlayerKey[2].text = "";
        PlayerKey[3].text = "";
    }

	void Update()
	{
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Debug.Log("Credit");
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Game 끔");
        }
        else
            GetControlKey ();

        switch (WhichPlayer)
        {
            case 2:
                Title.SetActive(false);
                Lobby.GetComponent<RectTransform>().position = new Vector3(990, 540, 0);
                break;
            case 3:
                Players[1].SetActive(true);
                CountDown.SetActive(true);
                break;
            case 4:
                Players[2].SetActive(true);
                break;
            case 5:
                Players[3].SetActive(true);
                break;
            default:
                break;
        }

        ShowKey();
        ChangeTank();
        WaitNextPlayer ();
        ShowCountDown();
	}

    KeyCode GetControlKey()
    {
        int e = System.Enum.GetNames(typeof(KeyCode)).Length;
        for(int i = 0; i < e; i++)
        {
            if(Input.GetKeyDown((KeyCode)i))
            {
                StoreKey (i);
                return (KeyCode)i;
            }
        }
        return KeyCode.None;
    }

    void StoreKey(int i)
    {
        switch (WhichPlayer)
        {
            case 1:
                PlayerPrefs.SetInt ("Player1", i);
                WhichPlayer = WhichPlayer + 1;
                DelayTime = 0;
                break;
            case 2:
                if (PlayerPrefs.GetInt ("Player1") == i)
                    break;
                PlayerPrefs.SetInt ("Player2", i);
                WhichPlayer = WhichPlayer + 1;
                DelayTime = 0;
                break;
            case 3:
                if (PlayerPrefs.GetInt ("Player1") == i)
                    break;
                else if (PlayerPrefs.GetInt ("Player2") == i)
                    break;
                PlayerPrefs.SetInt ("Player3", i);
                WhichPlayer = WhichPlayer + 1;
                DelayTime = 0;
                break;
            case 4:
                if (PlayerPrefs.GetInt ("Player1") == i)
                    break;
                else if (PlayerPrefs.GetInt ("Player2") == i)
                    break;
                else if (PlayerPrefs.GetInt ("Player3") == i)
                    break;
                PlayerPrefs.SetInt ("Player4", i);
                WhichPlayer = WhichPlayer + 1;
                DelayTime = 0;
                break;
            default:
                break;
        }
    }

    void ShowKey()
    {
        if (PlayerPrefs.HasKey ("Player1"))
        {
            Key[0] = PlayerPrefs.GetInt ("Player1");

            PlayerKey[0].text = ((KeyCode)Key[0]).ToString();
        }
        if (PlayerPrefs.HasKey ("Player2"))
        {
            Key[1] = PlayerPrefs.GetInt ("Player2");

            PlayerKey[1].text = ((KeyCode)Key[1]).ToString();
        }
        if (PlayerPrefs.HasKey ("Player3"))
        {
            Key[2] = PlayerPrefs.GetInt ("Player3");

            PlayerKey[2].text = ((KeyCode)Key[2]).ToString();
        }
        if (PlayerPrefs.HasKey ("Player4"))
        {
            Key[3] = PlayerPrefs.GetInt ("Player4");

            PlayerKey[3].text = ((KeyCode)Key[3]).ToString();
        }
    }

    void ChangeTank()
    {
        if (PlayerPrefs.HasKey("Player1"))
        {
            if (Input.GetKeyDown((KeyCode)Key[0]))
            {
                int i = WhichTank[0] % 5;

                TankImage[0].sprite = TankSprite[i];
                WhichTank[0] += 1;
                DelayTime = 0;
            }
        }
        if (PlayerPrefs.HasKey("Player2"))
        {
            if (Input.GetKeyDown((KeyCode)Key[1]))
            {
                int i = WhichTank[1] % 5;

                TankImage[1].sprite = TankSprite[i];
                WhichTank[1] += 1;
                DelayTime = 0;
            }
        }
        if (PlayerPrefs.HasKey("Player3"))
        {
            if (Input.GetKeyDown((KeyCode)Key[2]))
            {
                int i = WhichTank[2] % 5;

                TankImage[2].sprite = TankSprite[i];
                WhichTank[2] += 1;
                DelayTime = 0;
            }
        }
        if (PlayerPrefs.HasKey("Player4"))
        {
            if (Input.GetKeyDown((KeyCode)Key[3]))
            {
                int i = WhichTank[3] % 5;

                TankImage[3].sprite = TankSprite[i];
                WhichTank[3] += 1;
                DelayTime = 0;
            }
        }
    }

    void WaitNextPlayer()
    {
        if (WhichPlayer > 2)
        {
            DelayTime += Time.deltaTime;

            if (DelayTime > 5f)
            {
                Debug.Log("Next Scene");
            }
        }
    }

    void ShowCountDown()
    {
        if (5 - DelayTime > 4f)
            CountDown.GetComponent<Text>().text = "5";
        else if (5 - DelayTime > 3f)
            CountDown.GetComponent<Text>().text = "4";
        else if (5 - DelayTime > 2f)
            CountDown.GetComponent<Text>().text = "3";
        else if (5 - DelayTime > 1f)
            CountDown.GetComponent<Text>().text = "2";
        else if (5 - DelayTime > 0f)
            CountDown.GetComponent<Text>().text = "1";
        else
        {
            CountDown.GetComponent<Text>().text = "0";

            for (int i = 1; i < WhichPlayer; i++)
            {
                Player player = new Player((KeyCode)Key[i - 1], (TankEnum)(WhichTank[i - 1] % 5));
                Player.currentPlayers.Add(player);
                Debug.Log(i);
            }

            SceneManager.LoadScene("Main");
        }
    }
}
