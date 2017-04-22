using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andrew : MonoBehaviour {

    public int MaxX = 3;
    public int MinX = 0;
    public int MaxY = 3;
    public int MinY = 0;

    public ClueManager ClueManager;


    int[,] sampleMap = new[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

    bool[,] zonesFound;

    private Point lastPlayerLocation;

    private struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X;
        public int Y;
    }


	// Use this for initialization
	void Start () {
        var map = sampleMap; // MapManager.GetMap();
        //var clueId = ClueManager.AnalyzeMap(map??)
        zonesFound = new bool[map.GetLength(0), map.GetLength(1)];
        for ( int i = 0; i < map.GetLength(0); i++ )
        {
            for ( int j = 0; j < map.GetLength(1); j++ )
            {
                zonesFound[i, j] = false;
            }
        }
	}

	// Update is called once per frame
	void Update () {

        // get player location in our map grid
        Point playerLocation = new Point(0, 3); // MapManager.GetPlayerLocation();

        // we return if the player location did not change
        if ( playerLocation.Equals( lastPlayerLocation ) )
        {
            return;
        }

        // get current clue
        int currentClue = 3; // ClueManager.GetCurrentClue();

        // check adjacent map items
        var map = sampleMap; // MapManager.GetMap();
        int tileUp = playerLocation.Y < MaxY ? map[playerLocation.X, playerLocation.Y + 1] : -1;
        int tileDown = playerLocation.Y > MinY ? map[playerLocation.X, playerLocation.Y - 1] : -1;
        int tileLeft = playerLocation.X > MinX ? map[playerLocation.X - 1, playerLocation.Y] : -1;
        int tileRight = playerLocation.X < MaxX ? map[playerLocation.X + 1, playerLocation.Y] : -1;

        // see if any belongs to the clue
        if ( tileUp == currentClue && !zonesFound[playerLocation.X, playerLocation.Y + 1] )
        {
            // mark zone found
            zonesFound[playerLocation.X, playerLocation.Y + 1] = true;
            // change the game object sprite to a different color
            GameObject tileObject = GameObject.Find("test");
            tileObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 0.5f);
            // register zone is found for current clue
            //ClueManager.FoundOne(); // reduce counter/go to next clue/win game

        }
        if ( tileDown == currentClue )
        {

        }
        if ( tileLeft == currentClue )
        {

        }
        if ( tileRight == currentClue )
        {

        }
    }


}
