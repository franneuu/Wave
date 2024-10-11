using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Rigidbody2D rb;
    private Vector2 movement;
    [SerializeField] private float moveSpeed;
    public Animator animator;
    public FireGun firegun;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal"); 
        movement.y = Input.GetAxis("Vertical");

        if (movement != Vector2.zero) 
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        animator.SetFloat("moveSpeed", movement.sqrMagnitude);

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 direction = transform.right;
            firegun.Shoot(direction);
        }
    }
    private void FixedUpdate()
    {
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime, Space.World);

    }
}
