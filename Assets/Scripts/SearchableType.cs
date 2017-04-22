using System;
using System.Collections.Generic;

public enum SearchableType
{
    MayanHouse0 = 61,
    MayanHouse1 = 62,
    MayanHouse2 = 63,
    MayanHouse3 = 64,
    MayanHouse4 = 65,
    Grass = 66,
    Building1 = 67,
    Building2 = 68,
    Building3 = 69,
    Building4 = 70,
    Building5 = 71,
    Building6 = 72,
    Building7 = 73,
    Building8 = 74,
    barrel_red = 75,
    barrel_blue = 76,
    tree_small = 77,
    rock2 = 78,
    cone_down = 79
}

public static class SearchableTypeExtensions
{
    public static bool IsDecoration(this SearchableType type)
    {
        List<SearchableType> decorationTiles = new List<SearchableType>() {SearchableType.Grass};

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
