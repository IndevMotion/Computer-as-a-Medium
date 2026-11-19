
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private float speedX = 0f;
    private float speedY = 0f;
    public Rigidbody2D rb;

    [Header("Player Direction Sprites")]
    public SpriteRenderer playerRenderer;
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    [Header("Weapon Direction")]
    public Transform weaponPivot;

    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        if (playerRenderer == null)
            playerRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        // Horizontal Movement
        if (Keyboard.current.aKey.isPressed)
        {
            speedX = -moveSpeed;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            speedX = moveSpeed;
        }
        else
        {
            speedX = 0;
        }

        // Vertical Movement
        if (Keyboard.current.wKey.isPressed)
        {
            speedY = moveSpeed;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            speedY = -moveSpeed;
        }
        else
        {
            speedY = 0;
        }

        rb.linearVelocity = new Vector2(speedX, speedY);

        UpdateDirection();
    }

    void UpdateDirection()
    {
        if (speedX == 0 && speedY == 0)
            return;

        Sprite newSprite = null;
        float angle = 0f;

        if (Mathf.Abs(speedX) > Mathf.Abs(speedY))
        {
            if (speedX > 0)
            {
                newSprite = rightSprite;
                angle = 0f;
            }
            else
            {
                newSprite = leftSprite;
                angle = 180f;
            }
        }
        else
        {
            if (speedY > 0)
            {
                newSprite = upSprite;
                angle = 90f;
            }
            else
            {
                newSprite = downSprite;
                angle = -90f;
            }
        }

        // Change player sprite
        if (playerRenderer != null && newSprite != null)
        {
            playerRenderer.sprite = newSprite;
        }

        // Rotate weapon and its child FirePoint
        if (weaponPivot != null)
        {
            weaponPivot.localRotation =
                Quaternion.Euler(0f, 0f, angle);
        }
    }
}
