# SimpleLog

How to use:
- You need Autofac to register all clases of the SimpleLog library. With the extension:

            builder.AddSimpleLog(c =>
            {
                c.AddConsole();
                c.AddTextFile();
                c.AddAppender<AppenderCustomed>();
            });
            
- c.AddConsole() => Will log the text in console;            
- c.AddTextFile() => Will log the text in a file (in C:\SimpleLogs (when you root is C:\));
- c.AddAppender() => Appender customed, you need to implement IAppender;
            
- In your clase will inteject a log like ILogger< YourClass >.
