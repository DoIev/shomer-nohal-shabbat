using ShomerShabbat.Service;
using AudioSwitcher.AudioApi.CoreAudio;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureHostConfiguration(configHost =>
    {
        
        configHost.SetBasePath(Directory.GetCurrentDirectory());
        configHost.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    })
    .ConfigureServices(services =>
    {
        services.AddSingleton<CoreAudioController>();
        services.AddSingleton<ISystemAudioService, SystemAudioService>();
        services.AddHostedService<ShabbatChecker>();
    })
    .Build();
    
    
host.Run();