using System;
using System.ComponentModel;
using UnityEngine;

public class RoadSectionScript : MonoBehaviour
{
    public string Section;

    private GameObject[] tiles;

    private void CreateSection()
    {
        tiles = new GameObject[Section.Length];
        for (var i = 0; i < Section.Length; i++)
        {
            var sectionType = Section[i];
            RoadScript.RoadSectionType type;
            switch (sectionType)
            {
                case 's':
                    type = RoadScript.RoadSectionType.Straight;
                    break;
                case 'c':
                    type = RoadScript.RoadSectionType.Curve;
                    break;
                case 'd':
                    type = RoadScript.RoadSectionType.DeadEnd;
                    break;
                case 't':
                    type = RoadScript.RoadSectionType.ThreeWayIntersection;
                    break;
                case 'x':
                    type = RoadScript.RoadSectionType.FourWayIntersection;
                    break;
                case 'l':
                    type = RoadScript.RoadSectionType.StraightLake;
                    break;
                case 'r':
                    type = RoadScript.RoadSectionType.StraightRiver;
                    break;
                case 'C':
                    type = RoadScript.RoadSectionType.StraightCanal;
                    break;
                default:
                    throw new InvalidEnumArgumentException(string.Format("Section type {0} not mapped.", sectionType));
            }

            var tile = (GameObject)Instantiate(Resources.Load("Prefabs/RoadTile"));
            Debug.Log(tile.transform.position);
            tile.transform.parent = transform;
            Debug.Log(tile.transform.position);
            //tile.transform.localPosition = Vector3.zero;
            //tile.transform.position = new Vector2(0, i - 1);
            Debug.Log(tile.transform.position);
            tile.GetComponent<RoadScript>().SectionType = type;

            tiles[i] = tile;
        }
    }

    // Use this for initialization
    private void Start()
    {
        CreateSection();
    }
}
