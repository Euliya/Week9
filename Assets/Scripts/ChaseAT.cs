using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class ChaseAT : ActionTask {
		public BBParameter<Transform> player;
		public float speed = 10f;
		public float catchDis = 0.5f;
		public float loseDis = 15f;
		
		float distance;
		NavMeshAgent bearAgent;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			bearAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			bearAgent.SetDestination(player.value.position);
			bearAgent.speed = speed;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			distance = Vector3.Distance(agent.transform.position, player.value.position);

            if (distance < catchDis||distance>loseDis)
			{
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