using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Company.Framework.Server
{
    public static class HostHelper
    {
      // TODO: Your company name here...
      const string NamspaceRoot = "Company";
      const string ComponentIdentifier = "Service";
      static Assembly[] m_Assemblies = new Assembly[0];

      static void LoadAssemblies()
      {
         DirectoryInfo baseDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
         FileInfo[] files = baseDirectory.GetFiles("*.dll").Where(f => f.Name.StartsWith(NamspaceRoot)).ToArray();

         foreach(FileInfo info in files)
         {
            try
            {
               Assembly.LoadFile(info.FullName);
            }
            catch
            {}
         }

         List<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
         Assembly microservice = assemblies.Single(assembly=>assembly.FullName.Contains("Microservice"));
         IEnumerable<AssemblyName> names = microservice.GetReferencedAssemblies();
         foreach(AssemblyName name in names)
         {
            Assembly referenced = Assembly.Load(name);
            assemblies.Add(referenced);
         }
         m_Assemblies = assemblies.ToArray();
      }
      static HostHelper()
      {
         LoadAssemblies();
      }

      static IEnumerable<Type> FindHosts(string identifier)
      {
         List<Type> hostTypes = new List<Type>();
         IEnumerable<Assembly> assemblies = m_Assemblies.Where(assembly => assembly.FullName.StartsWith(NamspaceRoot) && assembly.FullName.EndsWith(identifier));
         foreach(Assembly assembly in assemblies)
         {
            hostTypes.AddRange(assembly.GetExportedTypes().Where(type => type.FullName.Equals("Hosting")));
         }
         return hostTypes.ToArray();
      }
      public static void Register()
      {
         IEnumerable<Type> hosts = FindHosts(ComponentIdentifier);
         foreach (Type host in hosts)
         {
            host.InvokeMember("Register",BindingFlags.Public | BindingFlags.Static,null,null,new object[0]);
         }
      }
   }
}
