using System.Collections.Generic;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    public MapController MapController;
    public TextChanger TextChanger;

    private Dictionary<int, int> tilesLeft = new Dictionary<int, int>();
    private Dictionary<int, string> tileClues = new Dictionary<int, string>();
    

    public int AnalyzeMap()
    {
        int outVal;
        for (int i = 0; i < MapController.Tiles.Length - 1; ++i)
        {
            for (int j = 0; j < MapController.Tiles[i].Length - 1; ++j)
            {
                TileManager tileManager = (TileManager) MapController.Tiles[i][j].GetComponent(typeof(TileManager));

                if (!tileManager.IsRoad && !tileManager.IsPrize)
                {
                    tilesLeft.TryGetValue(tileManager.TileId, out outVal);
                    tilesLeft[tileManager.TileId] = outVal + 1;

                    if (!tileClues.ContainsKey(tileManager.TileId))
                    {
                        tileClues.Add(tileManager.TileId, tileManager.ClueDescription);
                    }
                }
            }
        }

        return FindNewClue();
    }
    
    public int FoundOne(int clueId)
    {
        int outVal;
        tilesLeft.TryGetValue(clueId, out outVal);

        if (outVal == 0)
        {
            throw new System.Exception("No more clues left");
        }

        tilesLeft[clueId] =  outVal - 1;

        outVal-=1;
        if (outVal > 0)
        {
            return clueId;
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
                return i;
            }
        }

        return -1;
    }
}
