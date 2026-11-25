using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;

    [SerializeField] float lefftBoundPadding;
    [SerializeField] float rightBoundPadding;
    [SerializeField] float topBoundPadding;
    [SerializeField] float bottomBoundPadding;

    InputAction moveAction;

    Vector3 moveVector;
    Vector3 minBounds;
    Vector3 maxBounds;

    void Start()
    {
        moveAction =  InputSystem.actions.FindAction("Move");

        InitBounds();
    }

    void Update()
    {
        MovePlayer();
    }

    void InitBounds()
    {
        // Get the camera's bounds
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void MovePlayer ()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        Vector3 newPos = transform.position + moveVector * moveSpeed * Time.deltaTime;

        // Make sure the player stays within the camera's bounds using Mathf.Clamp
        newPos.x = Mathf.Clamp(newPos.x, minBounds.x + lefftBoundPadding, maxBounds.x - rightBoundPadding);
        newPos.y = Mathf.Clamp(newPos.y, minBounds.y + bottomBoundPadding, maxBounds.y - topBoundPadding);

        transform.position = newPos;
    }
}
