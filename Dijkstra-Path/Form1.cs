using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DijkstraTest2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<Location> Locations = new List<Location>();
        SetUpGraph g = new SetUpGraph();
        private void Form1_Load(object creator, EventArgs e) //Goi ten cac dia diem va set vi tri
        {
            Location binhPhuoc = new Location("Bình Phước", "A", 541, 65);
            Location saiGon = new Location("Sài Gòn", "B", 502, 164);
            Location tayNinh = new Location("Tây Ninh", "C", 431, 105);
            Location vungTau = new Location("Vũng Tàu", "D", 590, 198);
            Location tienGiang = new Location("Tiền Giang", "E", 432, 212);
            Location anGiang = new Location("An Giang", "F", 296, 210);
            Location hauGiang = new Location("Hậu Giang", "G", 348, 286);
            Location traVinh = new Location("Trà Vinh", "H", 462, 286);
            Location kienGiang = new Location("Kiên Giang", "I", 290, 286);
            Location caMau = new Location("Cà Mau", "K", 260, 345);
            Locations.Add(binhPhuoc);
            Locations.Add(saiGon);
            Locations.Add(tayNinh);
            Locations.Add(vungTau);
            Locations.Add(tienGiang);
            Locations.Add(anGiang);
            Locations.Add(hauGiang);
            Locations.Add(traVinh);
            Locations.Add(kienGiang);
            Locations.Add(caMau);
            cbSource.Items.Add("Bình Phước");
            cbSource.Items.Add("Sài Gòn");
            cbSource.Items.Add("Tây Ninh");
            cbSource.Items.Add("Vũng Tàu");
            cbSource.Items.Add("Tiền Giang");
            cbSource.Items.Add("An Giang");
            cbSource.Items.Add("Hậu Giang");
            cbSource.Items.Add("Trà Vinh");
            cbSource.Items.Add("Kiên Giang");
            cbSource.Items.Add("Cà Mau");
            cbDestination.Items.Add("Bình Phước");
            cbDestination.Items.Add("Sài Gòn");
            cbDestination.Items.Add("Tây Ninh");
            cbDestination.Items.Add("Vũng Tàu");
            cbDestination.Items.Add("Tiền Giang");
            cbDestination.Items.Add("An Giang");
            cbDestination.Items.Add("Hậu Giang");
            cbDestination.Items.Add("Trà Vinh");
            cbDestination.Items.Add("Kiên Giang");
            cbDestination.Items.Add("Cà Mau");
            Graphics graph = southMap.CreateGraphics();
            for (int i = 0; i < Locations.Count; i++)
            {
                lvListProvinces.Items.Add(Locations[i].getPointName());
                lvListProvinces.Items[i].SubItems.Add(Locations[i].getName());
                g.listPoint.Add(Locations[i].getPoint());
                g.InsertVertex(Locations[i].getName());
            }
            g.InsertEdge("Tây Ninh", "Bình Phước", 111);
            g.InsertEdge("Vũng Tàu", "Bình Phước", 182);
            g.InsertEdge("Sài Gòn", "Bình Phước", 124);
            g.InsertEdge("Vũng Tàu", "Sài Gòn", 98);
            g.InsertEdge("Tiền Giang", "Sài Gòn", 72);
            g.InsertEdge("An Giang", "Sài Gòn", 235);
            g.InsertEdge("Tây Ninh", "Sài Gòn", 92);
            g.InsertEdge("Trà Vinh", "Sài Gòn", 125);
            g.InsertEdge("Trà Vinh", "Cà Mau", 195);
            g.InsertEdge("Trà Vinh", "Hậu Giang", 124);
            g.InsertEdge("Tiền Giang", "An Giang", 174);
            g.InsertEdge("Trà Vinh", "Tiền Giang", 68);
            g.InsertEdge("An Giang", "Trà Vinh", 187);
            g.InsertEdge("Hậu Giang", "Cà Mau", 130);
            g.InsertEdge("Cà Mau", "Kiên Giang", 106);
            g.InsertEdge("An Giang", "Hậu Giang", 146);
            g.InsertEdge("An Giang", "Kiên Giang", 96);
        }
        //Vẽ bản đồ ra Panel
        private void southMap_Paint(object creator, PaintEventArgs e)
        {
            Graphics graph = southMap.CreateGraphics();
            for (int i = 0; i < Locations.Count; i++)
            {
                SolidBrush brush = new SolidBrush(Color.SeaGreen);
                Brush pointName = new SolidBrush(Color.White);
                graph.FillEllipse(brush, Locations[i].getPoint().X - 3, Locations[i].getPoint().Y - 2, 18, 18);
                graph.DrawString(Locations[i].getPointName(), new Font("Arial", 8), pointName, Locations[i].getPoint().X, Locations[i].getPoint().Y);
            }
            DrawLine();
        }

        private void DrawLine() // Noi cac tuyen duong co the di duoc va da tinh toan chi phi
        {
            DrawLine("Tây Ninh", "Bình Phước");
            DrawLine("Vũng Tàu", "Bình Phước");
            DrawLine("Sài Gòn", "Bình Phước");
            DrawLine("Vũng Tàu", "Sài Gòn");
            DrawLine("Tiền Giang", "Sài Gòn");
            DrawLine("An Giang", "Sài Gòn");
            DrawLine("Tây Ninh", "Sài Gòn");
            DrawLine("Trà Vinh", "Sài Gòn");
            DrawLine("Trà Vinh", "Cà Mau");
            DrawLine("Trà Vinh", "Hậu Giang");
            DrawLine("Tiền Giang", "An Giang");
            DrawLine("Trà Vinh", "Tiền Giang");
            DrawLine("An Giang", "Trà Vinh");
            DrawLine("Hậu Giang", "Cà Mau");
            DrawLine("Cà Mau", "Kiên Giang");
            DrawLine("An Giang", "Hậu Giang");
            DrawLine("An Giang", "Kiên Giang");
        }
        private void DrawLine(string a, string b)
        {
            Graphics graph = southMap.CreateGraphics();
            int x = g.GetIndex(a);
            int y = g.GetIndex(b);
            Pen p = new Pen(Color.Black, 2);
            Point point1 = new Point(g.listPoint[x].X, g.listPoint[x].Y);
            Point point2 = new Point(g.listPoint[y].X, g.listPoint[y].Y);
            graph.DrawLine(p, point1, point2);
            graph.DrawString($"{g.adj[x, y]}", new Font("Fira Code", 10), Brushes.Black, new Point((point1.X + point2.X) / 2 - 8, (point1.Y + point2.Y) / 2 + 8));
        }
        private void cbSource_SelectedIndexChanged(object creator, EventArgs e)
        {
            if (cbSource.SelectedIndex != -1 && cbDestination.SelectedIndex != -1)
            {
                southMap.Controls.Clear();
                southMap.Refresh();
                DrawLine();
                g.pathIndex.Clear();
                tbKM.Clear();
                tbLiter.Clear();
                tbCost.Clear();
                tbPath.Clear();
                g.FindPaths(cbSource.SelectedItem.ToString(), cbDestination.SelectedIndex.ToString(),tbKM,tbLiter, tbCost, tbPath);
                for (int i = 0; i < g.pathIndex.Count - 1; i++)
                {
                    DrawPathLine(i);
                }
            }
            if (cbSource.SelectedIndex == cbDestination.SelectedIndex)
            {
                MessageBox.Show("Unresponsive\n Starting point must not be the same as destination !", "Notify!");
            }
        }
        private void cbDestination_SelectedIndexChanged(object creator, EventArgs e)
        {
            if (cbSource.SelectedIndex != -1 && cbDestination.SelectedIndex != -1)
            {
                southMap.Controls.Clear();
                southMap.Refresh();
                DrawLine();
                g.pathIndex.Clear();
                tbKM.Clear();
                tbLiter.Clear();
                tbCost.Clear();
                tbPath.Clear();
                g.FindPaths(cbSource.SelectedItem.ToString(), cbDestination.SelectedIndex.ToString(),tbKM ,tbLiter, tbCost, tbPath);
                for (int i = 0; i < g.pathIndex.Count - 1; i++)
                {
                    DrawPathLine(i);
                }
            }
            if (cbSource.SelectedIndex == cbDestination.SelectedIndex)
            {
                MessageBox.Show("Unresponsive\n Starting point must not be the same as destination !", "Notify!");
            }    
        }
        //Vẽ lại đường đi ngắn nhất
        private void DrawPathLine(int i)
        {
            Graphics graph = southMap.CreateGraphics();
            Pen p = new Pen(Color.Aqua, 2);
            Point point1 = new Point(g.pathIndex[i].X, g.pathIndex[i].Y);
            Point point2 = new Point(g.pathIndex[i + 1].X, g.pathIndex[i + 1].Y);
            graph.DrawLine(p, point1, point2);
        }

    }
}
