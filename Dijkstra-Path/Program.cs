using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DijkstraTest2
{
    public class Location
    {
        private string nameLocation { get; set; }
        private string pointName { get; set; }
        private Point pointLocation { get; set; }

        public Location(string name, string symbol, int x, int y)
        {
            nameLocation = name;
            pointName = symbol;
            Point p = new Point(x, y);
            pointLocation = p;
        }
        public string getName()
        {
            return nameLocation;
        }
        public string getPointName()
        {
            return pointName;
        }
        public Point getPoint()
        {
            return pointLocation;
        }
    }
    public class Vertex
    {
        public String name;
        public int status;
        public int predecessor;
        public int pathLength;
        public Vertex(String name)
        {
            this.name = name;
        }
    }

    class SetUpGraph
    {
        public readonly int MAX_VERTICES = 100;
        public int n = 0;
        public int[,] adj;
        public Vertex[] vertexList;
        private readonly int INFINITY = 9999999;
        private readonly int PERMANENT = 2;
        private readonly int TEMPORARY = 1;
        private readonly int NIL = -1;
        public List<Point> listPoint = new List<Point>();
        public List<Point> pathIndex = new List<Point>();

        public SetUpGraph()
        {
            adj = new int[MAX_VERTICES, MAX_VERTICES];
            vertexList = new Vertex[MAX_VERTICES];
        }

        private void Dijkstra(int s)
        {
            int v, c;
            for (v = 0; v < n; v++)
            {
                vertexList[v].status = TEMPORARY;
                vertexList[v].pathLength = INFINITY;
                vertexList[v].predecessor = NIL;
            }
            vertexList[s].pathLength = 0;
            while (true)
            {
                c = TempVertexWithMinPL();
                if (c == NIL)
                    return;
                vertexList[c].status = PERMANENT;
                for (v = 0; v < n; v++)
                {
                    if (IsAdjacent(c, v) && vertexList[v].status == TEMPORARY)
                    {
                        if (vertexList[c].pathLength + adj[c, v] < vertexList[v].pathLength)
                        {
                            vertexList[v].predecessor = c;
                            vertexList[v].pathLength = vertexList[c].pathLength + adj[c, v];
                        }
                    }
                }
            }
        }
        public void FindPaths(string source, string last,TextBox tbKM,TextBox tbLiter, TextBox tbCost, TextBox tbPath)
        {
            int s = GetIndex(source);
            Dijkstra(s);

            int v = Convert.ToInt32(last);
            {
                if (v != s)
                {
                    if (vertexList[v].pathLength == INFINITY)
                    {
                        tbPath.Text += "\tNo path \n";
                    }
                    else
                    {
                        FindPath(s, v,tbKM, tbLiter, tbCost, tbPath);
                    }
                }
            }
        }

        public void FindPath(int s, int v, TextBox tbKM, TextBox tbLiter, TextBox tbCost, TextBox tbPath)
        {
            int i, u;
            int[] path = new int[n];
            int sd = 0;
            double sl = 0;
            int km = 0;
            int count = 0;
            while (v != s)
            {
                count++;
                path[count] = v;
                u = vertexList[v].predecessor;
                km += adj[u, v];
                v = u;
            }
            sl = km * 0.09;
            sd = km * 2043;
            count++;
            if (count >= n)
            {
                MessageBox.Show("Error!", "Notify!");

            }
            path[count] = s;
            for (i = count; i >= 1; i--)
            {
                pathIndex.Add(listPoint[path[i]]);
                if (tbPath.Text == "")
                {
                    tbPath.Text += vertexList[path[i]].name;
                }
                else
                {
                    tbPath.Text += " -> " + vertexList[path[i]].name;
                }
            }
            tbKM.Text = $"{km} KM";
            tbLiter.Text = $"{sl} liters";
            tbCost.Text = $"{sd} VNĐ";
        }

        public int GetIndex(string s)
        {
            for (int i = 0; i < n; i++)
            {
                if (s.Equals(vertexList[i].name))
                    return i;
            }
            throw new System.InvalidOperationException("Invalid Vertex");
        }

        public void InsertVertex(string name)
        {
            vertexList[n++] = new Vertex(name);
        }
        private bool IsAdjacent(int u, int v)
        {
            return adj[u, v] != 0;
        }

        private int TempVertexWithMinPL()
        {
            int min = INFINITY;
            int x = NIL;
            for (int v = 0; v < n; v++)
            {
                if (vertexList[v].status == TEMPORARY && vertexList[v].pathLength < min)
                {
                    min = vertexList[v].pathLength;
                    x = v;
                }
            }
            return x;
        }

        public void InsertEdge(string v1, string v2, int v3)
        {
            int i = GetIndex(v1);
            int j = GetIndex(v2);
            adj[i, j] = v3;
            adj[j, i] = v3;
        }
    }

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
