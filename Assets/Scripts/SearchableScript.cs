using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SearchableScript : MonoBehaviour
{
    private Dictionary<SearchableType, Sprite> map;
    private SearchableType currentType;

    public SearchableType SectionType;

    public Sprite MayanHouse0;
    public Sprite MayanHouse1;
    public Sprite MayanHouse2;
    public Sprite MayanHouse3;
    public Sprite MayanHouse4;
    public Sprite Grass;

    // Use this for initialization
    void Start ()
    {
        map = new Dictionary<SearchableType, Sprite>();
        map[SearchableType.Grass] = Grass;
        map[SearchableType.MayanHouse0] = MayanHouse0;
        map[SearchableType.MayanHouse1] = MayanHouse1;
        map[SearchableType.MayanHouse2] = MayanHouse2;
        map[SearchableType.MayanHouse3] = MayanHouse3;
        map[SearchableType.MayanHouse4] = MayanHouse4;

        UpdateSprite();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (currentType != SectionType)
            UpdateSprite();
    }

    private void UpdateSprite()
    {
        var selectedSprite = map[SectionType];

        GetComponent<SpriteRenderer>().sprite = selectedSprite;
        currentType = SectionType;
    }
}
