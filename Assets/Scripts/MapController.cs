using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject[][] Tiles;

    // Use this for initialization
    private void Start()
    {
        SetTileCoordinates();
    }

    private void SetTileCoordinates()
    {
        for (var rowIndex = 0; rowIndex < Tiles.Length; rowIndex++)
        {
            var translatedRowIndex = CalculateWorldRowIndex(rowIndex, Tiles.Length);
            for (var cellIndex = 0; cellIndex < Tiles[rowIndex].Length; cellIndex++)
            {
                Debug.Log("r " + rowIndex + ", c " + cellIndex);
                var tile = Tiles[rowIndex][cellIndex];
                Debug.Log(tile.GetComponentInChildren<RoadScript>().SectionType);
                var position = new Vector2(cellIndex, translatedRowIndex);
                Debug.Log("new pos "+ position);

                tile.transform.localPosition = position;
            }
        }
    }

    private float CalculateWorldRowIndex(int rowIndex, int numberOfRows)
    {
        return numberOfRows - rowIndex;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private GameObject CreateRoadTile(RoadSectionType sectionType)
    {
        var roadTile = (GameObject)Instantiate(Resources.Load("prefabs/RoadTile"));
        roadTile.transform.parent = transform;
        roadTile.GetComponentInChildren<RoadScript>().SectionType = sectionType;

        return roadTile;
    }
}