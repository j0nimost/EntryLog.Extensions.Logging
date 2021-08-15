## EntryLog.Extensions.Logging
An Extension Library for `Microsoft.Extensions.Logging` using the default implementation of [EntryLog Lib](https://github.com/j0nimost/EntryLog).

### Implementation
The library comes in handy when writing logs from the robust `ILogger` library.

* Download the extension library [here]()

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

- To remove default logging extensions i.e Console use `builder.ClearProviders()`. 
So the implementation changes to:

```c#
Host.CreateDefaultBuilder(args)
                .ConfigureLogging(builder =>
                    builder.ClearProviders().AddEntryLog()
```

### .Net Support
|      .Net Core
|________________________|
| 2.1, 2.2, 3.0, 3.1, 5.0|


### Author
John Nyingi

### Contributions
Feel Free to Hack 