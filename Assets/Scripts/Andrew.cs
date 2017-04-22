using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andrew : MonoBehaviour {

    public int MaxX = 3;
    public int MinX = 0;
    public int MaxY = 3;
    public int MinY = 0;

    public ClueManager ClueManager;
    public MapController MapController;


    //int[,] sampleMap = new[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

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
        ClueManager.AnalyzeMap(MapController);
        zonesFound = new bool[MapController.Tiles.GetLength(0), MapController.Tiles.GetLength(1)];
        for ( int i = 0; i < MapController.Tiles.GetLength(0); i++ )
        {
            for ( int j = 0; j < MapController.Tiles.GetLength(1); j++ )
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
        int currentClue = ClueManager.GetCurrentClue();

        // check adjacent map items
        //var map = sampleMap; // MapManager.GetMap();
        int tileUp = playerLocation.Y < MaxY ? GetTileClue(MapController.Tiles[playerLocation.X][playerLocation.Y + 1]) : -1;
        int tileDown = playerLocation.Y > MinY ? GetTileClue(MapController.Tiles[playerLocation.X][playerLocation.Y - 1]) : -1;
        int tileLeft = playerLocation.X > MinX ? GetTileClue(MapController.Tiles[playerLocation.X - 1][playerLocation.Y]): -1;
        int tileRight = playerLocation.X < MaxX ? GetTileClue(MapController.Tiles[playerLocation.X + 1][playerLocation.Y]) : -1;

        // see if any belongs to the clue
        if ( tileUp == currentClue && !zonesFound[playerLocation.X, playerLocation.Y + 1] )
        {
            // mark zone found
            zonesFound[playerLocation.X, playerLocation.Y + 1] = true;
            // change the game object sprite to a different color
            GameObject tileObject = GameObject.Find("test");
            tileObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 0.5f);
            // register zone is found for current clue
            ClueManager.FoundOne(); // reduce counter/go to next clue/win game

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

    private int GetTileClue(GameObject tile)
    {
        TileManager tileManager = (TileManager)tile.GetComponent(typeof(TileManager));
        return tileManager.TileId;
    }
}
