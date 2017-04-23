using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueManager : MonoBehaviour
{
    public TextChanger TextChanger;
    public Text matchesText;

    private Dictionary<int, int> tilesLeft = new Dictionary<int, int>();
    private Dictionary<int, string> tileClues = new Dictionary<int, string>();

    private int currentClue = 0;
    private const int WINNING_TILE_ID = 999;
    private GameObject prizeTile;

    public int AnalyzeMap(MapController mapController)
    {
        int outVal;
        for (int i = 0; i < mapController.Tiles.Length; ++i)
        {
            for (int j = 0; j < mapController.Tiles[i].Length; ++j)
            {
                TileManager tileManager = (TileManager) mapController.Tiles[i][j].GetComponent(typeof(TileManager));

                if (!tileManager.IsRoad && !tileManager.IsPrize && !tileManager.IsDecorationTile)
                {
                    tilesLeft.TryGetValue(tileManager.TileId, out outVal);
                    tilesLeft[tileManager.TileId] = outVal + 1;

                    if (!tileClues.ContainsKey(tileManager.TileId))
                    {
                        tileClues[tileManager.TileId] = tileManager.ClueDescription;
                    }
                }

                if (tileManager.IsPrize)
                {
                    tileManager.gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, 0.01f);
                    prizeTile = tileManager.gameObject;
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

        matchesText.text = tilesLeft[currentClue].ToString();

        outVal-=1;
        if (outVal > 0)
        {
            return currentClue;
        }

        //if outval = 0, change clue
        this.gameObject.GetComponent<AudioSource>().Play();
        return FindNewClue();
    }

    private int FindNewClue()
    {
        foreach (int i in tilesLeft.Keys)
        {
            if (tilesLeft[i] > 0)
            {
                TextChanger.Text(tileClues[i]);
                matchesText.text = tilesLeft[i].ToString();
                currentClue = i;
                Debug.Log("Next clue: " + currentClue);
                return i;
            }
        }

        currentClue = WINNING_TILE_ID;
        matchesText.text = "???";
        TextChanger.Text("Anywhere else to look?");
        prizeTile.GetComponentInChildren<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Debug.Log("Final clue: " + currentClue);
        return currentClue;
    }

    public int GetCurrentClue()
    {
        return currentClue;
    }
}
