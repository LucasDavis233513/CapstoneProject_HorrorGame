using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [Header("Movement Variables")]
    [SerializeField] float speed = 2.0f;
    private Vector2 MovementVector;
    private float MovementX, MovementZ;
    private Rigidbody RB;

    // Start is called before the first frame update
    void Start() {
        this.RB = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
        OnMove();
    }

    private void OnMove() {
        this.MovementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        this.MovementX = this.MovementVector.x;
        this.MovementZ = this.MovementVector.y;
    }

    // Updated at a fixed framerate; used for physics calculations
    private void FixedUpdate() {
        Vector3 movement = new Vector3(this.MovementX, 0, this.MovementZ);
        Vector3 direction = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        Vector3 velocity;

        direction.Normalize();
        velocity = direction * speed;

        this.RB.AddForce(movement + velocity);
    }
}
