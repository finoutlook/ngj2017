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
    public Sprite Building1;
    public Sprite Building2;
    public Sprite Building3;
    public Sprite Building4;
    public Sprite Building5;
    public Sprite Building6;
    public Sprite Building7;
    public Sprite Building8;
    public Sprite barrel_red;
    public Sprite barrel_blue;
    public Sprite tree_small;
    public Sprite rock2;
    public Sprite cone_down;

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
        map[SearchableType.Building1] = Building1;
        map[SearchableType.Building2] = Building2;
        map[SearchableType.Building3] = Building3;
        map[SearchableType.Building4] = Building4;
        map[SearchableType.Building5] = Building5;
        map[SearchableType.Building6] = Building6;
        map[SearchableType.Building7] = Building7;
        map[SearchableType.Building8] = Building8;

        map[SearchableType.barrel_blue] = barrel_blue;
        map[SearchableType.barrel_red] = barrel_red;
        map[SearchableType.tree_small] = tree_small;
        map[SearchableType.rock2] = rock2;
        map[SearchableType.cone_down] = cone_down;

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
