using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarshipMovement : MonoBehaviour
{
    private Vector3 touchPosition;
    private Rigidbody2D rb;
    private Vector3 direction;
    private float moveSpeed = 10f;

    public GameObject Bullet;
    Vector2 bulletPos;
    public float fireRate = 0.5f;
    float nextFire = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
            rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;

            if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector2.zero;
            }
        }
        if (IsDoubleTap())
        {
           print("double tap");
           nextFire = Time.time + fireRate;
           makeFire();
        }
    }

    void makeFire()
    {
        bulletPos = transform.position;
        bulletPos += new Vector2(0, -0.5f);
        Instantiate(Bullet, bulletPos, Quaternion.identity);
    }

   
    public static bool IsDoubleTap()
    {
        bool result = false;
        float MaxTimeWait = 1;
        float VariancePosition = 1;

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            float DeltaTime = Input.GetTouch(0).deltaTime;
            float DeltaPositionLenght = Input.GetTouch(0).deltaPosition.magnitude;

            if (DeltaTime > 0 && DeltaTime < MaxTimeWait && DeltaPositionLenght < VariancePosition)
                result = true;
        }
        return result;
    }
}
