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
            Console.WriteLine($"get1.value: {get1.Value}");
            var name1 = get1.Value;
            Console.WriteLine($"name1 is null: {name1 == null}");

            var getList1 = JsonConvert.DeserializeObject<BaseResponse<List<NameObj>>>(nameObj.ListBaseJSON);
            Console.WriteLine($"getList1 is null: {getList1 == null}");
            Console.WriteLine($"getList1.value: {getList1.Value}");
            var nameList = getList1.Value;
            Console.WriteLine($"nameList is null: {nameList == null}");
            nameList.ForEach(n => Console.WriteLine($"name: {n.Name}"));

            var superObj = new SuperObj();
            var get2 = JsonConvert.DeserializeObject<BaseResponse<SuperObj>>(superObj.GetBaseJSON);
            Console.WriteLine($"get2 is null: {get2 == null}");
            Console.WriteLine($"get2.value: {get2.Value}");
            var name2 = get2.Value;
            Console.WriteLine($"name2 is null: {name2 == null}");

            var getList2 = JsonConvert.DeserializeObject<BaseResponse<List<SuperObj>>>(superObj.ListBaseJSON);
            Console.WriteLine($"getList2 is null: {getList2 == null}");
            Console.WriteLine($"getList2.value: {getList2.Value}");
            var nameList2 = getList2.Value;
            Console.WriteLine($"nameList is null: {nameList2 == null}");
            nameList2.ForEach(n => Console.WriteLine($"super: {n.SuperName}"));

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
        public string SuperName => $"Super {Super}";
    }

    public abstract class BaseResponseBase
    {
        // Allows for non-generic access to the BaseResponse value if needed
        // Use a method rather than a property to prevent accidental serialization.
        public abstract object GetBaseValue();
    }

    public class BaseResponse<T>
    {
        //public override object GetBaseValue() { return Value; }

        public T Value { get; set; }
    }
}
