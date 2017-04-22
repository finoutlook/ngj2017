using System;
using System.Collections.Generic;

public enum SearchableType
{
    cone_down = 5,
    MayanHouse0 = 11,
    MayanHouse1 = 17,
    barrel_blue = 18,
    barrel_red = 19,
    Building1 = 20,
    Building2 = 21,
    Building3 = 22,
    MayanHouse2 = 23,
    Building4 = 24,
    Building5 = 25,
    Building6 = 26,
    Building7 = 27,
    Building8 = 28,
    MayanHouse3 = 29,
    MayanHouse4 = 30,
    Grass = 31,
    rock2 = 32,
    tree_small = 33
}

public static class SearchableTypeExtensions
{
    public static bool IsDecoration(this SearchableType type)
    {
        List<SearchableType> decorationTiles = new List<SearchableType>() {SearchableType.Grass, SearchableType.tree_small};

        if (decorationTiles.Contains(type))
        {
            return true;
        }

        return false;
    }

    public static string GetClue(this SearchableType type)
    {
        switch (type)
        {
            case SearchableType.MayanHouse0:
                return "Not next to MayanHouse0";
            case SearchableType.MayanHouse1:
                return "Not next to MayanHouse1";
            case SearchableType.MayanHouse2:
                return "Not next to MayanHouse2";
            case SearchableType.MayanHouse3:
                return "Not next to MayanHouse3";
            case SearchableType.MayanHouse4:
                return "Not next to MayanHouse4";
            case SearchableType.Grass:
                return "Not next to Grass";
            case SearchableType.Building1:
                return "Not next to Building1";
            case SearchableType.Building2:
                return "Not next to Building2";
            case SearchableType.Building3:
                return "Not next to Building3";
            case SearchableType.Building4:
                return "Not next to Building4";
            case SearchableType.Building5:
                return "Not next to Building5";
            case SearchableType.Building6:
                return "Not next to Building6";
            case SearchableType.Building7:
                return "Not next to Building7";
            case SearchableType.Building8:
                return "Not next to Building8";
            case SearchableType.barrel_blue:
                return "Not next to barrel_blue";
            case SearchableType.barrel_red:
                return "Not next to barrel_red";
            case SearchableType.tree_small:
                return "Not next to tree_small";
            case SearchableType.rock2:
                return "Not next to rock2";
            case SearchableType.cone_down:
                return "Not next to cone_down";
            default:
                throw new ArgumentOutOfRangeException("type", type, null);
        }
    }
}
