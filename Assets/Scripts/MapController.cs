using System;
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
               CreateSearchableTile(SearchableType.Grass, false),
               CreateSearchableTile(SearchableType.Grass, false),
               CreateSearchableTile(SearchableType.Building1, false),
               CreateSearchableTile(SearchableType.Grass, false),
               CreateSearchableTile(SearchableType.Grass, false),
               CreateSearchableTile(SearchableType.Grass, false),
               CreateSearchableTile(SearchableType.MayanHouse2, false),
           },
           new [] {
               CreateSearchableTile(SearchableType.Grass, false),
               CreateRoadTile(RoadSectionType.RoadCornerTopLeft),
               CreateRoadTile(RoadSectionType.RoadHorizontal),
               CreateRoadTile(RoadSectionType.RoadBranchDown),
               CreateRoadTile(RoadSectionType.RoadHorizontal),
               CreateRoadTile(RoadSectionType.RoadCornerTopRight),
               CreateSearchableTile(SearchableType.Grass, false),
           },
           new [] {
               CreateSearchableTile(SearchableType.Grass, false),
               CreateRoadTile(RoadSectionType.RoadVertical),
               CreateSearchableTile(SearchableType.MayanHouse3, true),
               CreateRoadTile(RoadSectionType.RoadVertical),
               CreateSearchableTile(SearchableType.Grass, false),
               CreateRoadTile(RoadSectionType.RoadBranchRight),
               CreateRoadTile(RoadSectionType.RoadCornerTopRight),
           },
           new [] {
               CreateSearchableTile(SearchableType.Grass, false),
               CreateRoadTile(RoadSectionType.RoadBranchRight),
               CreateRoadTile(RoadSectionType.RoadHorizontal),
               CreateRoadTile(RoadSectionType.RoadCross),
               CreateRoadTile(RoadSectionType.RoadHorizontal),
               CreateRoadTile(RoadSectionType.RoadBranchLeft),
               CreateRoadTile(RoadSectionType.RoadVertical),
           },
           new [] {
               CreateSearchableTile(SearchableType.MayanHouse1, false),
               CreateRoadTile(RoadSectionType.RoadVertical),
               CreateSearchableTile(SearchableType.Grass, false),
               CreateRoadTile(RoadSectionType.RoadVertical),
               CreateSearchableTile(SearchableType.MayanHouse4, false),
               CreateRoadTile(RoadSectionType.RoadBranchRight),
               CreateRoadTile(RoadSectionType.RoadCornerBottomRight),
           },
           new [] {
               CreateSearchableTile(SearchableType.Grass, false),
               CreateRoadTile(RoadSectionType.RoadCornerBottomLeft),
               CreateRoadTile(RoadSectionType.RoadHorizontal),
               CreateRoadTile(RoadSectionType.RoadBranchUp),
               CreateRoadTile(RoadSectionType.RoadHorizontal),
               CreateRoadTile(RoadSectionType.RoadCornerBottomRight),
               CreateSearchableTile(SearchableType.Grass, false),
           },
           new [] {
               CreateSearchableTile(SearchableType.Grass, false),
               CreateSearchableTile(SearchableType.Grass, false),
               CreateSearchableTile(SearchableType.Grass, false),
               CreateSearchableTile(SearchableType.Grass, false),
               CreateSearchableTile(SearchableType.Grass, false),
               CreateSearchableTile(SearchableType.MayanHouse0, false),
               CreateSearchableTile(SearchableType.Grass, false),
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

    public GameObject GetTileFromWorldCoordinates(Vector2 position)
    {
        var cellIndex = Convert.ToInt32(position.x);
        var rowPosition = CalculateArrayRowIndex(Convert.ToInt32(position.y));

        if (cellIndex < 0 || cellIndex > Tiles[0].Length - 1 || rowPosition < 0 || rowPosition > Tiles.Length - 1)
        {
            return null;
        }

        return Tiles[rowPosition][cellIndex];
    }

    private int CalculateArrayRowIndex(int xPosition)
    {
        return Tiles.Length - 1 - xPosition;
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

        TileManager tileManager = (TileManager)roadTile.GetComponent(typeof(TileManager));
        tileManager.TileId = (int)sectionType;
        tileManager.IsRoad = true;
        tileManager.IsPrize = false;
        tileManager.IsDecorationTile = false;
        tileManager.ClueDescription = "";

        return roadTile;
    }

    private GameObject CreateSearchableTile(SearchableType sectionType, bool isPrize)
    {
        var tile = (GameObject)Instantiate(Resources.Load("prefabs/SearchableTile"));
        tile.transform.parent = transform;
        tile.GetComponentInChildren<SearchableScript>().SectionType = sectionType;

        TileManager tileManager = (TileManager)tile.GetComponent(typeof(TileManager));
        tileManager.TileId = isPrize ? 999 : (int) sectionType;
        tileManager.IsRoad = false;
        tileManager.IsPrize = isPrize;
        tileManager.IsDecorationTile = sectionType.IsDecoration();
        tileManager.ClueDescription = sectionType.GetClue();

        return tile;
    }
}