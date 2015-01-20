
public interface ISkylinkNotificationManager {
	ISkylinkNotificationManagerDelegate Delegate{ get; set; }
	void Register();
}

public abstract class AbstractSkylinkNotificationManager : ISkylinkNotificationManager {
	private ISkylinkNotificationManagerDelegate _delegate;
	public ISkylinkNotificationManagerDelegate Delegate{ get{ return _delegate; } set{ _delegate = value; } }
	public abstract void Register ();
}