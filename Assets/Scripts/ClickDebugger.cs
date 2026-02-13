using UnityEngine;
using UnityEngine.InputSystem;

public class ClickDebugger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // New way to check for a "click" or "tap"
        if (Pointer.current != null && Pointer.current.press.wasPressedThisFrame)
        {
            // Get the screen position from the pointer (mouse or trackpad)
            Vector2 screenPos = Pointer.current.position.ReadValue();
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

            // For 2D: Check if we hit a collider
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("SUCCESS! Hit object: " + hit.collider.gameObject.name);
            }
            else
            {
                Debug.Log("MISS: You clicked on empty space at " + worldPos);
            }

            // Draw a visual indicator in the Scene View
            Debug.DrawRay(worldPos, Vector3.forward * 10, Color.red, 1f);
        }


    }
}
