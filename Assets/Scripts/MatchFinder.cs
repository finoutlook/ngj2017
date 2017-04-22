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

    private Vector2 lastPlayerLocation;
    private GameObject player;

	// Use this for initialization
	void Start () {
        // get player
        player = GameObject.Find("Player");

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
        var playerLocation = MapController.GetTileFromWorldCoordinates(player.transform.position).transform.position;

        // we return if the player location did not change
        if ( playerLocation.Equals( lastPlayerLocation ) )
        {
            return;
        }

        Debug.Log("[MatchFinder] New player location: " + playerLocation);

        int playerX = (int)playerLocation.x;
        int playerY = (int)playerLocation.y;

        // get current clue
        int currentClue = ClueManager.GetCurrentClue();

        // check adjacent map items
        int tileUp = playerY < MaxY ? GetTileClue(MapController.Tiles[playerX][playerY + 1]) : -1;
        int tileDown = playerY > MinY ? GetTileClue(MapController.Tiles[playerX][playerY - 1]) : -1;
        int tileLeft = playerX > MinX ? GetTileClue(MapController.Tiles[playerX - 1][playerY]): -1;
        int tileRight = playerX < MaxX ? GetTileClue(MapController.Tiles[playerX + 1][playerY]) : -1;

        // see if any belongs to the clue
        if ( tileUp == currentClue && !zonesFound[playerX, playerY + 1] )
        {
            Debug.Log("[MatchFinder] Clue match found up");
            ClueTileFound(playerX, playerY + 1);
        }
        if ( tileDown == currentClue )
        {
            Debug.Log("[MatchFinder] Clue match found down");
            ClueTileFound(playerX, playerY - 1);
        }
        if ( tileLeft == currentClue )
        {
            Debug.Log("[MatchFinder] Clue match found left");
            ClueTileFound(playerX - 1, playerY);
        }
        if ( tileRight == currentClue )
        {
            Debug.Log("[MatchFinder] Clue match found right");
            ClueTileFound(playerX + 1, playerY);
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
