public class InteractableTrigger : GameTrigger {
	
	protected override void Awake()
	{
        base.Awake();
		gameObject.tag="Interactable";
	}
}
