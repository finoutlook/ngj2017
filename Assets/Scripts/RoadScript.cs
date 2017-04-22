using System.Reflection;
using UnityEngine;

[ExecuteInEditMode]
public class RoadScript : MonoBehaviour
{
    private RoadSectionType currentSectionType;
    
    public RoadSectionType SectionType;

    [Header("Sprites")]
    public Sprite RoadHorizontal;
    public Sprite RoadVertical;
    
    public Sprite RoadCornerTopLeft;
    public Sprite RoadCornerTopRight;
    public Sprite RoadCornerBottomLeft;
    public Sprite RoadCornerBottomRight;
    
    public Sprite RoadBranchDown;
    public Sprite RoadBranchUp;
    public Sprite RoadBranchLeft;
    public Sprite RoadBranchRight;
    
    public Sprite RoadCross;
    
    public Sprite RoadDeadEndUp;
    public Sprite RoadDeadEndDown;
    public Sprite RoadDeadEndLeft;
    public Sprite RoadDeadEndRight;


    public Sprite GetSprite(RoadSectionType sectionType)
    {
        var field = GetType().GetField(sectionType.ToString(), BindingFlags.Instance | BindingFlags.Public);
        var sprite = (Sprite) field.GetValue(this);

        return sprite;
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