using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssemblyLib.Node;
using AssemblyLib.Reflection;
using AssemblyLib.Extension;

namespace AssemblyLib
{
    internal class AssemblyTree
    {
        private Assembly _assembly;
        private List<AssemblyNode> _tree;
        private Dictionary<TypeNode, Func<object, string>> _nameFuncs;

        internal AssemblyTree(Assembly assembly)
        {
            _assembly = assembly;
            _tree = new List<AssemblyNode>();
            _nameFuncs = new Dictionary<TypeNode, Func<object, string>>()
            {
                { TypeNode.Namespace, NameFormatter.GetNamespaceName },
                { TypeNode.Type, NameFormatter.GetTypeName },
                { TypeNode.Field, NameFormatter.GetFieldName },
                { TypeNode.Property, NameFormatter.GetPropertyName },
                { TypeNode.Method, NameFormatter.GetMethodSignature }
            };
        }

        internal void SetCustomNameFunc(TypeNode typeNode, Func<object, string> func)
        {
            if (_nameFuncs.ContainsKey(typeNode))
            {
                _nameFuncs[typeNode] = func;
            }
            else
            {
                throw new Exception("Not exist for this type generator");
            }
        }

        private void CreateTree()
        {
            AssemblyNode currentNode = null;
            Type[] types = Metadata.GetAssemblyTypes(_assembly);
            for (int i = 0; i < types.Length; i++)
            {
                currentNode = _tree.GetOrAdd(new AssemblyNode(TypeNode.Namespace, types[i], _nameFuncs[TypeNode.Namespace](types[i])));
                currentNode = currentNode.Childrens.GetOrAdd(new AssemblyNode(TypeNode.Type, types[i], _nameFuncs[TypeNode.Type](types[i])));
                currentNode.Childrens.AddRange(GetMembers(types[i]));
            }
        }

        private List<AssemblyNode> GetMembers(Type type)
        {
            List<AssemblyNode> result = new List<AssemblyNode>();
            MethodInfo[] methods = Metadata.GetMethods(type);
            if (type.IsDefined(typeof(ExtensionAttribute)))
            {
                methods = DeleteExtensionMethods(methods);
            }
            result.AddRange(methods.Select(method => new AssemblyNode(TypeNode.Method, method, _nameFuncs[TypeNode.Method](method))).ToList());
            result.AddRange(Metadata.GetFields(type).Select(field => new AssemblyNode(TypeNode.Field, field, _nameFuncs[TypeNode.Field](field))).ToList());
            result.AddRange(Metadata.GetProperties(type).Select(property => new AssemblyNode(TypeNode.Property, property, _nameFuncs[TypeNode.Property](property))).ToList());
            return result;
        }

        private MethodInfo[] DeleteExtensionMethods(MethodInfo[] methods)
        {
            AssemblyNode currentNode = null;
            MethodInfo[] extensionMethods = methods.Where(method => method.IsDefined(typeof(ExtensionAttribute))).ToArray();
            for (int i = 0; i < extensionMethods.Length; i++)
            {
                Type extensionType = extensionMethods[i].GetParameters()[0].ParameterType;
                currentNode = _tree.GetOrAdd(new AssemblyNode(TypeNode.Namespace, extensionType, _nameFuncs[TypeNode.Namespace](extensionType)));
                currentNode = currentNode.Childrens.GetOrAdd(new AssemblyNode(TypeNode.Type, extensionType, _nameFuncs[TypeNode.Type](extensionType)));
                currentNode.Childrens.Add(new AssemblyNode(TypeNode.Method, extensionMethods[i], _nameFuncs[TypeNode.Method](extensionMethods[i])));
            }
            return methods.Except(extensionMethods).ToArray();
        }

        internal List<AssemblyNode> GetAssemblyTree()
        {
            CreateTree();
            return _tree;
        }
    }
}
