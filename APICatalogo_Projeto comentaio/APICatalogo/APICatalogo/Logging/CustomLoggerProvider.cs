//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Concurrent;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ApiCatalogo.Logging
//{
//    //implementando a interface 
//    //essa classe responsavel pela instancias do logger 
//    public class CustomLoggerProvider : ILoggerProvider
//    {
//        readonly CustomLoggerProviderConfiguration loggerConfig;

//        //definindo uma instancia de dicionario para amazenar os loggers 
//        readonly ConcurrentDictionary<string, CustomerLogger> loggers =
//            new ConcurrentDictionary<string, CustomerLogger>();

//        //passando a configuração do logger 
//        public CustomLoggerProvider(CustomLoggerProviderConfiguration config)
//        {
//            loggerConfig = config;
//        }

//        //cria um instancia do logger passando o nome da categoria e armazenado no dicionario 
//        public ILogger CreateLogger(string categoryName)
//        {
//            return loggers.GetOrAdd(categoryName, name => new CustomerLogger(name, loggerConfig));
//        }

//        public void Dispose()
//        {
//            loggers.Clear();
//        }
//    }
//}
