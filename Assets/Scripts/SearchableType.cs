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
}
