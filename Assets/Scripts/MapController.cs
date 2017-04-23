using System;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject[][] Tiles;

    private int[][] mapArray = GetSmallMap();
    

    private static int[][] GetSmallMap()
    {
        return new int[][]
         {
             new int[] { 33,33,21,21,21,21,21,21,21,21,21,21,21,21,21,21,21,21,21,21,21,21,31,31,31,31,31,31,31,31,31,31,31,31,31,31,31,33,33,33},
             new int[] { 33,1,16,16,16,16,0,16,16,16,0,16,16,16,16,16,16,16,16,16,16,16,12,25,25,33,33,25,33,26,33,26,26,33,26,26,31,1,12,33    },
             new int[] { 21,3,24,24,32,24,3,24,33,21,3,28,28,21,21,32,21,21,21,21,21,21,8,16,16,16,16,0,16,16,16,16,16,16,16,0,16,4,3,33        },
             new int[] { 21,3,24,31,33,1,9,16,16,16,13,21,33,33,33,33,33,33,33,33,33,33,33,33,33,25,25,3,31,33,26,33,26,33,33,3,33,32,3,32      },
             new int[] { 21,3,32,31,1,4,32,32,33,24,3,21,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,3,33,31,31,31,31,31,33,3,33,32,3,32       },
             new int[] { 24,3,24,33,3,33,31,31,31,33,3,33,24,28,28,28,28,28,33,33,33,33,33,33,33,33,25,3,33,31,31,33,26,26,32,3,33,32,3,32      },
             new int[] { 24,3,33,33,3,33,24,24,33,24,7,16,16,16,16,16,16,16,16,16,12,33,33,33,33,33,25,3,26,31,26,1,16,6,32,3,33,32,3,32        },
             new int[] { 24,3,32,1,9,16,16,16,16,16,13,33,24,28,28,28,28,28,33,28,3,33,33,33,33,33,33,3,33,33,33,3,33,26,31,8,0,16,4,32         },
             new int[] { 33,7,16,4,24,24,24,24,33,33,3,24,31,33,33,33,28,1,16,16,13,33,33,20,33,20,20,3,33,31,33,3,26,31,31,33,3,31,33,33       },
             new int[] { 31,3,24,31,31,31,31,31,31,33,3,24,33,33,33,33,28,3,25,25,8,16,16,16,16,16,16,13,33,33,26,3,26,31,31,26,3,31,31,31      },
             new int[] { 33,3,32,32,31,24,24,24,33,24,3,33,31,31,31,33,33,3,25,31,28,25,31,33,33,25,25,3,26,33,26,3,33,27,27,27,3,27,33,31      },
             new int[] { 33,8,0,16,16,16,16,16,16,16,14,16,16,0,16,16,16,13,31,25,25,25,31,31,31,31,26,3,26,33,26,7,16,16,16,16,14,16,12,31     },
             new int[] { 31,33,3,24,33,33,31,24,33,24,3,33,20,3,33,31,31,8,16,0,16,16,16,12,31,33,26,3,26,31,33,3,33,27,27,27,3,27,3,27         },
             new int[] { 31,33,3,22,31,31,31,31,31,24,3,20,33,3,20,33,33,31,31,3,33,31,33,3,31,33,31,8,12,31,26,3,27,31,31,33,3,27,3,27         },
             new int[] { 31,33,3,22,31,31,31,31,31,33,3,20,33,8,12,31,33,32,33,3,32,31,33,3,31,33,33,26,3,27,33,3,33,31,27,1,4,27,3,27          },
             new int[] { 31,33,3,32,24,24,33,24,33,33,3,20,33,20,3,33,32,1,16,9,16,12,33,3,25,33,33,26,7,16,16,4,31,31,27,3,27,27,3,27          },
             new int[] { 31,1,9,16,16,16,16,16,16,16,13,31,33,33,3,20,32,3,32,32,32,3,32,3,31,33,31,33,3,33,27,27,31,31,33,3,27,27,3,27         },
             new int[] { 33,3,33,24,24,24,33,33,33,24,3,20,20,33,3,20,32,3,32,23,32,3,32,3,25,31,26,1,4,27,27,33,33,27,27,3,27,27,3,27          },
             new int[] { 22,15,33,31,31,31,33,33,31,31,8,16,16,16,4,33,32,8,16,16,16,4,33,8,16,16,16,9,16,16,16,16,16,16,16,9,16,16,4,31        },
             new int[] { 33,31,33,31,31,31,33,33,33,33,33,20,20,20,31,31,31,32,32,32,32,32,31,31,31,31,33,33,33,33,27,27,27,27,27,27,27,27,33,31},

         };
    }

    private static int[][] GetBigMap()
    {
        return new int[][]
         {
            new int[] { 31, 31, 33, 33, 21, 33, 33, 21, 21, 31, 33, 21, 33, 33, 33, 33, 21, 33, 31, 21, 33, 31, 31, 31, 31, 31, 31, 31, 31, 31, 31, 31, 31, 31, 31, 31, 31, 30, 23, 17, 17, 11, 11, 29, 23, 17, 17, 11, 23, 31 },
            new int[] { 31, 1, 16, 16, 16, 16, 0, 16, 16, 16, 0, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 12, 25, 25, 33, 33, 25, 33, 31, 33, 26, 26, 33, 31, 31, 23, 1, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 12, 17 },
            new int[] { 21, 3, 24, 24, 32, 24, 3, 24, 33, 31, 3, 28, 28, 33, 33, 32, 31, 33, 33, 31, 33, 31, 8, 16, 16, 16, 16, 0, 16, 16, 16, 16, 16, 16, 16, 16, 0, 4, 17, 17, 29, 17, 23, 17, 11, 11, 11, 17, 3, 23 },
            new int[] { 33, 3, 24, 31, 33, 1, 9, 16, 16, 16, 13, 33, 31, 31, 31, 31, 31, 31, 31, 31, 31, 31, 31, 33, 33, 25, 25, 3, 31, 32, 26, 32, 26, 32, 32, 29, 3, 23, 31, 17, 11, 11, 17, 23, 17, 17, 31, 17, 3, 29 },
            new int[] { 33, 3, 5, 2, 0, 4, 32, 32, 33, 24, 3, 31, 31, 31, 31, 31, 31, 31, 31, 31, 31, 31, 31, 31, 31, 31, 33, 3, 33, 31, 31, 31, 31, 31, 31, 33, 3, 11, 17, 2, 16, 16, 16, 0, 16, 6, 29, 11, 3, 11 },
            new int[] { 24, 3, 24, 33, 3, 33, 31, 31, 31, 33, 3, 33, 24, 31, 33, 21, 33, 31, 31, 33, 31, 31, 31, 31, 31, 31, 25, 3, 33, 31, 31, 33, 26, 31, 31, 29, 3, 11, 31, 23, 17, 23, 30, 3, 11, 23, 31, 11, 3, 23 },
            new int[] { 24, 3, 33, 33, 3, 33, 24, 24, 33, 24, 7, 16, 16, 16, 16, 16, 16, 16, 16, 16, 12, 31, 31, 31, 31, 31, 25, 3, 31, 31, 26, 1, 16, 6, 5, 31, 3, 11, 23, 29, 17, 23, 17, 3, 11, 31, 31, 17, 3, 11 },
            new int[] { 24, 3, 32, 1, 9, 16, 16, 16, 16, 16, 13, 33, 24, 33, 33, 33, 21, 31, 33, 31, 3, 33, 31, 31, 31, 31, 33, 3, 33, 31, 31, 3, 33, 26, 31, 31, 7, 16, 16, 16, 16, 16, 16, 13, 30, 17, 23, 29, 3, 11 },
            new int[] { 33, 7, 16, 13, 24, 24, 24, 24, 33, 33, 3, 24, 31, 31, 31, 31, 31, 1, 16, 16, 13, 33, 33, 20, 31, 20, 20, 3, 33, 31, 31, 3, 26, 31, 31, 33, 3, 31, 28, 33, 11, 11, 23, 8, 16, 0, 16, 16, 4, 11 },
            new int[] { 31, 3, 24, 15, 31, 31, 31, 31, 31, 33, 3, 24, 31, 31, 31, 31, 31, 3, 25, 25, 8, 16, 16, 16, 16, 16, 16, 13, 33, 31, 33, 3, 26, 31, 31, 31, 3, 5, 2, 16, 16, 16, 12, 31, 33, 3, 17, 11, 23, 31 },
            new int[] { 33, 3, 32, 5, 31, 24, 24, 24, 33, 24, 3, 33, 21, 31, 21, 33, 33, 3, 25, 31, 31, 25, 31, 33, 33, 25, 25, 3, 31, 31, 26, 3, 33, 27, 27, 31, 3, 31, 28, 33, 28, 28, 3, 28, 31, 3, 33, 28, 31, 31 },
            new int[] { 33, 8, 0, 16, 16, 16, 16, 16, 16, 16, 14, 16, 16, 0, 16, 16, 16, 13, 31, 25, 25, 25, 31, 31, 31, 31, 31, 3, 31, 31, 26, 7, 16, 16, 16, 16, 14, 16, 16, 12, 31, 31, 8, 12, 31, 8, 16, 16, 12, 31 },
            new int[] { 31, 33, 3, 24, 33, 33, 31, 24, 33, 24, 3, 33, 31, 3, 33, 31, 31, 8, 16, 0, 16, 16, 16, 12, 31, 31, 33, 3, 26, 31, 33, 3, 33, 27, 33, 33, 3, 28, 33, 3, 33, 31, 33, 3, 31, 31, 31, 33, 3, 28 },
            new int[] { 31, 33, 3, 22, 31, 31, 31, 31, 31, 24, 3, 31, 21, 3, 21, 31, 31, 31, 31, 3, 33, 31, 33, 3, 31, 31, 31, 8, 12, 31, 26, 3, 27, 31, 31, 33, 3, 33, 33, 3, 33, 31, 28, 3, 28, 31, 31, 28, 3, 33 },
            new int[] { 31, 33, 3, 22, 31, 31, 31, 31, 31, 33, 3, 20, 31, 8, 12, 31, 31, 31, 33, 3, 31, 31, 33, 3, 31, 31, 26, 26, 3, 27, 33, 3, 33, 31, 27, 1, 4, 31, 28, 3, 28, 31, 28, 3, 33, 31, 28, 31, 3, 33 },
            new int[] { 31, 33, 3, 32, 24, 24, 33, 24, 33, 33, 3, 20, 31, 21, 3, 33, 31, 31, 1, 9, 12, 31, 33, 3, 25, 5, 2, 16, 14, 16, 16, 4, 31, 31, 27, 3, 27, 31, 1, 4, 31, 31, 33, 7, 16, 16, 6, 5, 3, 33 },
            new int[] { 31, 1, 9, 16, 16, 16, 16, 16, 16, 16, 13, 31, 31, 33, 3, 31, 31, 31, 3, 5, 3, 31, 31, 3, 31, 31, 31, 33, 3, 33, 27, 31, 31, 31, 33, 3, 31, 33, 3, 33, 31, 28, 1, 4, 31, 28, 28, 31, 3, 33 },
            new int[] { 33, 3, 33, 24, 24, 24, 33, 33, 33, 24, 3, 27, 31, 33, 3, 20, 31, 31, 8, 16, 4, 31, 32, 3, 25, 31, 31, 1, 4, 31, 31, 31, 31, 31, 33, 3, 33, 31, 3, 28, 31, 28, 3, 31, 31, 31, 31, 33, 3, 33 },
            new int[] { 22, 3, 33, 31, 31, 5, 31, 31, 31, 31, 3, 27, 31, 33, 3, 33, 31, 31, 31, 31, 31, 31, 33, 3, 33, 31, 26, 3, 33, 31, 32, 33, 31, 33, 31, 3, 27, 31, 8, 12, 31, 33, 3, 33, 33, 31, 28, 33, 3, 31 },
            new int[] { 33, 3, 33, 31, 31, 10, 20, 31, 31, 20, 3, 27, 31, 33, 3, 20, 31, 31, 31, 31, 31, 31, 31, 7, 16, 16, 16, 14, 16, 16, 16, 16, 16, 16, 16, 9, 12, 31, 33, 3, 31, 1, 9, 16, 16, 16, 16, 16, 4, 31 },
            new int[] { 31, 3, 31, 31, 20, 7, 16, 16, 16, 16, 9, 12, 31, 21, 3, 33, 31, 31, 31, 31, 31, 33, 1, 4, 31, 31, 26, 3, 33, 31, 33, 31, 33, 31, 31, 33, 3, 31, 33, 3, 28, 3, 28, 28, 28, 5, 28, 28, 31, 31 },
            new int[] { 33, 3, 31, 31, 31, 3, 33, 32, 33, 22, 33, 3, 31, 21, 3, 20, 20, 33, 31, 31, 31, 20, 3, 26, 31, 31, 31, 3, 26, 31, 31, 31, 31, 31, 31, 33, 3, 31, 33, 3, 28, 8, 12, 31, 31, 10, 31, 31, 5, 31 },
            new int[] { 31, 3, 31, 31, 20, 3, 32, 31, 31, 33, 22, 3, 31, 31, 8, 16, 16, 16, 12, 31, 31, 33, 3, 26, 31, 31, 26, 3, 31, 31, 31, 31, 33, 33, 33, 27, 3, 27, 28, 3, 31, 28, 3, 31, 31, 3, 28, 28, 10, 28 },
            new int[] { 32, 3, 33, 31, 22, 3, 31, 31, 31, 1, 16, 4, 31, 31, 31, 33, 33, 31, 3, 25, 1, 16, 9, 16, 12, 31, 26, 3, 33, 31, 33, 1, 16, 16, 16, 16, 9, 16, 16, 13, 33, 33, 3, 28, 28, 7, 16, 16, 13, 33 },
            new int[] { 18, 3, 32, 31, 32, 3, 33, 31, 33, 3, 33, 31, 31, 31, 31, 31, 31, 33, 3, 33, 3, 31, 31, 31, 3, 31, 31, 3, 33, 31, 31, 3, 33, 31, 33, 31, 31, 33, 28, 8, 16, 16, 9, 16, 16, 4, 28, 33, 3, 33 },
            new int[] { 19, 3, 18, 19, 19, 3, 33, 31, 1, 4, 31, 31, 31, 31, 31, 31, 31, 20, 3, 25, 3, 31, 31, 26, 3, 26, 32, 3, 20, 20, 33, 3, 33, 31, 31, 28, 31, 31, 31, 31, 33, 28, 28, 33, 31, 5, 31, 31, 3, 33 },
            new int[] { 19, 7, 16, 16, 16, 13, 33, 22, 3, 33, 31, 31, 31, 31, 31, 31, 31, 20, 7, 16, 4, 31, 5, 2, 9, 16, 16, 9, 16, 16, 16, 9, 16, 16, 16, 16, 12, 31, 31, 31, 31, 31, 31, 28, 28, 28, 31, 33, 3, 33 },
            new int[] { 18, 3, 19, 18, 19, 3, 22, 22, 3, 33, 21, 31, 33, 21, 31, 33, 33, 33, 3, 31, 33, 31, 33, 26, 31, 26, 33, 33, 33, 33, 31, 32, 32, 32, 31, 33, 3, 33, 28, 31, 28, 1, 16, 16, 16, 16, 16, 16, 4, 28 },
            new int[] { 19, 15, 19, 31, 31, 8, 16, 16, 9, 16, 16, 16, 16, 16, 16, 16, 16, 16, 9, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 9, 16, 16, 16, 16, 4, 33, 28, 33, 28, 33, 33, 28, 31 },
            new int[] { 31, 5, 31, 31, 31, 33, 31, 20, 31, 33, 33, 33, 33, 31, 31, 33, 31, 20, 20, 20, 20, 20, 31, 31, 31, 33, 31, 20, 33, 33, 33, 31, 20, 31, 20, 31, 28, 33, 33, 28, 28, 28, 31, 31, 31, 31, 31, 31, 31, 31 },
        };
    }

    // Use this for initialization
    private void Start()
    {
        CreateMap();

        SetTileCoordinates();
    }

    private readonly List<int> NonSearchableIds = new List<int>
    {
        (int)RoadSectionType.RoadBranchDown,
        (int)RoadSectionType.RoadCornerTopLeft,
        (int)RoadSectionType.RoadDeadEndLeft,
        (int)RoadSectionType.RoadVertical,
        (int)RoadSectionType.RoadCornerBottomRight,
        (int)RoadSectionType.RoadDeadEndRight,
        (int)RoadSectionType.RoadBranchRight,
        (int)RoadSectionType.RoadCornerBottomLeft,
        (int)RoadSectionType.RoadBranchUp,
        (int)RoadSectionType.RoadDeadEndUp,
        (int)RoadSectionType.RoadCornerTopRight,
        (int)RoadSectionType.RoadBranchLeft ,
        (int)RoadSectionType.RoadCross,
        (int)RoadSectionType.RoadDeadEndDown ,
        (int)RoadSectionType.RoadHorizontal
    };
    
    private void CreateMap()
    {
        Tiles = new GameObject[mapArray.Length][];
        for (int i = 0; i < mapArray.Length; i++)
        {
            Tiles[i] = new GameObject[mapArray[0].Length];
            for (int j = 0; j < mapArray[0].Length; j++)
            {
                if (NonSearchableIds.Contains(mapArray[i][j]))
                {
                    Tiles[i][j] = CreateRoadTile((RoadSectionType)mapArray[i][j]);
                }
                else
                {
                    Tiles[i][j] = CreateSearchableTile((SearchableType)mapArray[i][j]);
                }
            }
        }
        
    }

    private void SetTileCoordinates()
    {
        for (var rowIndex = 0; rowIndex < Tiles.Length; rowIndex++)
        {
            var translatedRowIndex = CalculateWorldRowIndex(rowIndex, Tiles.Length);
            for (var cellIndex = 0; cellIndex < Tiles[rowIndex].Length; cellIndex++)
            {
                var tile = Tiles[rowIndex][cellIndex];
                if (!tile)
                {
                    continue;
                }

                var position = new Vector2(cellIndex, translatedRowIndex);
                tile.transform.localPosition = position;
            }
        }
    }

    public GameObject GetTileFromWorldCoordinates(Vector2 position)
    {
        var cellIndex = Convert.ToInt32(position.x);
        var rowPosition = CalculateArrayRowIndex(Convert.ToInt32(position.y));

        if (cellIndex < 0 || cellIndex > Tiles[0].Length - 1 || rowPosition < 0 || rowPosition > Tiles.Length - 1)
        {
            return null;
        }

        return Tiles[rowPosition][cellIndex];
    }

    private int CalculateArrayRowIndex(int xPosition)
    {
        return Tiles.Length - 1 - xPosition;
    }

    private float CalculateWorldRowIndex(int rowIndex, int numberOfRows)
    {
        return numberOfRows - rowIndex - 1;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private GameObject CreateRoadTile(RoadSectionType sectionType)
    {
        var roadTile = (GameObject)Instantiate(Resources.Load("prefabs/RoadTile"));
        roadTile.transform.parent = transform;
        roadTile.GetComponentInChildren<RoadScript>().SectionType = sectionType;

        TileManager tileManager = (TileManager)roadTile.GetComponent(typeof(TileManager));
        tileManager.TileId = (int)sectionType;
        tileManager.IsRoad = true;
        tileManager.IsPrize = false;
        tileManager.IsDecorationTile = false;
        tileManager.ClueDescription = "";

        return roadTile;
    }

    private GameObject CreateSearchableTile(SearchableType sectionType)
    {
        var tile = (GameObject)Instantiate(Resources.Load("prefabs/SearchableTile"));
        tile.transform.parent = transform;
        tile.GetComponentInChildren<SearchableScript>().SectionType = sectionType;

        TileManager tileManager = (TileManager)tile.GetComponent(typeof(TileManager));
        tileManager.TileId = (int) sectionType;

        tileManager.IsRoad = false;
        tileManager.IsPrize = false;

        if ( sectionType == SearchableType.MayanHouse2 )
        {
            tileManager.TileId = 999;
            tileManager.IsPrize = true;
        }
        tileManager.IsDecorationTile = sectionType.IsDecoration();
        tileManager.ClueDescription = sectionType.GetClue();

        return tile;
    }
}