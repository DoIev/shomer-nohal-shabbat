namespace ShomerShabbat.Service;

public interface ISystemAudioService
{
    public Task SetMuteAsync(bool mute, CancellationToken cancellationToken);
}