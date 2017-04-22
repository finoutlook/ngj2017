using System;
using System.Collections.Generic;

public enum SearchableType
{
    MayanHouse0 = 1,
    MayanHouse1 = 2,
    MayanHouse2 = 3,
    MayanHouse3 = 4,
    MayanHouse4 = 5,
    Grass = 6,
    Building1 = 7,
    Building2 = 8,
    Building3 = 9,
    Building4 = 10,
    Building5 = 11,
    Building6 = 12,
    Building7 = 13,
    Building8 = 14,
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
            default:
                throw new ArgumentOutOfRangeException("type", type, null);
        }
    }
}
