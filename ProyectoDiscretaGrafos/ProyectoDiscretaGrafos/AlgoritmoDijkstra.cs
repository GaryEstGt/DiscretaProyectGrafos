using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoDiscretaGrafos
{
    public partial class AlgoritmoDijkstra : Form
    {
        public static int posVertice;
        public static int posArista;
        public AlgoritmoDijkstra()
        {
            InitializeComponent();
        }

        private void AlgoritmoDijkstra_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < posVertice; i++)
            {
                comboBox1.Items.Add(Program.vertices[i].getNombre());
                comboBox2.Items.Add(Program.vertices[i].getNombre());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int IdInicial = 0;
            int IdFinal = 0;
            for (int i = 0; i < Program.vertices.Length; i++)
            {
                if (Program.vertices[i].getNombre()==comboBox1.Text)
                {
                    IdInicial = Program.vertices[i].getId();
                }
                if (Program.vertices[i].getNombre() == comboBox2.Text)
                {
                    IdFinal = Program.vertices[i].getId();
                }
            }
                for (int i = 0; i < Program.vertices.Length; i++)
                {
                    if (comboBox1.Text==Program.vertices[i].getNombre())
                    {
                        Program.vertices[i].setId(1);
                    }
                    if(comboBox2.Text== Program.vertices[i].getNombre())
                    {
                        Program.vertices[i].setId(Program.vertices.Length);
                    }
                    if(i!=0 && i!= Program.vertices.Length-1)
                    {
                        Program.vertices[i].setId(i + 1);
                    }
                }
                for (int i = 0; i < Program.aristas.Length; i++)
                {
                    for (int x = 0; x < Program.vertices.Length; x++)
                    {
                        if((Program.vertices[x] != null) && (Program.aristas[i] != null))
                    {
                        if (Program.vertices[x].getNombre() == Program.aristas[i].getInicial().getNombre())
                        {
                            Program.aristas[i].getInicial().setId(Program.vertices[x].getId());
                        }
                        if (Program.vertices[x].getNombre() == Program.aristas[i].getFinal().getNombre())
                        {
                            Program.aristas[i].getFinal().setId(Program.vertices[x].getId());
                        }
                    }
                        
                    }
                    Program.Implementacion.addEdge(Program.aristas[i].getInicial().getId(), Program.aristas[i].getFinal().getId(), Program.aristas[i].getPeso(), true);
                }
            for (int i = 0; i < Program.vertices.Length; i++)
            {
                if (Program.vertices[i].getNombre() == comboBox1.Text)
                {
                    IdInicial = Program.vertices[i].getId();
                }
                if (Program.vertices[i].getNombre() == comboBox2.Text)
                {
                    IdFinal = Program.vertices[i].getId();
                }
            }

            Program.Implementacion.dijkstra(IdInicial);
                Program.Implementacion.printShortestPath(IdFinal);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
