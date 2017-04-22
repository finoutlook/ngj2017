using System.Collections.Generic;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    public TextChanger TextChanger;

    private Dictionary<int, int> tilesLeft = new Dictionary<int, int>();
    private Dictionary<int, string> tileClues = new Dictionary<int, string>();

    private int currentClue = 0;
    

    public int AnalyzeMap(MapController mapController)
    {
        int outVal;
        for (int i = 0; i < mapController.Tiles.Length - 1; ++i)
        {
            for (int j = 0; j < mapController.Tiles[i].Length - 1; ++j)
            {
                TileManager tileManager = (TileManager) mapController.Tiles[i][j].GetComponent(typeof(TileManager));

                if (!tileManager.IsRoad && !tileManager.IsPrize && !tileManager.IsDecorationTile)
                {
                    tilesLeft.TryGetValue(tileManager.TileId, out outVal);
                    tilesLeft[tileManager.TileId] = outVal + 1;
                }
            }
        }

        return FindNewClue();
    }
    
    public int FoundOne()
    {
        int outVal;
        tilesLeft.TryGetValue(currentClue, out outVal);

        if (outVal == 0)
        {
            throw new System.Exception("No more clues left");
        }

        tilesLeft[currentClue] =  outVal - 1;

        outVal-=1;
        if (outVal > 0)
        {
            return currentClue;
        }

        //if outval = 0, change clue
        return FindNewClue();
    }

    private int FindNewClue()
    {
        foreach (int i in tilesLeft.Keys)
        {
            if (tilesLeft[i] > 0)
            {
                TextChanger.Text(tileClues[i]);
                currentClue = i;
                return i;
            }
        }

        return -1;
    }

    public int GetCurrentClue()
    {
        return currentClue;
    }
}
