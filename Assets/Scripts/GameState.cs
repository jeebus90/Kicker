using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

    private static int levelReached = 0;

    public static int getLevelReached() {
        return levelReached;
    }

    public static void setLevelReached(int level) {
        levelReached = level;
    }
}
