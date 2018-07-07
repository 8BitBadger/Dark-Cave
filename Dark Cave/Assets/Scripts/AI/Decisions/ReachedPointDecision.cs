using UnityEngine;

namespace AiLogic
{
    [CreateAssetMenu(menuName = "PluggableAI/Decisions/Reached Point")]
    public class ReachedPointDecision : Decision
    {
        bool firstLoop = true;

        public override bool Decide(StateController controller)
        {
            if (firstLoop)
            {
                firstLoop = false;
                controller.lastTimeMoved = Time.time;
                controller.lastPosition = controller.transform.position;
            }
            return ReachedPoint(controller);
        }

        private bool ReachedPoint(StateController controller)
        {
            if (Vector2.Distance(controller.rb2d.position, controller.lastSeenPoint) < 0.4f)
            {
                return true;
            }

            if ((Time.time - controller.lastTimeMoved) > 3)
            {
                if (Vector2.Distance(controller.lastPosition, controller.transform.position) < 0.1f)
                {
                    firstLoop = true;
                    return true;
                }
                controller.lastTimeMoved = Time.time;
                controller.lastPosition = controller.transform.position;
            }

            return false;
        }
    }
}
