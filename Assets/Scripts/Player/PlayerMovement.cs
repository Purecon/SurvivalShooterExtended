using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Atribut
    public float speed = 6f;
    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;

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
        //Set nilai x dan y
        movement.Set(h, 0f, v);

        //Normalisasi vector
        movement = movement.normalized * speed * Time.deltaTime;

        //Move to position
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        //Buat Ray dari posisi mouse di layar
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(camRay.origin,camRay.direction*camRayLength,Color.green);

        //Raycast untuk floorHit
        RaycastHit floorHit;

        //Lakukan raycast
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            //Mendapat vector dari posisi player dan posisi floorHit
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            //Mendapat look rotation baru ke hit position
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            //Debug.Log("Rotation:"+newRotation);

            //Rotasi player
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    public void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }
}
