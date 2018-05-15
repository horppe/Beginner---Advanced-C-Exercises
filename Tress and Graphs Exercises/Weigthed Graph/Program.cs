using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weigthed_Graph
{
    class GraphTest
    {
        static void Main(string[] args)
        {
            
            GraphComponents graph = new GraphComponents();
            graph.CheckEuler(0);

            Console.ReadKey();
        }
        static void PrintPaths(List<string> paths)
        {
            for (int i = 0; i < paths.Count; i++)
            {
                Console.WriteLine(paths[i]);
            }
            Console.WriteLine();
        }
    }
    class GraphComponents
    {
        public class Edge
        {
            public int weight;
            public int value;
            public Edge(int weight, int value)
            {
                this.weight = weight;
                this.value = value;
            }
            public int CompareTo(Edge y)
            {
                return this.value.CompareTo(y.value);
            }
        }

        public class Graph
        {
            public List<Edge>[] childNodes;

            public Graph(int size)
            {
                childNodes = new List<Edge>[size];
                for (int i = 0; i < childNodes.Length; i++)
                {
                    childNodes[i] = new List<Edge>();
                }
            }

            public Graph(List<Edge>[] childNodes)
            {
                this.childNodes = childNodes;
            }
            public int Size
            {
                get { return childNodes.Length; }
            }
            public void AddEdge(int v, int s, int edgeWeight)
            {
                childNodes[v].Add(new Edge(edgeWeight, s));
            }
            public void RemoveEdge(int v, Edge edge)
            {
                childNodes[v].Remove(edge);
            }
            public bool HasEdge(int v, Edge edge)
            {
                bool hasEdge = childNodes[v].Contains(edge);
                return hasEdge;
            }
            public bool Contains(int vertex)
            {
                if (childNodes[vertex] != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        Graph graph = new Graph(new List<Edge>[] {
        new List<Edge>() { new Edge(1, 1) },
        new List<Edge>() { new Edge(5, 2) },
        new List<Edge>() { new Edge(7, 3) },
        new List<Edge>() { new Edge(12, 0), new Edge(6, 4), new Edge(9, 5) },
        new List<Edge>() { new Edge(8, 6) },
        new List<Edge>() { new Edge(6, 7) },
        new List<Edge>() { new Edge(10, 3) },
        new List<Edge>() { new Edge(3, 6) },
        });

        bool[] visited;
        public int Size { get { return graph.Size; } }

        public GraphComponents()
        {
            visited = new bool[graph.Size];
        }

        public Edge FindEdge(int value)
        {
            Stack<Edge> stk = new Stack<Edge>();
            bool[] tmpVisited = new bool[graph.Size];
            stk.Push(graph.childNodes[0][0]);
            while (stk.Count > 0)
            {
                Edge peek = stk.Peek();
                if (peek.value == value)
                {
                    return peek;
                }
                List<Edge> paths = GetPaths(stk.Pop());
                foreach (Edge edge in paths)
                {
                    if (!tmpVisited[edge.value])
                    {
                        stk.Push(edge);
                        tmpVisited[edge.value] = true;
                    }
                }
            }
            return null;
        }

        public string FindShortestPath(int start, int end)
        {   //First declare and initiate the needed tools to traverse and store the values
            if (start == end)
            {
                return null;
            }
            Queue<Edge> que = new Queue<Edge>();  //*que stores the paths we pass through
            Stack<Edge> stk = new Stack<Edge>();  //*stk enables DFS Traversal through the graph
            bool[] visitedNode = new bool[visited.Length];  //*visitedNode keeps the record of visited nodes
            List<Edge> shortestPath = new List<Edge>();   //List *shortestPath is used to save the current and shortest path to the destination found
            Edge begin = new Edge(0, start);
            List<Edge> paths = GetPaths(begin);
            foreach (Edge path in paths)    //paths contains the successors of the starting index
            {   //each Path in *paths is Traversed individually to avoid clashes between different routes.
                que.Enqueue(new Edge(0, start)); //values are pushed in *stk and *que to kick off the -Traverse method
                stk.Push(path); //one of the *paths of x is pushed into the *stk before traversal
                visitedNode[start] = true;   //the path pushed into *stk is maked visited
                visitedNode[path.value] = true;
                shortestPath = Traverse(stk, que, shortestPath, visitedNode, end);    //The *path is traversed to find the destination *y
                stk.Clear();
                que.Clear();
                visitedNode = new bool[visited.Length];
                //all used variables are cleared of the previous journey before starting the next traversal.
            }
            string strPath = ConvertPath(shortestPath);
            return strPath;
        }

        public string ConvertPath(List<Edge> path)
        {
            StringBuilder stb = new StringBuilder();
            int pathSum = 0;
            foreach (Edge i in path)
            {
                if (i != null)
                {
                    stb.AppendFormat("{0}, ", i.value);
                    pathSum += i.weight;
                }
            }
            stb.AppendFormat("Total Distance: {0}.", pathSum);
            string result = stb.ToString();
            return result;
        }

        private List<Edge> Traverse(Stack<Edge> stk, Queue<Edge> que, List<Edge> shortestPath, bool[] visitedNode, int y)
        {
            Edge currentPath = stk.Pop();    //the *currentPath is popped out of the stack
            que.Enqueue(currentPath);   //*que keeps a record of the visit to *currentPath
            if (currentPath.value == y)
            {   //If destination is found
                if (shortestPath.Count <= 0)
                {
                    shortestPath = SavePath(que);
                }
                else if (que.Count < shortestPath.Count)
                {   //If a path was found
                    shortestPath = SavePath(que);
                }
                return shortestPath;    //End current traversal and return the path
            }
            List<Edge> paths = GetPaths(currentPath);    //get the successors of the *currentPath
            foreach (Edge path in paths)
            {   //Traverse each successor of *currentPath
                if (!visitedNode[path.value])
                {   //check if the vertex is already visted
                    stk.Push(path);
                    visitedNode[path.value] = true;   //if not visited, push into stack and mark as visited
                    bool[] currentBoolNodes = new bool[visitedNode.Length];
                    visitedNode.CopyTo(currentBoolNodes, 0);
                    Queue<Edge> currentQueue = new Queue<Edge>(que);  //Swap the variables sent into the Recursive call, to enable step-back if a *path is not valid
                    shortestPath = Traverse(stk, currentQueue, shortestPath, currentBoolNodes, y);
                }
            }

            return shortestPath;
        }

        private List<Edge> GetPaths(Edge vertex)
        {
            return graph.childNodes[vertex.value];
        }

        private List<Edge> SavePath(Queue<Edge> que)
        {
            List<Edge> shortestPath = new List<Edge>(); //First create a List
            while (que.Count > 0)
            {
                shortestPath.Add(que.Dequeue());
            }
            return shortestPath;   //return the list
        }

        public List<string> CalculateAllPaths(int start)
        {
            List<string> paths = new List<string>();
            for (int i = 0; i < graph.Size; i++)
            {
                string Path = FindShortestPath(start, i);
                if (Path != null)
                {
                    paths.Add(Path);
                }
            }
            
            return paths;
        }

        public List<Edge> this[int index]
        {
            get { return graph.childNodes[index]; }
        }

        public bool CheckEuler(int start)
        {
            Edge vertexStart = new Weigthed_Graph.GraphComponents.Edge(0, start);
            bool[] tempVisited = new bool[visited.Length];
            List<Edge> paths = GetPaths(vertexStart);
            Stack<Edge> stk = new Stack<Edge>();
            stk.Push(vertexStart);
            Queue<Edge> que = new Queue<Edge>();
            List<List<Edge>> shortestPath = new List<List<Edge>>();
            List<Edge> resultPath = new List<Edge>();
            List<Edge> result = Traverse(stk, que, shortestPath, resultPath, 0);
            Console.ReadKey();
            return true;

        }

        private List<Edge> Traverse(Stack<Edge> stk, Queue<Edge> que, List<List<Edge>> invalidPaths, List<Edge> resultPath, int startValue)
        {
            Edge currentVertex = stk.Pop();
            List<Edge> paths = GetPaths(currentVertex);
            if (currentVertex.value == startValue)
            {
                if (CheckPath(que, invalidPaths))
                {
                    resultPath = SavePath(que);
                    List<Edge> tempInvalid = SavePath(que);
                    invalidPaths.Add(new List<Edge>(tempInvalid));
                    return resultPath;
                }
                else
                {
                    return null;
                }
            }
            
            foreach (Edge path in paths)
            {
                que.Enqueue(path);
                if (path.value == startValue)
                {
                    if (que.Count < graph.Size)
                    {
                        continue;
                    } else if (que.Count >= graph.Size)
                    {
                        invalidPaths = SavePath(que);
                        return invalidPaths;
                    }
                }
                stk.Push(path);
                return Traverse(stk, que, invalidPaths, resultPath, startValue);
            }
        }

        public bool CheckPath(Queue<Edge> currentPath, List<List<Edge>> InvalidPaths)
        {
            
        }
    }
}
