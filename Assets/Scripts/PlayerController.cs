using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int BorderLeft = 0;

    public int BorderRight = 20;

    public int BorderBottom = 0;

    public int BorderTop = 20;

    private Transform body;

    private MapController mapController;

    private GameObject[][] tiles;

    // Use this for initialization
    void Start ()
    {
        body = transform.Find("Body");
        mapController = GameObject.FindObjectOfType<MapController>();
        tiles = mapController.Tiles;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            move(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            move(Vector3.right);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            move(Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            move(Vector3.down);
        }
    }

    private void move(Vector3 RelDirection)
    {

        var newPosition = transform.position + RelDirection * 1;
        var x = Mathf.Clamp(newPosition.x, BorderLeft, BorderRight);
        var y = Mathf.Clamp(newPosition.y, BorderBottom, BorderTop);

        var newVector3 = new Vector3(x, y, 0);
        var sectionTypeAhead = GetRoadSectionType(newVector3);

        // Forget moving if there is no roadsection
        if (sectionTypeAhead == null)
        {
            return;
        }

        if (CanIGoThere(RelDirection, sectionTypeAhead))
        {
            transform.position = newVector3;
            Face(RelDirection);
        }
        else
        {
            // car crash
            print("Player Collision Detect");
        }
    }

    private void Face(Vector3 RelDirection)
    {
        var roadSectionType = GetRoadSectionType(transform.position);
        var angle = GetAngle(RelDirection, roadSectionType);
        body.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private int GetAngle(Vector3 RelDirection, RoadSectionType? roadSectionType)
    {
        int angle = 0;

        if (RelDirection == Vector3.left)
        {
            switch (roadSectionType)
            {
                case RoadSectionType.RoadCornerTopLeft:
                    angle = -45;
                    break;
                case RoadSectionType.RoadCornerBottomLeft:
                    angle = -135;
                    break;
                default:
                    angle = -90;
                    break;
            }
        }
        else if (RelDirection == Vector3.right)
        {
            switch (roadSectionType)
            {
                case RoadSectionType.RoadCornerTopRight:
                    angle = 45;
                    break;
                case RoadSectionType.RoadCornerBottomRight:
                    angle = 135;
                    break;
                default:
                    angle = 90;
                    break;
            }
        }
        else if (RelDirection == Vector3.up)
        {
            switch (roadSectionType)
            {
                case RoadSectionType.RoadCornerTopRight:
                    angle = 225;
                    break;
                case RoadSectionType.RoadCornerTopLeft:
                    angle = 135;
                    break;
                default:
                    angle = 180;
                    break;
            }
        }
        else if (RelDirection == Vector3.down)
        {
            switch (roadSectionType)
            {
                case RoadSectionType.RoadCornerBottomLeft:
                    angle = 45;
                    break;
                case RoadSectionType.RoadCornerBottomRight:
                    angle = -45;
                    break;
                default:
                    angle = 0;
                    break;
            }
        }

        return angle;
    }

    private bool CanIGoThere(Vector3 RelDirection, RoadSectionType? roadSectionType)
    {
        if (RelDirection == Vector3.left)
        {
            switch (roadSectionType)
            {
                case RoadSectionType.RoadCornerTopLeft:
                case RoadSectionType.RoadCornerBottomLeft:
                case RoadSectionType.RoadHorizontal:
                case RoadSectionType.RoadCross:
                case RoadSectionType.RoadDeadEndLeft:
                case RoadSectionType.RoadBranchRight:
                case RoadSectionType.RoadBranchDown:
                case RoadSectionType.RoadBranchUp:
                    return true;
                default:
                    return false;
            }
        }
        else if (RelDirection == Vector3.right)
        {
            switch (roadSectionType)
            {
                case RoadSectionType.RoadCornerTopRight:
                case RoadSectionType.RoadCornerBottomRight:
                case RoadSectionType.RoadHorizontal:
                case RoadSectionType.RoadCross:
                case RoadSectionType.RoadDeadEndRight:
                case RoadSectionType.RoadBranchLeft:
                case RoadSectionType.RoadBranchDown:
                case RoadSectionType.RoadBranchUp:
                    return true;
                default:
                    return false;
            }
        }
        else if (RelDirection == Vector3.up)
        {
            switch (roadSectionType)
            {
                case RoadSectionType.RoadCornerTopRight:
                case RoadSectionType.RoadCornerTopLeft:
                case RoadSectionType.RoadVertical:
                case RoadSectionType.RoadCross:
                case RoadSectionType.RoadDeadEndUp:
                case RoadSectionType.RoadBranchRight:
                case RoadSectionType.RoadBranchLeft:
                case RoadSectionType.RoadBranchDown:
                    return true;
                default:
                    return false;
            }
        }
        else if (RelDirection == Vector3.down)
        {
            switch (roadSectionType)
            {
                case RoadSectionType.RoadCornerBottomLeft:
                case RoadSectionType.RoadCornerBottomRight:
                case RoadSectionType.RoadVertical:
                case RoadSectionType.RoadCross:
                case RoadSectionType.RoadDeadEndDown:
                case RoadSectionType.RoadBranchRight:
                case RoadSectionType.RoadBranchLeft:
                case RoadSectionType.RoadBranchUp:
                    return true;
                default:
                    return false;
            }
        }

        return false;
    }

    private RoadSectionType? GetRoadSectionType(Vector3 position)
    {
        var myTile = mapController.GetTileFromWorldCoordinates(position);
        if (myTile == null)
        {
            return null;
        }

        var myTileManager = myTile.GetComponentInChildren<TileManager>() as TileManager;
        if (myTileManager == null || !myTileManager.IsRoad)
        {
            return null;
        }

        var myTileScript = myTile.GetComponentInChildren<RoadScript>();
        if (myTileScript == null)
        {
            return null;
        }
        
        return myTileScript.SectionType;
    }
}
