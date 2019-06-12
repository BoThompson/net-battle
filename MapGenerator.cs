using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriangleNet.Geometry;

public class MapGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField]
    private int
        m_pointCount = 300;

    private List<Vector2> m_points;
    private float m_mapWidth = 100;
    private float m_mapHeight = 50;
    private List<Segment> m_edges = null;
    private List<Segment> m_spanningTree;
    private List<Segment> m_delaunayTriangulation;


    /*void Generate()
    {

        List<uint> colors = new List<uint>();
        m_points = new List<Vector2>();

        for (int i = 0; i < m_pointCount; i++)
        {
            colors.Add(0);
            m_points.Add(new Vector2(
                    UnityEngine.Random.Range(0, m_mapWidth),
                    UnityEngine.Random.Range(0, m_mapHeight))
            );
        }
        
        Delaunay.Voronoi v = new Delaunay.Voronoi(m_points, colors, new Rect(0, 0, m_mapWidth, m_mapHeight));
        m_edges = v.VoronoiDiagram();

        m_spanningTree = v.SpanningTree(KruskalType.MINIMUM);
        m_delaunayTriangulation = v.DelaunayTriangulation();

  
        Gizmos.color = Color.red;
        if (m_points != null)
        {
            for (int i = 0; i < m_points.Count; i++)
            {
                Gizmos.DrawSphere(m_points[i], 0.2f);
            }
        }

        if (m_edges != null)
        {
            Gizmos.color = Color.white;
            for (int i = 0; i < m_edges.Count; i++)
            {
                Vector2 left = (Vector2)m_edges[i].p0;
                Vector2 right = (Vector2)m_edges[i].p1;
                Gizmos.DrawLine((Vector3)left, (Vector3)right);
            }
        }

        Gizmos.color = Color.magenta;
        if (m_delaunayTriangulation != null)
        {
            for (int i = 0; i < m_delaunayTriangulation.Count; i++)
            {
                Vector2 left = (Vector2)m_delaunayTriangulation[i].p0;
                Vector2 right = (Vector2)m_delaunayTriangulation[i].p1;
                Gizmos.DrawLine((Vector3)left, (Vector3)right);
            }
        }

        if (m_spanningTree != null)
        {
            Gizmos.color = Color.green;
            for (int i = 0; i < m_spanningTree.Count; i++)
            {
                LineSegment seg = m_spanningTree[i];
                Vector2 left = (Vector2)seg.p0;
                Vector2 right = (Vector2)seg.p1;
                Gizmos.DrawLine((Vector3)left, (Vector3)right);
            }
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector2(0, 0), new Vector2(0, m_mapHeight));
        Gizmos.DrawLine(new Vector2(0, 0), new Vector2(m_mapWidth, 0));
        Gizmos.DrawLine(new Vector2(m_mapWidth, 0), new Vector2(m_mapWidth, m_mapHeight));
        Gizmos.DrawLine(new Vector2(0, m_mapHeight), new Vector2(m_mapWidth, m_mapHeight));
    }
    */
}
