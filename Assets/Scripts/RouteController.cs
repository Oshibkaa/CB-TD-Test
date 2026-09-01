using System.Collections.Generic;
using UnityEngine;

public class RouteController : MonoBehaviour
{
    [SerializeField] private List<RoutePoint> routePoints = new List<RoutePoint>();

    private int currentPointIndex;

    void Start()
    {
        UpdateMarkers();
    }

    public void ReachPoint(RoutePoint point)
    {
        if (currentPointIndex >= routePoints.Count || point != routePoints[currentPointIndex])
        {
            return;
        }

        routePoints[currentPointIndex].SetActive(false);
        currentPointIndex++;

        if (currentPointIndex >= routePoints.Count)
        {
            Debug.Log("Route completed");
            return;
        }

        UpdateMarkers();
    }

    private void UpdateMarkers()
    {
        for(int i = 0; i < routePoints.Count; i++)
        {
            routePoints[i].SetActive(i == currentPointIndex);
        }
    }
}
