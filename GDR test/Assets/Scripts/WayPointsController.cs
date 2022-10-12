using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsController : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] Transform pointParent;
    [SerializeField] private GameObject pointPrefab;
    [SerializeField] public GameObject startPointPrefab;

    [Header("Lines")]
    [SerializeField] Transform lineParent;
    [SerializeField] private GameObject linePrefab;
    private LineController trajectory;

    [Header("Fake player (using on start only)")]
    public GameObject fakePlayer;
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 worldTouchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if (touch.phase == TouchPhase.Began)
            {
                if (trajectory == null)
                {
                    fakePlayer.SetActive(false);
                    trajectory = Instantiate(linePrefab, Vector2.zero, Quaternion.identity, lineParent).GetComponent<LineController>();
                    GameObject startpoint = Instantiate(startPointPrefab, GetPlayerPosition(), Quaternion.identity, pointParent);
                    trajectory.AddPoint(startpoint.transform);
                }
                if (PlayerController.isPlayerAlive == true)
                {
                    GameObject point = Instantiate(pointPrefab, worldTouchPosition, Quaternion.identity, pointParent);
                    trajectory.AddPoint(point.transform);
                }
            }
        }
    }
    private Vector2 GetPlayerPosition()
    {
        Vector2 playerPosition = Camera.main.ScreenToWorldPoint(new Vector2(540, 960));

        return playerPosition;
    }
}