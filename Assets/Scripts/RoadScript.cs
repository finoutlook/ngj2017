using System.ComponentModel;
using UnityEngine;

[ExecuteInEditMode]
public class RoadScript : MonoBehaviour
{
    public RoadSectionType SectionType;

    [Header("Sprites")]
    public Sprite Curve;

    public Sprite DeadEnd;

    public Sprite FourWayIntersection;

    public Sprite Straight;

    public Sprite StraightCanal;

    public Sprite StraightLake;

    public Sprite StraightRiver;

    public Sprite ThreeWayIntersection;

    private RoadSectionType currentSectionType;

    public enum RoadSectionType
    {
        Straight = 0,

        Curve = 1,

        DeadEnd = 2,

        ThreeWayIntersection = 3,

        FourWayIntersection = 4,

        StraightLake = 5,

        StraightRiver = 6,

        StraightCanal = 7
    }

    public Sprite GetSprite(RoadSectionType sectionType)
    {
        switch (sectionType)
        {
            case RoadSectionType.Curve:
                return Curve;
            case RoadSectionType.DeadEnd:
                return DeadEnd;
            case RoadSectionType.Straight:
                return Straight;
            case RoadSectionType.ThreeWayIntersection:
                return ThreeWayIntersection;
            case RoadSectionType.FourWayIntersection:
                return FourWayIntersection;
            case RoadSectionType.StraightLake:
                return StraightLake;
            case RoadSectionType.StraightRiver:
                return StraightRiver;
            case RoadSectionType.StraightCanal:
                return StraightCanal;
            default:
                throw new InvalidEnumArgumentException(string.Format("Type {0} is not mapped to a sprite.", sectionType));
        }
    }

    // Use this for initialization
    private void Start()
    {
        UpdateSprite();
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentSectionType != SectionType)
        {
            UpdateSprite();
        }
    }

    private void UpdateSprite()
    {
        var selectedSprite = GetSprite(SectionType);

        GetComponent<SpriteRenderer>().sprite = selectedSprite;
        currentSectionType = SectionType;
    }
}
