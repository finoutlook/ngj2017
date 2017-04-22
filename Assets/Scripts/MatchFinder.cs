using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchFinder : MonoBehaviour {

    public ParticleSystem ParticleSystem;

    public int MaxX = 2;
    public int MinX = 0;
    public int MaxY = 2;
    public int MinY = 0;

    public ClueManager ClueManager;
    public MapController MapController;

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
        Point playerLocation = new Point(0, 1); // MapManager.GetPlayerLocation();

        // we return if the player location did not change
        if ( playerLocation.Equals( lastPlayerLocation ) )
        {
            return;
        }

        // get current clue
        int currentClue = ClueManager.GetCurrentClue();

        // check adjacent map items
        int tileUp = playerLocation.Y < MaxY ? GetTileClue(MapController.Tiles[playerLocation.X][playerLocation.Y + 1]) : -1;
        int tileDown = playerLocation.Y > MinY ? GetTileClue(MapController.Tiles[playerLocation.X][playerLocation.Y - 1]) : -1;
        int tileLeft = playerLocation.X > MinX ? GetTileClue(MapController.Tiles[playerLocation.X - 1][playerLocation.Y]): -1;
        int tileRight = playerLocation.X < MaxX ? GetTileClue(MapController.Tiles[playerLocation.X + 1][playerLocation.Y]) : -1;

        // see if any belongs to the clue
        if ( tileUp == currentClue && !zonesFound[playerLocation.X, playerLocation.Y + 1] )
        {
            ClueTileFound(playerLocation.X, playerLocation.Y + 1);
        }
        if ( tileDown == currentClue )
        {
            ClueTileFound(playerLocation.X, playerLocation.Y - 1);
        }
        if ( tileLeft == currentClue )
        {
            ClueTileFound(playerLocation.X - 1, playerLocation.Y);
        }
        if ( tileRight == currentClue )
        {
            ClueTileFound(playerLocation.X + 1, playerLocation.Y);
        }
    }

    private void ClueTileFound(int x, int y)
    {
        if (ClueManager.GetCurrentClue() == 999)
        {
            SceneManager.LoadScene("Win");
        }
        else
        {
            // mark zone found
            zonesFound[x, y] = true;
            // change the game object sprite to a different color
            GameObject tileObject = MapController.Tiles[x][y];
            tileObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 0.5f);
            if (ParticleSystem != null)
            {
                ParticleSystem.transform.position = tileObject.transform.position;
                ParticleSystem.Emit(20);
            }
            // register zone is found for current clue
            ClueManager.FoundOne(); // reduce counter/go to next clue/win game
        }
    }

    private int GetTileClue(GameObject tile)
    {
        TileManager tileManager = (TileManager)tile.GetComponent(typeof(TileManager));
        return tileManager.TileId;
    }
}
