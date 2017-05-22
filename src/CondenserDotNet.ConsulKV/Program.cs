using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondenserDotNet.ConsulKV
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = System.IO.File.ReadAllText("kv.json");
            var keys = JsonConvert.DeserializeObject<KeyValue[]>(input);
            var consul = new Configuration.Consul.ConsulRegistry(null);

            var taskList = new List<Task>();

            foreach (var kv in keys)
            {
                taskList.Add(consul.SetKeyAsync(kv.Key, kv.Value));
            }
            try
            {
                Task.WaitAll(taskList.ToArray());
            }
            catch(AggregateException ex)
            {
                foreach(var e in ex.InnerExceptions)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}