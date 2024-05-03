using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingPoint : MonoBehaviour
{
    public static WalkingPoint Instance;
    public List<Vector3> points = new List<Vector3>();

    private MazeRenderer mazeRenderer;

    int size;
    int width;
    int height;

    public bool Draw;

    public List<Vector3> GetPoints() { return points; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void ConfigurePoints()
    {
        mazeRenderer = GetComponent<MazeRenderer>();
        size = Mathf.RoundToInt(mazeRenderer.GetSize());
        width = mazeRenderer.GetWidth();
        height = mazeRenderer.GetHeight();
        int halfWidth = width / 2;
        int halfHeight = height / 2;
        int halfSize = size / 2;




        for (int x = -halfWidth; x <= halfWidth; x++)
        {
            for (int y = -halfHeight; y <= halfHeight; y++)
            {
                Vector3 point = new Vector3(halfSize + x, transform.position.y + 0.2f, halfSize + y);
                points.Add(point);
            }
        }
    }

    private void OnDrawGizmos()
    {
        
        Gizmos.color = Color.yellow;      
        for (int i = 0; i < points.Count; i++)
        {
            Gizmos.DrawSphere(points[i],0.1f);
        }
       
    }


}
