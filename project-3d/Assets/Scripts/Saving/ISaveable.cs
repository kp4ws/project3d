namespace Kp4wsGames.Util
{
	public interface ISaveable
	{
		object CaptureState();
		void RestoreState(object state);
    }
}