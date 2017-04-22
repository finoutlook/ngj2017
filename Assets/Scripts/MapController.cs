using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject[][] Tiles;

    // Use this for initialization
    private void Start()
    {
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