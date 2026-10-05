using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySearchTrees;

namespace TreeTests;


public class NodeTests
{
    [Test]
    public void TestNode()
    {
        Node<string> root = new Node<string>("Root");
        root.Left = new Node<string>("Left");
        root.Right = new Node<string>("Right");
        root.Right.Left = new Node<string>("RightLeft");
        root.Right.Right = new Node<string>("RightRight");
        Assert.IsFalse(root.IsLeaf());
        Assert.IsTrue(root.Left.IsLeaf() );
        Assert.IsTrue(root.Right.Right.IsLeaf() ) ;
        string treeString = "Root L(Left) R(Right) L(RightLeft)R(RightRight))";
        Assert.AreEqual(treeString, root.ToString() );
    }
}


public class BSTTests
{
    BST<int> iBST = new BST<int>();
    [SetUp] 
    public void BSTSetup()
    {
        
        iBST.Add(50);
        iBST.Add(20);
        iBST.Add(27);
        iBST.Add(77);
        iBST.Add(22);
        iBST.Add(90);
        iBST.Add(89);
        iBST.Add(91);
        /*
         *          50
         *         /   \
         *        20    77
         *          \     \ 
         *           27     90
         *          /      /  \
         *        22      89   91
         * 
         */
       
    }

    [Test]
    public void TestAdd()
    {
        Assert.AreEqual(8, iBST.Count);
        string treeString = "Tree (50 L(20 R(27 L(22)) R(77 R(90 L(89) R(91))))";
        Assert.AreEqual(treeString, iBST.ToString());
        
    }

    [Test]
    public void TestHeight()
    {
        Assert.AreEqual(3, iBST.Height());
        BST<string> sTree = new BST<string>();
        Assert.AreEqual(-1, sTree.Height());
        sTree.Add("A");
        Assert.AreEqual(0, sTree.Height());
        sTree.Add("B");
        Assert.AreEqual(1, sTree.Height());
        sTree.Add("C");
        sTree.Add("D");
        sTree.Add("E");
        Assert.AreEqual(4, sTree.Height());
        sTree.Add("1");
        Assert.AreEqual(4, sTree.Height());

    }
}
