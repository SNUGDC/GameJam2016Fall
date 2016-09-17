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
    public TankEnum tankenum;
    public Color color;
    //TODO: public TankType tankType;

    public Player(KeyCode key, TankEnum tankenum, Color color) {
        this.key = key;
        this.tankenum = tankenum;
        this.color = color;
    }

    
    // Variables preserved only under a single level scope.
    public Tank tank; // Better than holding a GameObject IMO
    public int lap;
    public List<Checkpoint> passedCheckpoints;

    public void init(Tank tank) {
        // Initialize variables that are used under a single level scope
        this.tank = tank;
        tank.key = key;
        lap = 1;
        passedCheckpoints = new List<Checkpoint>();
    }
}
