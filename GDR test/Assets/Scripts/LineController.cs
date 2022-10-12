using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lineRendered;
    public GameObject start; //start - пустой GameObject, к которому привязан игрок
    public List<Transform> points;
    public GameObject lineCanvas;
    public Vector2 target;
    private void Awake()
    {
        lineRendered = GetComponent<LineRenderer>();
        lineRendered.positionCount = 0;
        points = new List<Transform>();
    }
    private void Start()
    {
        start = GameObject.FindWithTag("Start");
    }
    public void AddPoint(Transform point)
    {
        lineRendered.positionCount++;
        points.Add(point);
    }
    private void LateUpdate()
    {
        if (points.Count >= 2)
        {
            for (int i = 0; i < points.Count; i++)
            {
                lineRendered.SetPosition(i, points[i].position);
            }
            target = points[1].position; //цель - позиция точки[1] в списке
            start.transform.position = Vector2.MoveTowards(start.transform.position, target, PlayerController.speed * Time.deltaTime);
            if(start.transform.position == points[1].position)
            {
                DeletePoint();
            }
        }
    }
    private void DeletePoint()
    {
        if(lineRendered.positionCount > 1)
        {
            lineRendered.positionCount--;
            Destroy(points[1].gameObject);
            points.RemoveAt(1);
        }
    }
    public void DeleteLine()
    {
        if(PlayerController.isPlayerAlive == false)
        {
            lineCanvas = GameObject.FindWithTag("LineCanvas");
            lineCanvas.SetActive(false);
            PlayerController.isPlayerAlive = true;
        }
    }
}
