using UnityEngine;

public class PlayerFPS : MonoBehaviour
{
    //Atribut
    public float speed = 6f;
    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;

    //FPS
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    float rotationX = 0;

    //Awake called before start
    private void Awake()
    {
        //Mendapat nilai mask dari layer Floor
        floorMask = LayerMask.GetMask("Floor");
        Debug.Log("Floor mask:"+floorMask);

        //Mendapat komponen Animator
        anim = GetComponent<Animator>();

        //Mendapat komponen Rigidbody
        playerRigidbody = GetComponent<Rigidbody>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    //Fixed update not update, fixed update for physics (supaya ga lag)
    private void FixedUpdate()
    {
        //Mendapatkan nilai input horizontal (-1,0,1)
        float h = Input.GetAxisRaw("Horizontal");
        //Mendapatkan nilai input horizontal (-1,0,1)
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();
        Animating(h, v);
    }

    //Method player berjalan
    public void Move(float h, float v)
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        //Set nilai x dan y
        //movement.Set(h, 0f, v);

        //Normalisasi vector
        movement = (forward * v * speed * Time.deltaTime) + (right * h * speed * Time.deltaTime);

        //Move to position
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }

    public void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }
}
