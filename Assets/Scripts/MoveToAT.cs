using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class MoveToAT : ActionTask {
		public Transform target;
		public float speed;
		public float stopDistance;

		private NavMeshAgent navAgent;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			navAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            navAgent.speed = speed;
            navAgent.SetDestination(target.position);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            float distance = Vector3.Distance(agent.transform.position, target.position);
            //stop when close enough
            if (distance <= stopDistance)
            {
				navAgent.speed = 0;
                EndAction(true);
            }
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}