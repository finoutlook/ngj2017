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

    private Vector3 lastPlayerLocation;
    private GameObject player;

	// Use this for initialization
	void Start () {
        // get player
        player = GameObject.Find("Player");

        ClueManager.AnalyzeMap(MapController);
        zonesFound = new bool[MapController.Tiles.Length, MapController.Tiles[0].Length];
        for ( int i = 0; i < MapController.Tiles.Length; i++ )
        {
            for ( int j = 0; j < MapController.Tiles[0].Length; j++ )
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

        lastPlayerLocation = playerLocation;

        Debug.Log("[MatchFinder] New player location: " + playerLocation);

        int playerX = (int)playerLocation.x;
        int playerY = (int)playerLocation.y;

        // get current clue
        int currentClue = ClueManager.GetCurrentClue();

        // check adjacent map items
        var upTile = GetTileManager(MapController.GetTileFromWorldCoordinates(player.transform.position + Vector3.up/*MapController.Tiles[playerX][playerY + 1]*/));
        var downTile = GetTileManager(MapController.GetTileFromWorldCoordinates(player.transform.position + Vector3.down/*MapController.Tiles[playerX][playerY - 1]*/));
        var leftTile = GetTileManager(MapController.GetTileFromWorldCoordinates(player.transform.position + Vector3.left/*MapController.Tiles[playerX - 1][playerY]*/));
        var rightTile = GetTileManager(MapController.GetTileFromWorldCoordinates(player.transform.position + Vector3.right/*MapController.Tiles[playerX + 1][playerY]*/));

        int tileUp = playerY < MaxY ? upTile.TileId : -1;
        int tileDown = playerY > MinY ? downTile.TileId : -1;
        int tileLeft = playerX > MinX ? leftTile.TileId : -1;
        int tileRight = playerX < MaxX ? rightTile.TileId : -1;
        
        // see if any belongs to the clue
        if ( tileUp == currentClue && !upTile.IsFound )
        {
            Debug.Log("[MatchFinder] Clue match found up");
            ClueTileFound(upTile.gameObject);
            upTile.IsFound = true;
        }
        if ( tileDown == currentClue && !downTile.IsFound )
        {
            Debug.Log("[MatchFinder] Clue match found down");
            ClueTileFound(downTile.gameObject);
            downTile.IsFound = true;
        }
        if ( tileLeft == currentClue && !leftTile.IsFound )
        {
            Debug.Log("[MatchFinder] Clue match found left");
            ClueTileFound(leftTile.gameObject);
            leftTile.IsFound = true;
        }
        if ( tileRight == currentClue && !rightTile.IsFound )
        {
            Debug.Log("[MatchFinder] Clue match found right");
            ClueTileFound(rightTile.gameObject);
            rightTile.IsFound = true;
        }
    }

    private void ClueTileFound(GameObject tileObject)
    {
        if (ClueManager.GetCurrentClue() == 999)
        {
            SceneManager.LoadScene("Win");
        }
        else
        {
            // change the game object sprite to a different color
            tileObject.GetComponentInChildren<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 0.5f);
            if (ParticleSystem != null)
            {
                ParticleSystem.transform.position = tileObject.transform.position + new Vector3(0.5f, 0.5f, 0f);
                ParticleSystem.Emit(20);
            }
            // register zone is found for current clue
            ClueManager.FoundOne(); // reduce counter/go to next clue/win game
        }
    }

    private TileManager GetTileManager(GameObject tile)
    {
        TileManager tileManager = (TileManager)tile.GetComponent(typeof(TileManager));
        return tileManager;
    }
}
