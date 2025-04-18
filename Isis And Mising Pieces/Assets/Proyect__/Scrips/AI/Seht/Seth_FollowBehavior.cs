using Unity.VisualScripting;
using UnityEngine;

public class Seth_FollowBehavior : StateMachineBehaviour
{


    [SerializeField] private float speedHunt;
    [SerializeField] private float time;

    private float timefollow;


    private Transform player;

    private SethBattle SethBattle;

    private EnemyAttack  enemyAttack;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timefollow = speedHunt;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        SethBattle = animator.gameObject.GetComponent<SethBattle>();
    }

    

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, player.transform.position, speedHunt * Time.deltaTime);
        
        timefollow -= Time.deltaTime;

        

    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
