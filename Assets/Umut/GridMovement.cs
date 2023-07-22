using System.Collections;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 targetPosition;
    private bool isMoving = false;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Fare pozisyonunu al
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0f; // 2D ortamda z eksenini s�f�rla

            // Karakteri hedef pozisyona do�ru y�nlendir
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.up = moveDirection;

            // Karakteri hedefe do�ru hareket ettir (sadece bir kez)
            if (!isMoving)
            {
                StartCoroutine(MoveToTarget());
            }
        }
    }

    IEnumerator MoveToTarget()
    {
        isMoving = true;
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            // Karakteri hedefe do�ru hareket ettir
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        isMoving = false;
    }

}
