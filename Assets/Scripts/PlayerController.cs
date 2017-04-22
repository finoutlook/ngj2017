using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int BorderLeft = 0;

    public int BorderRight = 20;

    public int BorderBottom = 0;

    public int BorderTop = 20;

    // Use this for initialization
    void Start ()
    {
		
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
        Face(RelDirection);

        var newPosition = transform.position + RelDirection * 1;
        var x = Mathf.Clamp(newPosition.x, BorderLeft, BorderRight);
        var y = Mathf.Clamp(newPosition.y, BorderBottom, BorderTop);
        transform.position = new Vector3(x, y, 0);
    }


    private void Face(Vector3 RelDirection)
    {
        if (RelDirection == Vector3.left)
        {
            transform.rotation = Quaternion.AngleAxis(-90, Vector3.forward);
        }
        else if (RelDirection == Vector3.right)
        {
            transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
        }
        else if (RelDirection == Vector3.up)
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
        }
        else if (RelDirection == Vector3.down)
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        }
    }
}
