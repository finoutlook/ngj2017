﻿using System;
using System.Collections.Generic;

public enum SearchableType
{
    MayanHouse0 = 1,
    MayanHouse1 = 2,
    MayanHouse2 = 3,
    MayanHouse3 = 4,
    MayanHouse4 = 5,
    Grass = 6,
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
