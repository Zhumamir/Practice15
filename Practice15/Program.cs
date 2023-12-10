using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Practice15
{
    public class MyClass
    {
        public string MyProperty { get; set; }

        public void MyMethod()
        {
            Console.WriteLine("Executing MyMethod");
        }

        private void PrivateMethod()
        {
            Console.WriteLine("Executing PrivateMethod");
        }
    }
    class Program
    {
        static void Main()
        {
            Type myClassType = typeof(MyClass);

            Console.WriteLine($"Имя класса: {myClassType.Name}");

            Console.WriteLine("Конструкторы:");
            foreach (var constructor in myClassType.GetConstructors())
            {
                Console.WriteLine($"- {constructor}");
            }

            Console.WriteLine("Поля и свойства:");
            foreach (var field in myClassType.GetFields())
            {
                Console.WriteLine($"- {field.Name} ({field.FieldType.Name})");
            }

            foreach (var property in myClassType.GetProperties())
            {
                Console.WriteLine($"- {property.Name} ({property.PropertyType.Name})");
            }

            Console.WriteLine("Методы:");
            foreach (var method in myClassType.GetMethods())
            {
                Console.WriteLine($"- {method.ReturnType.Name} {method.Name}");
            }

            object instance = Activator.CreateInstance(myClassType);

            PropertyInfo propertyInfo = myClassType.GetProperty("MyProperty");
            propertyInfo.SetValue(instance, "New Value");

            MethodInfo methodInfo = myClassType.GetMethod("MyMethod");
            methodInfo.Invoke(instance, null);

            MethodInfo privateMethodInfo = myClassType.GetMethod("PrivateMethod", BindingFlags.NonPublic | BindingFlags.Instance);
            privateMethodInfo.Invoke(instance, null);
        }
    }
}
