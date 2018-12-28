using System;
using System.Collections.Generic;
using System.Text;

namespace GofPatterns.Structural.FlyWeight
{
    /// <summary>
    /// Flyweight class - shared data
    /// </summary>
    class TreeType
    {
        public int Size { get; set; }
        public string ComplexData { get; set; }

        public TreeType(int size, string complexData)
        {
            this.Size = size;
            this.ComplexData = complexData;
        }

        public void DrawAt(int x, int y)
        {
            Console.WriteLine($"Tree size {Size} drawing at [{x},{y}] with complex data: {ComplexData}");
        }
    }

    class TreeTypeFactory
    {
        private Dictionary<int, TreeType> types = new Dictionary<int, TreeType>();

        public TreeType Get(int size, string complexData)
        {
            TreeType type = null;
            if (types.ContainsKey(size))
                type = types[size];
            else
            {
                type = new TreeType(size, complexData);
                types[size] = type;
            }

            return type;
        }
    }

    /// <summary>
    /// Context
    /// </summary>
    class Tree
    {
        public int X { get; set; }
        public int Y { get; set; }

        private TreeType treeType;

        public Tree (int x, int y, TreeType treeType)
        {
            X = x;
            Y = y;
            this.treeType = treeType;
        }

        public void Draw()
        {
            treeType.DrawAt(X,Y);
        }
    }

    /// <summary>
    /// Client
    /// </summary>
    class Forest
    {
        List<Tree> trees = new List<Tree>();
        private TreeTypeFactory factory;

        public Forest(TreeTypeFactory factory)
        {
            this.factory = factory;
        }

        public void PlantTree(int x, int y, int size, string complexData)
        {
            //shared
            var type = factory.Get(size, complexData);
            var tree = new Tree(x,y, type);
            trees.Add(tree);
        }

        public void Draw()
        {
            trees.ForEach(tree => tree.Draw());
        }
    }
}
