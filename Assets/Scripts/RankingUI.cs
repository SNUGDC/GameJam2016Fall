using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class RankingUI : MonoBehaviour {
	public List<RankingUIElement> elements;

	public void Set(List<Player> players)
	{
		var sortedPlayers = players
			.OrderByDescending(
				player => player.lap * 100 + player.passedCheckpoints.Count
			)
			.ToList();
		for (int i=0; i<sortedPlayers.Count; i++)
		{
			elements[i].Set(sortedPlayers[i]);
		}

		for (int i=sortedPlayers.Count; i<elements.Count; i++)
		{
			elements[i].gameObject.SetActive(false);
		}
	}
}
