using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssemblyLib.AssemblyNode;
using AssemblyLib.Reflection;
using AssemblyLib.Extension;

namespace AssemblyLib
{
    internal class AssemblyTree
    {
        private Assembly _assembly;
        private List<IAssemblyNode> _tree;
        private const BindingFlags _flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

        internal AssemblyTree(Assembly assembly)
        {
            _assembly = assembly;
            _tree = new List<IAssemblyNode>();
        }

        private void CreateTree()
        {
            IAssemblyNode currentNode = null;
            Type[] types = Metadata.GetAssemblyTypes(_assembly);
            for (int i = 0; i < types.Length; i++)
            {
                currentNode = _tree.GetOrAdd(new NamespaceNode(types[i]));
                currentNode = currentNode.Nodes.GetOrAdd(new TypeNode(types[i]));
                currentNode.Nodes.AddRange(GetMembers(types[i]));
            }
        }

        private List<IAssemblyNode> GetMembers(Type type)
        {
            List<IAssemblyNode> result = new List<IAssemblyNode>();
            MethodInfo[] methods = Metadata.GetMethods(type);
            if (type.IsDefined(typeof(ExtensionAttribute)))
            {
                methods = DeleteExtensionMethods(methods);
            }
            result.AddRange(methods.Select(method => new MethodNode(method)).ToList());
            result.AddRange(Metadata.GetFields(type).Select(field => new FieldNode(field)).ToList());
            result.AddRange(Metadata.GetProperties(type).Select(property => new PropertyNode(property)).ToList());
            return result;
        }

        private MethodInfo[] DeleteExtensionMethods(MethodInfo[] methods)
        {
            IAssemblyNode currentNode = null;
            MethodInfo[] extensionMethods = methods.Where(method => method.IsDefined(typeof(ExtensionAttribute))).ToArray();
            for (int i = 0; i < extensionMethods.Length; i++)
            {
                Type extensionType = extensionMethods[i].GetParameters()[0].ParameterType;
                currentNode = _tree.GetOrAdd(new NamespaceNode(extensionType));
                currentNode = currentNode.Nodes.GetOrAdd(new TypeNode(extensionType));
                currentNode.Nodes.Add(new MethodNode(extensionMethods[i]));
            }
            return methods.Except(extensionMethods).ToArray();
        }

        internal List<IAssemblyNode> GetAssemblyTree()
        {
            CreateTree();
            return _tree.OrderBy(arr => arr.Name).ToList();
        }
    }
}
