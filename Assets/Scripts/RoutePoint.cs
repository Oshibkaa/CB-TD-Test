using UnityEngine;

public class RoutePoint : MonoBehaviour
{
    [SerializeField] private RouteController routeController;
    [SerializeField] private GameObject marker;

    public void SetActive(bool active)
    {
        marker.SetActive(active);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Vehicle"))
        {
            routeController.ReachPoint(this);
        }
    }
}
