using System.Reflection;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AssemblyLib.AssemblyNode
{
    internal class MethodNode : IAssemblyNode
    {
        public string Name { get; }
        public bool IsExtensionMethod { get; }
        public List<IAssemblyNode> Nodes { get; }

        internal MethodNode(MethodInfo method)
        {
            Name = GetMethodSignature(method);
            IsExtensionMethod = method.IsDefined(typeof(ExtensionAttribute));
            Nodes = null;
        }

        private static string GetMethodSignature(MethodInfo method)
        {
            string result = method.ReturnType.Name + " " + method.Name + "(";
            ParameterInfo[] parameters = method.GetParameters();
            for (int i = 0; i < parameters.Length; i++)
            {
                result += parameters[i].ParameterType.Name + " " + parameters[i].Name;
                if (i < parameters.Length - 1)
                {
                    result += ", ";
                }
            }
            return result + ")";
        }
    }
}
