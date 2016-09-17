using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartKeyManager : MonoBehaviour
{
	public GameObject NoKeyCode1;
	public GameObject NoKeyCode2;
	public GameObject NoKeyCode3;
	public GameObject NoKeyCode4;
	public Text Player1Key;
	public Text Player2Key;
	public Text Player3Key;
	public Text Player4Key;

	private int WhichPlayer;

	void Start()
	{
		PlayerPrefs.DeleteAll();
		WhichPlayer = 1;

		Player1Key.text = "";
		Player2Key.text = "";
		Player3Key.text = "";
		Player4Key.text = "";
	}

	void Update()
	{
		GetControlKey ();
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
			break;
		case 2:
			if (PlayerPrefs.GetInt ("Player1") == i)
				break;
			PlayerPrefs.SetInt ("Player2", i);
			WhichPlayer = WhichPlayer + 1;
			break;
		case 3:
			if (PlayerPrefs.GetInt ("Player1") == i)
				break;
			else if (PlayerPrefs.GetInt ("Player2") == i)
				break;
			PlayerPrefs.SetInt ("Player3", i);
			WhichPlayer = WhichPlayer + 1;
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
			NoKeyCode1.SetActive (false);
		}
		if (PlayerPrefs.HasKey ("Player2"))
		{
			int Key = PlayerPrefs.GetInt ("Player2");

			Player2Key.text = ((KeyCode)Key).ToString();
			NoKeyCode2.SetActive (false);
		}
		if (PlayerPrefs.HasKey ("Player3"))
		{
			int Key = PlayerPrefs.GetInt ("Player3");

			Player3Key.text = ((KeyCode)Key).ToString();
			NoKeyCode3.SetActive (false);
		}
		if (PlayerPrefs.HasKey ("Player4"))
		{
			int Key = PlayerPrefs.GetInt ("Player4");

			Player4Key.text = ((KeyCode)Key).ToString();
			NoKeyCode4.SetActive (false);
		}
	}
}
