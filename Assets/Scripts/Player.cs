// Player script to hold all information about a player
// plus the list of ALL current players via Player.currentPlayers
// (alternative was to make a PlayerManager just to hold all players).
// 
// Note the two different level of variable scoping,
// one preserved throught the levels,
// and one preserved only under a single level.
// They are both handled here for code simplicity and organization.

using System.Collections.Generic;
using UnityEngine;

public class Player {
    public static List<Player> currentPlayers; // list of all current players
    
    // Variables preserved from when players are selected to result phase
    public KeyCode key;
    //TODO: public TankType tankType;

    public Player(KeyCode key) {
        this.key = key;
    }


    // Variables preserved only under a single level scope.
    public TrainScript tank; // Better than holding a GameObject IMO
    public int lap;
    public List<Checkpoint> passedCheckpoints;

    public void init() {
        // Initialize variables that are used under a single level scope
        //TODO: this.tank = tank;
        lap = 0;
        passedCheckpoints = new List<Checkpoint>();
    }
}
