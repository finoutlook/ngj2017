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
            default:
                throw new ArgumentOutOfRangeException("type", type, null);
        }
    }
}
