using System.ComponentModel;
using UnityEngine;

public class RoadSectionScript : MonoBehaviour
{
    public string Section;

    private void CreateSection()
    {
        foreach (Transform tile in transform)
        {
            Destroy(tile.gameObject);
        }

        var sectionParts = Section.Split(',');

        for (var i = 0; i < sectionParts.Length; i++)
        {
            var sectionType = sectionParts[i];
            RoadSectionType type;
            switch (sectionType)
            {
                case "s":
                    type = RoadSectionType.Straight;
                    break;
                case "l":
                    type = RoadSectionType.Left;
                    break;
                case "r":
                    type = RoadSectionType.Right;
                    break;
                case "fr":
                    type = RoadSectionType.FromRight;
                    break;
                case "fl":
                    type = RoadSectionType.FromLeft;
                    break;
                case "start":
                    type = RoadSectionType.DeadEndStart;
                    break;
                case "end":
                    type = RoadSectionType.DeadEnd;
                    break;
                case "ts":
                    type = RoadSectionType.TStart;
                    break;
                case "te":
                    type = RoadSectionType.TEnd;
                    break;
                case "tl":
                    type = RoadSectionType.TLeft;
                    break;
                case "tr":
                    type = RoadSectionType.TRight;
                    break;
                case "x":
                    type = RoadSectionType.FourWayIntersection;
                    break;
                case "sl":
                    type = RoadSectionType.StraightLake;
                    break;
                case "sr":
                    type = RoadSectionType.StraightRiver;
                    break;
                case "sc":
                    type = RoadSectionType.StraightCanal;
                    break;
                default:
                    throw new InvalidEnumArgumentException(string.Format("Section type {0} not mapped.", sectionType));
            }

            var tile = (GameObject) Instantiate(Resources.Load("Prefabs/RoadTile"));
            tile.transform.parent = transform;
            tile.transform.localPosition = Vector3.zero;
            tile.transform.localPosition = new Vector2(0, i - 1);
            tile.GetComponent<RoadScript>().SectionType = type;
        }
    }

    // Use this for initialization
    private void Start()
    {
        CreateSection();
    }
}