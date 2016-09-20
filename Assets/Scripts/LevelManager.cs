using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    public GameObject tankPrefab;
    public GameObject checkpointsObject; // Assumes this has Checkpoints for children
    public GameObject startingPointsObject; // Assumes this has transforms of starting points for children
    private List<Checkpoint> checkpoints; // Because Gameobjects are easier to edit than List<> in editor
    private List<Transform> startingPoints;
    private Checkpoint goal;
    private List<Player> players;
    private RankingUI rankingUI;
    private ResultUI resultUI;
    private bool gameEnd = false;

    public static int GoalLap = 3;
    
    void Awake ()
    {
        checkpoints = new List<Checkpoint>();
        foreach (Transform childTransform in checkpointsObject.transform){
            checkpoints.Add(childTransform.gameObject.GetComponent<Checkpoint>());
        }
        goal = checkpoints[0]; // Assumes that first checkpoint is goal
        
        startingPoints = new List<Transform>();
        foreach (Transform childTransform in startingPointsObject.transform)
        {
            startingPoints.Add(childTransform);
            childTransform.gameObject.SetActive(false);
        }

        players = Player.currentPlayers;

        if (players == null || players.Count == 0)
        {
            Debug.LogError("There is no player, use temporary player");
            players = new List<Player>()
            {
                new Player(KeyCode.A, TankEnum.Centurion, new Color(1f,1f,1f,1f)),
                new Player(KeyCode.S, TankEnum.CV33, new Color(1f,1f,1f,1f))
            };
        }

        for (int i = 0; i < players.Count; i++) {
            Player player = players[i];
            GameObject tankObject = Instantiate(Tank.tankEnumToPrefab(player.tankenum), startingPoints[i].position, startingPoints[i].rotation) as GameObject;
            Tank tank = tankObject.GetComponent<Tank>();
            tank.GetComponent<SpriteRenderer>().color = player.color;
            player.init(tank);
        }

        rankingUI = FindObjectOfType<RankingUI>();
        rankingUI.Set(players);
        resultUI = FindObjectOfType<ResultUI>();
        resultUI.gameObject.SetActive(false);
    }

	void Update () {
        if (gameEnd)
        {
            return;
        }
        // Add checkpoint
	    
        bool needRankingUpdate = false;
        foreach (Player player in players) {
	        foreach (Checkpoint checkpoint in checkpoints) {
	            if (!player.passedCheckpoints.Contains(checkpoint) && checkpoint.IsTouchingPlayer(player)) {
	                player.passedCheckpoints.Add(checkpoint);
                    Debug.Log("Player " + player.key + " add checkpoint");
                    needRankingUpdate = true;
                }
	        }
	    }
        rankingUI.Set(players);

	    foreach (Player player in players) {
	        if (goal.IsTouchingPlayer(player) && (player.passedCheckpoints.Count == checkpoints.Count)) {
	            // Reached All checkpoints and returned to goal
	            if (player.lap == GoalLap)
	            {
	                Debug.Log(player.ToString() + " WINS!!");
                    resultUI.Set(player);
                    gameEnd = true;
                    // Time.timeScale = 0;
                    break;
	            }
	            else
	            {
                    player.lap += 1;
                    player.passedCheckpoints = new List<Checkpoint>();
                    Debug.Log(player.ToString() + " Lap " + player.lap.ToString());
                }
	        }
        }

        if (gameEnd)
        {
            foreach (Player player in players)
            {
                player.tank.enabled = false;
                player.tank.GetComponent<TankShoot>().enabled = false;
            }
        }
	    
    }
}
