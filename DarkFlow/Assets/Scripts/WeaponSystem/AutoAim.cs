using UnityEngine;

public class AutoAim : MonoBehaviour
{
    public Transform target; // The current target
    public float aimAssistRadius = 10f; // Radius within which to search for targets
    public LayerMask enemyLayer; // Layer on which the enemies are placed
    public float rotationSpeed = 5f; // Speed at which the weapon rotates towards the target
    private DistanceMeter distanceMeter; // Reference to the DistanceMeter component

    private void Start()
    {
        // Find the DistanceMeter component in the scene
        distanceMeter = FindObjectOfType<DistanceMeter>();
    }

    private void Update()
    {
        if (target == null) // Find the closest target when there is none
        {
            FindClosestTarget();
        }

        if (target != null)
        {
            // Calculate the direction to the target
            Vector3 directionToTarget = target.position - transform.position;

            // Calculate the rotation needed to aim at the target
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

            // Smoothly rotate the weapon towards the target
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Calculate the distance to the target
            float distance = Vector3.Distance(transform.position, target.position);

            // Call the UpdateDistance method in DistanceMeter to display the distance
            distanceMeter.UpdateDistance(distance, target);
        }
        else
        {
            // If there's no target, hide the distance meter
            distanceMeter.HideDistance();
        }
    }

    private void FindClosestTarget()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, aimAssistRadius, enemyLayer);
        float closestDistance = aimAssistRadius;
        Transform closestTarget = null;

        foreach (var hit in hits)
        {
            float distance = Vector3.Distance(transform.position, hit.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = hit.transform;
            }
        }

        target = closestTarget;
    }
}
