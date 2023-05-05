using AudioSwitcher.AudioApi.CoreAudio;

namespace ShomerShabbat.Service;
public class SystemAudioService: ISystemAudioService, IDisposable
{
    private readonly ILogger<SystemAudioService> _logger;
    private readonly CoreAudioController _audioController;
    
    public SystemAudioService(ILogger<SystemAudioService> logger, CoreAudioController audioController)
    {
        _logger = logger;
        _audioController = audioController;
    }
    public async Task SetMuteAsync(bool mute, CancellationToken token)
    {
        _logger.LogInformation($"Setting Mute to {mute}");
        await _audioController.DefaultPlaybackDevice.SetMuteAsync(mute, token);
    }

    public void Dispose()
    {
        _audioController.Dispose();
    }
}