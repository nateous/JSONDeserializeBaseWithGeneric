using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JSONDeserializeBaseWithGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            var response1Get = "{\"value\":{\"Name\":\"Bob\"}}";
            var response1List = "{\"value\":[{\"Name\":\"Bob\"},{\"Name\":\"Jennifer\"},{\"Name\":\"Mary\"}]}";
            var response2Get = "{\"value\":{\"Super\":\"Bob\"}}";
            var response2List = "{\"value\":[{\"Super\":\"Bob\"},{\"Super\":\"Jennifer\"},{\"Super\":\"Mary\"}]}";

            var get1 = JsonConvert.DeserializeObject<BaseResponse<NameObj>>(response1Get);
            Console.WriteLine($"get1 is null: {get1 == null}");
            Console.WriteLine($"get1.value: {get1.value}");
            var name1 = get1.Get();
            Console.WriteLine($"name1 is null: {name1 == null}");

            var getList1 = JsonConvert.DeserializeObject<BaseResponse<NameObj>>(response1List);
            Console.WriteLine($"getList1 is null: {getList1 == null}");
            Console.WriteLine($"getList1.value: {getList1.value}");
            var nameList = getList1.List();
            Console.WriteLine($"nameList is null: {nameList == null}");

            Console.WriteLine("Hello World!");
        }
    }

    public class BaseObj
    {
        public string SomeBaseProperty { get; set; }
    }

    public class NameObj : BaseObj
    {
        public string Name { get; set; }
    }

    public class SuperObj : BaseObj
    {
        public string Super { get; set; }
    }

    public class BaseResponse<T> where T : BaseObj
    {
        public object value;

        public T Get()
        {
            return value as T;
        }

        public List<T> List()
        {
            return value as List<T>;
        }
    }
}
