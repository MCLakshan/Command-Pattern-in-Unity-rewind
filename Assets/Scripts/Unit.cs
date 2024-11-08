// directive in C# that allows you to use classes from the UnityEngine namespace
using System.Collections;

using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    // Move the unit to the front
    public void MoveFront() {
        Vector3 targetPosition = transform.position + Direction.Front;
        StartCoroutine(MoveCoroutine(targetPosition));
    }

    // Move the unit to the back
    public void MoveBack() {
        Vector3 targetPosition = transform.position + Direction.Back;
        StartCoroutine(MoveCoroutine(targetPosition));
    }

    // Move the unit to the left
    public void MoveLeft() {
        Vector3 targetPosition = transform.position + Direction.Left;
        StartCoroutine(MoveCoroutine(targetPosition));
    }

    // Move the unit to the right
    public void MoveRight() {
        Vector3 targetPosition = transform.position + Direction.Right;
        StartCoroutine(MoveCoroutine(targetPosition));
    }


    // Monve coroutine
    private IEnumerator MoveCoroutine(Vector3 targetPosition) {
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f) {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        // Snap the position to the target position
        transform.position = targetPosition;
    }
}
