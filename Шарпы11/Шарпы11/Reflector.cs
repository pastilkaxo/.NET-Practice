using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Шарпы11;

internal static class Reflector
{
    public static Type GetType(Object obj)
    {
        return obj.GetType();
    }

    public static Type GetType(string typeName)
    {
        Type? typeObject = Type.GetType(typeName);

        return typeObject;
    }

    static public bool HasPublicConstructors(Object obj)
    {
        return obj.GetType().GetConstructors(BindingFlags.Public | BindingFlags.Instance).Any();
    }

    public static IEnumerable<string> GetPublicMethods(string typeName)
    {
        return (
            GetType(typeName)
                .GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public)
                .Select(methodInfo => methodInfo.Name)
        );
    }

    static public IEnumerable<string> GetFields(Object obj)
    {
        return GetType(obj).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance).Select(el => el.Name);
    }

    static public IEnumerable<string> GetInters(Object obj)
    {
       
      return  GetType(obj).GetInterfaces().Select(inter => inter.Name);
    
    }

    static public IEnumerable<string> GetMethodWithParametr(Object className, string parametr)
    {
        Type type = className.GetType();
        MethodInfo[] methods = type.GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        foreach (MethodInfo m in methods)
        {
            ParameterInfo[] pr = m.GetParameters();
            foreach (ParameterInfo p in pr)
            {
                if (p.ParameterType.Name == parametr)
                {
                    yield return m.Name + " has: " + parametr;
                }
            }
        }
        
    }


    static public Object? Invoke(Object obj , string mName , Object[] parames)
    {
        Type type = obj.GetType();
        return type.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(me => me.Name == mName).First().Invoke(obj , parames);

    }


    public static T Create<T>(string typeName, Object[] parameters )
    {
        var constructor = (
            GetType(typeName)
                .GetConstructor(
                    BindingFlags.Instance | BindingFlags.Public,
                    null,
                    CallingConventions.HasThis,
                    parameters?.Select(p => p.GetType()).ToArray() ?? new Type[] { },
                    null
                 )
        );

     

        return (T)constructor.Invoke(parameters);
    }




    public static void InputFile(string typeName)
    {
        File.WriteAllText("C:\\Users\\Влад\\source\\repos\\Шарпы11\\Шарпы11\\json1.json", string.Join(" ", GetType(typeName).GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance).Select(el => el.Name)));

    }






}
