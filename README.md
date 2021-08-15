## EntryLog.Extensions.Logging
An Extension Library for `Microsoft.Extensions.Logging` using the default implementation of [EntryLog Lib](https://github.com/j0nimost/EntryLog). \
Download the extension library [here]()

### Implementation
The library comes in handy when writing logs from the robust `ILogger` library.

- Implementation is done in the `Program.cs` like so:
```c#
static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(builder =>
                    builder.AddEntryLog(config =>
                    {
                        config.FolderPath = new Uri(@"C:\logTests\entrlogExtension");
                        config.LogInterval = LogInterval.EveryMinute;
                    }));
```

- To remove default logging extensions i.e Console use `builder.ClearProviders()`. \
So the implementation changes to:

```c#
Host.CreateDefaultBuilder(args)
                .ConfigureLogging(builder =>
                    builder.ClearProviders().AddEntryLog()
```
### DefaultS
There are 2 default values set:
- Logging Folder Path : Directory Where the service is running
- Logging Interval : Every hour 


#### Note:
The DEFAULT values can be changed as shown in the implementation. \
There are 3 logging levels supported:
- LogInformation
- LogWarning
- LogError

### .Net Support
2.1, 2.2, 3.0, 3.1, 5.0


### Author
John Nyingi

### Contributions
Feel Free to Hack 