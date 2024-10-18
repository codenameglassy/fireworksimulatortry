using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkBase : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D rb;
    private FireWorkLaunchType myFireworkLaunchType;
    public enum FireWorkLaunchType
    {
        up,
        left,
        right
    }
   

    [Header("Data")]
    public FireworkData fireWorkData;
    private float launchForce;

    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        RandomizeLaunchType();
        Launch();
    }

    void RandomizeLaunchType()
    {
        launchForce = Random.Range(fireWorkData.launchForceUpMin, fireWorkData.launchForceUpMax);
        // Randomize the FireWorkLaunchType at start
        myFireworkLaunchType = (FireWorkLaunchType)Random.Range(0, System.Enum.GetValues(typeof(FireWorkLaunchType)).Length);
        Debug.Log("Firework Launch Type: " + myFireworkLaunchType);
    }
    void Launch()
    {
        switch (myFireworkLaunchType)
        {
            case FireWorkLaunchType.up:

                // Apply an upward force to the Rigidbody2D
                rb.AddForce(Vector2.up * launchForce, ForceMode2D.Impulse);
                break;

            case FireWorkLaunchType.left:

                // Apply force upward and to the left
                Vector2 force = new Vector2(-fireWorkData.launchForceLeft, launchForce);
                rb.AddForce(force, ForceMode2D.Impulse);
                break;

            case FireWorkLaunchType.right:

                // Apply force upward and to the left
                Vector2 force_ = new Vector2(fireWorkData.launchForceRight, launchForce);
                rb.AddForce(force_, ForceMode2D.Impulse);
                break;
        }
    }

    private bool isHovering = false;

    void Update()
    {
        // Get the mouse position in world space
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Check if the mouse position overlaps the object's collider
        Collider2D collider = Physics2D.OverlapPoint(mousePosition);

        if (collider != null && collider.gameObject == gameObject)
        {
            if (!isHovering)
            {
                // Mouse just started hovering over the GameObject
                isHovering = true;
                OnMouseEnter();
            }
        }
        else
        {
            if (isHovering)
            {
                // Mouse is no longer hovering over the GameObject
                isHovering = false;
                OnMouseExit();
            }
        }
    }

    void OnMouseEnter()
    {
        // Action when the mouse starts hovering over the GameObject
      
        Debug.Log("Mouse entered the GameObject!");
        Instantiate(fireWorkData.fireworkVfx, transform.position, Quaternion.identity);
        Destroy(gameObject);
        // You can also add visual effects, change color, etc. here
    }

    void OnMouseExit()
    {
        // Action when the mouse stops hovering over the GameObject
        Debug.Log("Mouse exited the GameObject!");
    }

}
