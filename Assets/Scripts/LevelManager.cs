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
        if(players == null) { // For testing
            Player player1 = new Player(KeyCode.Space);
            Player player2 = new Player(KeyCode.Return);
            Player.currentPlayers = new List<Player>() {player1, player2};
            players = Player.currentPlayers;
        }

        for (int i = 0; i < players.Count; i++) {
            Player player = players[i];
            GameObject tankObject = Instantiate(tankPrefab, startingPoints[i].position, startingPoints[i].rotation) as GameObject;
            Tank tank = tankObject.GetComponent<Tank>();
            player.init(tank);
        }
    }

	void Update () {
        // Add checkpoint
	    foreach (Player player in players) {
	        foreach (Checkpoint checkpoint in checkpoints) {
	            if (!player.passedCheckpoints.Contains(checkpoint) && checkpoint.IsTouchingPlayer(player)) {
	                player.passedCheckpoints.Add(checkpoint);
                }
	        }
	    }

	    foreach (Player player in players) {
	        if (goal.IsTouchingPlayer(player) && (player.passedCheckpoints.Count == checkpoints.Count)) {
	            // Reached All checkpoints and returned to goal
	            player.lap += 1;
                player.passedCheckpoints = new List<Checkpoint>();
	        }
	    }
        
	}
}
