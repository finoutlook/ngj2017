using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject[][] Tiles;

    // Use this for initialization
    private void Start()
    {
        CreateMap();
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
               null,
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

    // Update is called once per frame
    private void Update()
    {
    }

    private GameObject CreateRoadTile(RoadSectionType sectionType)
    {
        return (GameObject)Instantiate(Resources.Load("prefabs/RoadTile"));
    }
}