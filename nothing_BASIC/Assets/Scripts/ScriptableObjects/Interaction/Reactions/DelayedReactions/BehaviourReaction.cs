using UnityEngine;

public class BehaviourReaction : DelayedReaction
{
    public Behaviour behaviour;
    public string messageToBroadcast = "";
    public bool enabledState;


    protected override void ImmediateReaction()
    {
        behaviour.enabled = enabledState;
        if (messageToBroadcast != "")
        {
            behaviour.BroadcastMessage(messageToBroadcast);
        }
        
    }

}