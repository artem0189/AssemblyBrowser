using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary.Tree.TreeNode
{
    public class Node : INode
    {
        private object test;
        public object Value { get; set; }
        
        public Node(object value)
        {
            Value = value;
        }
    }
}
