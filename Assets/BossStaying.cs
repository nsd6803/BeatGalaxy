using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStaying : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange;


    Transform planet;
    Rigidbody2D rb;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        planet = GameObject.FindGameObjectWithTag("Planet").transform;
        rb = animator.GetComponent<Rigidbody2D>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target = new Vector2(planet.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if(Vector2.Distance(planet.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("BasicAttack");
        }
    }

     
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      animator.ResetTrigger("BasicAttack");
    }


}
