using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject[][] Tiles;

    // Use this for initialization
    private void Start()
    {
        CreateMap();

        SetTileCoordinates();
    }

    private void CreateMap()
    {
        Tiles = new[]
        {
           new [] {
               CreateRoadTile(RoadSectionType.RoadCornerTopLeft),
               CreateRoadTile(RoadSectionType.RoadHorizontal),
               CreateRoadTile(RoadSectionType.RoadBranchDown),
               CreateRoadTile(RoadSectionType.RoadHorizontal),
               CreateRoadTile(RoadSectionType.RoadCornerTopRight),
           },
           new [] {
               CreateRoadTile(RoadSectionType.RoadVertical),
               null,
               CreateRoadTile(RoadSectionType.RoadVertical),
               null,
               CreateRoadTile(RoadSectionType.RoadVertical),
           },
           new [] {
               CreateRoadTile(RoadSectionType.RoadBranchRight),
               CreateRoadTile(RoadSectionType.RoadHorizontal),
               CreateRoadTile(RoadSectionType.RoadCross),
               CreateRoadTile(RoadSectionType.RoadHorizontal),
               CreateRoadTile(RoadSectionType.RoadBranchLeft),
           },
           new [] {
               CreateRoadTile(RoadSectionType.RoadVertical),
               CreateSearchableTile(SearchableType.Grass),
               CreateRoadTile(RoadSectionType.RoadVertical),
               null,
               CreateRoadTile(RoadSectionType.RoadVertical),
           },
           new [] {
               CreateRoadTile(RoadSectionType.RoadCornerBottomLeft),
               CreateRoadTile(RoadSectionType.RoadHorizontal),
               CreateRoadTile(RoadSectionType.RoadBranchUp),
               CreateRoadTile(RoadSectionType.RoadHorizontal),
               CreateRoadTile(RoadSectionType.RoadCornerBottomRight),
           },
        };
    }

    private void SetTileCoordinates()
    {
        for (var rowIndex = 0; rowIndex < Tiles.Length; rowIndex++)
        {
            var translatedRowIndex = CalculateWorldRowIndex(rowIndex, Tiles.Length);
            for (var cellIndex = 0; cellIndex < Tiles[rowIndex].Length; cellIndex++)
            {
                var tile = Tiles[rowIndex][cellIndex];
                if (!tile)
                {
                    continue;
                }

                var position = new Vector2(cellIndex, translatedRowIndex);
                tile.transform.localPosition = position;
            }
        }
    }

    private float CalculateWorldRowIndex(int rowIndex, int numberOfRows)
    {
        return numberOfRows - rowIndex - 1;
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

    private GameObject CreateSearchableTile(SearchableType sectionType)
    {
        var tile = (GameObject)Instantiate(Resources.Load("prefabs/SearchableTile"));
        tile.transform.parent = transform;
        tile.GetComponentInChildren<SearchableScript>().SectionType = sectionType;

        return tile;
    }
}