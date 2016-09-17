using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Text Player1Key;
    public Text Player2Key;
    public Text Player3Key;
    public Text Player4Key;

    public GameObject Title;
    public GameObject Lobby;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;
    public GameObject CountDown;

    private int WhichPlayer;
    private float DelayTime;

    void Start()
    {
        PlayerPrefs.DeleteAll();
        Player1.SetActive(true);
        Player2.SetActive(false);
        Player3.SetActive(false);
        Player4.SetActive(false);

        WhichPlayer = 1;
        DelayTime = 0;

        Player1Key.text = "";
        Player2Key.text = "";
        Player3Key.text = "";
        Player4Key.text = "";
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
                Player2.SetActive(true);
                CountDown.SetActive(true);
                break;
            case 4:
                Player3.SetActive(true);
                break;
            case 5:
                Player4.SetActive(true);
                break;
            default:
                break;
        }

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
                Debug.Log ((KeyCode)i);
                StoreKey (i);
                ShowKey (i);
                Debug.Log (WhichPlayer);
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

    void ShowKey(int i)
    {
        if (PlayerPrefs.HasKey ("Player1"))
        {
            int Key = PlayerPrefs.GetInt ("Player1");

            Player1Key.text = ((KeyCode)Key).ToString();
        }
        if (PlayerPrefs.HasKey ("Player2"))
        {
            int Key = PlayerPrefs.GetInt ("Player2");

            Player2Key.text = ((KeyCode)Key).ToString();
        }
        if (PlayerPrefs.HasKey ("Player3"))
        {
            int Key = PlayerPrefs.GetInt ("Player3");

            Player3Key.text = ((KeyCode)Key).ToString();
        }
        if (PlayerPrefs.HasKey ("Player4"))
        {
            int Key = PlayerPrefs.GetInt ("Player4");

            Player4Key.text = ((KeyCode)Key).ToString();
        }
    }

    void WaitNextPlayer()
    {
        if (WhichPlayer > 2)
        {
            DelayTime += Time.deltaTime;

            if (DelayTime > 5f)
            {
                SceneManager.LoadScene ("Select");
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
            CountDown.GetComponent<Text>().text = "0";
    }
}
