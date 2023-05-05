namespace ShomerShabbat.Service;

public class ShabbatChecker : BackgroundService
{
    private readonly ILogger<ShabbatChecker> _logger;
    private readonly IConfiguration _configuration;
    private readonly ISystemAudioService _audioService;
    
    public ShabbatChecker(ILogger<ShabbatChecker> logger, IConfiguration configuration, ISystemAudioService audioService)
    {
        _logger = logger;
        _configuration = configuration;
        _audioService = audioService;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            _logger.LogInformation("Checking for Shabbat, running at: {time}", DateTimeOffset.Now);
            bool isNohalShabbat = DateTime.Now.IsNohalShabbat();
            await _audioService.SetMuteAsync(isNohalShabbat, cancellationToken);
            int frequency = int.Parse(_configuration.GetSection("ShabbatConfiguration:FrequencyInHours").Value);
            await Task.Delay(TimeSpan.FromHours(frequency), cancellationToken);
        }
    }
}