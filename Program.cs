using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JSONDeserializeBaseWithGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameObj = new NameObj();
            var get1 = JsonConvert.DeserializeObject<BaseResponse<NameObj>>(nameObj.GetBaseJSON);
            Console.WriteLine($"get1 is null: {get1 == null}");
            Console.WriteLine($"get1.value: {get1.value}");
            var name1 = get1.Get();
            Console.WriteLine($"name1 is null: {name1 == null}");

            var getList1 = JsonConvert.DeserializeObject<BaseResponse<NameObj>>(nameObj.ListBaseJSON);
            Console.WriteLine($"getList1 is null: {getList1 == null}");
            Console.WriteLine($"getList1.value: {getList1.value}");
            var nameList = getList1.List();
            Console.WriteLine($"nameList is null: {nameList == null}");

            var superObj = new SuperObj();
            var get2 = JsonConvert.DeserializeObject<BaseResponse<SuperObj>>(superObj.GetBaseJSON);
            Console.WriteLine($"get2 is null: {get2 == null}");
            Console.WriteLine($"get2.value: {get2.value}");
            var name2 = get2.Get();
            Console.WriteLine($"name2 is null: {name2 == null}");

            var getList2 = JsonConvert.DeserializeObject<BaseResponse<SuperObj>>(superObj.ListBaseJSON);
            Console.WriteLine($"getList2 is null: {getList2 == null}");
            Console.WriteLine($"getList2.value: {getList2.value}");
            var nameList2 = getList2.List();
            Console.WriteLine($"nameList is null: {nameList2 == null}");

            Console.WriteLine("Hello World!");
        }
    }

    public class BaseObj
    {
        public string GetBaseJSON { get; set; } = string.Empty;
        public string ListBaseJSON { get; set; } = string.Empty;
    }

    public class NameObj : BaseObj
    {
        public NameObj()
        {
            GetBaseJSON = "{\"value\":{\"Name\":\"Bob\"}}";
            ListBaseJSON = "{\"value\":[{\"Name\":\"Bob\"},{\"Name\":\"Jennifer\"},{\"Name\":\"Mary\"}]}";
        }
        public string Name { get; set; }
    }

    public class SuperObj : BaseObj
    {
        public SuperObj()
        {
            GetBaseJSON = "{\"value\":{\"Super\":\"Bob\"}}";
            ListBaseJSON = "{\"value\":[{\"Super\":\"Bob\"},{\"Super\":\"Jennifer\"},{\"Super\":\"Mary\"}]}";
        }
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
