using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class PatrolAT : ActionTask {
		NavMeshAgent bearAgent;
		public Transform pointsPar;
		public BBParameter<Transform> player;
		public float distance = 10f;
		public float buffer;
		public float speed = 3f;

        Transform[] points;
		int index;
		

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			bearAgent = agent.GetComponent<NavMeshAgent>();
			index = 1;
			points = pointsPar.GetComponentsInChildren<Transform>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			bearAgent.SetDestination(points[index].position);
            bearAgent.speed = speed;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if(Vector3.Distance(player.value.position, bearAgent.transform.position) < distance)
			{
                EndAction(true);
            }
			if(Vector3.Distance(bearAgent.transform.position, bearAgent.destination) < buffer)
			{
				index = index%(points.Length-1)+1;
				bearAgent.SetDestination(points[index].position);
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