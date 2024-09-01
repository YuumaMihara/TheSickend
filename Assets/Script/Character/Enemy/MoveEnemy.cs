using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 1.0f;
    [SerializeField] GameObject Player;
    public bool isStart;
    private CharacterController enemyController;
    private Animator animator;
    private Vector3 destination; //目的地
    private Vector3 velocity;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        enemyController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        destination = Player.transform.position;
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyController.isGrounded && isStart) {
			velocity = Vector3.zero;
			animator.SetFloat("Speed", 2.0f);
			direction = (destination - transform.position).normalized;
			transform.LookAt(new Vector3(destination.x, transform.position.y, destination.z));
			velocity = direction * walkSpeed;
		}
		velocity.y += Physics.gravity.y * Time.deltaTime;
		enemyController.Move(velocity * Time.deltaTime);
    }
}
