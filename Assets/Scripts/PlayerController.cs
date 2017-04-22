using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 0.5f;

    private Transform body;

    private MapController mapController;

    private GameObject[][] tiles;

    private bool isDriving = false;

    private Vector3 departureTile;

    private Vector3 arrivalTile;

    private Vector3 thrust;

    private float travelTime;

    private float departureAngle;

    private float arrivalAngle;

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
        if (!isDriving)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                TryDrive(Vector3.left);
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                TryDrive(Vector3.right);
            }
            else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                TryDrive(Vector3.up);
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                TryDrive(Vector3.down);
            }
        }
        else
        {
            AutoDrive();
        }
    }

    private void AutoDrive()
    {
        travelTime += Time.deltaTime;
        if (travelTime >= Speed)
        {
            transform.position = arrivalTile;
            body.rotation = Quaternion.AngleAxis(arrivalAngle, Vector3.forward);

            isDriving = false;
        }
        else
        {
            var intermediatePosition = transform.position + thrust * (1 / Speed) * Time.deltaTime;
            var intermediateAngle = departureAngle + (departureAngle - arrivalAngle) * (1 / Speed) * Time.deltaTime;
            transform.position = intermediatePosition;
            //body.rotation = Quaternion.AngleAxis(intermediateAngle, Vector3.forward);
        }
    }

    private void TryDrive(Vector3 RelDirection)
    {
        var newPosition = transform.position + RelDirection * 1;
        var newVector3 = new Vector3(newPosition.x, newPosition.y, 0);
        var sectionTypeAhead = GetRoadSectionType(newVector3);

        // Forget moving if there is no roadsection
        if (sectionTypeAhead == null)
        {
            return;
        }

        if (CanIGoThere(RelDirection, sectionTypeAhead))
        {
            DriveTo(RelDirection, newVector3);
        }
        else
        {
            // car crash
            print("Player Collision Detect");
        }
    }

    private void DriveTo(Vector3 RelDirection, Vector3 newPosition)
    {
        arrivalTile = newPosition;
        var roadSectionType = GetRoadSectionType(newPosition);
        arrivalAngle = GetAngle(RelDirection, roadSectionType);
        thrust = RelDirection;
        departureTile = transform.position;
        departureAngle = transform.rotation.z;
        body.rotation = Quaternion.AngleAxis(GetAngleForDirection(RelDirection), Vector3.forward);
        travelTime = 0;

        isDriving = true;
        AutoDrive();
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

    private int GetAngleForDirection(Vector3 RelDirection)
    {
        int angle = 0;

        if (RelDirection == Vector3.left)
        {
            angle = -90;
        }
        else if (RelDirection == Vector3.right)
        {
            angle = 90;
        }
        else if (RelDirection == Vector3.up)
        {
            angle = 180;
        }
        else if (RelDirection == Vector3.down)
        {
            angle = 0;
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
