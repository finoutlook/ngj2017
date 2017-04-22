using System.ComponentModel;
using UnityEngine;

[ExecuteInEditMode]
public class RoadScript : MonoBehaviour
{
    private RoadSectionType currentSectionType;
    
    public RoadSectionType SectionType;

    [Header("Sprites")]
    public Sprite CurveLeft;

    public Sprite CurveRight;

    public Sprite CurveFromLeft;

    public Sprite CurveFromRight;

    public Sprite DeadEnd;

    public Sprite DeadEndStart;

    public Sprite FourWayIntersection;

    public Sprite Straight;

    public Sprite StraightCanal;

    public Sprite StraightLake;

    public Sprite StraightRiver;

    public Sprite TStart;

    public Sprite TEnd;

    public Sprite TLeft;

    public Sprite TRight;

    public Sprite GetSprite(RoadSectionType sectionType)
    {
        switch (sectionType)
        {
            case RoadSectionType.Left:
                return CurveLeft;
            case RoadSectionType.Right:
                return CurveRight;
            case RoadSectionType.FromLeft:
                return CurveFromLeft;
            case RoadSectionType.FromRight:
                return CurveFromRight;
            case RoadSectionType.DeadEnd:
                return DeadEnd;
            case RoadSectionType.DeadEndStart:
                return DeadEndStart;
            case RoadSectionType.Straight:
                return Straight;
            case RoadSectionType.TStart:
                return TStart;
            case RoadSectionType.TEnd:
                return TEnd;
            case RoadSectionType.TRight:
                return TRight;
            case RoadSectionType.TLeft:
                return TLeft;
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
            UpdateSprite();
    }

    private void UpdateSprite()
    {
        var selectedSprite = GetSprite(SectionType);

        GetComponent<SpriteRenderer>().sprite = selectedSprite;
        currentSectionType = SectionType;
    }
}