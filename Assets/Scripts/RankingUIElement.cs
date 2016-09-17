using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RankingUIElement : MonoBehaviour {
	public Text playerName;
	public Text circleCount;

	private Player player;

	public void Set(Player player)
	{
		this.player = player;
		playerName.text = "\"" + player.key + "\"";
	}

	void Update()
	{
		if (player == null)
		{
			return;
		}
		circleCount.text = player.lap + "/" + LevelManager.GoalLap;
	}
}