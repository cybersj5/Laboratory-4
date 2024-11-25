using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared;
using View;

namespace lab
{
    public partial class Form1 : Form, IView
    {
        public Form1()
        {
            InitializeComponent();
        }
        public event Action<EventArgs> AddDataEvent;
        public event Action<int> DeleteDataEvent;
        public void RedrawForm(IEnumerable<EventArgs> data)
        {
            listView1.Items.Clear();
            foreach (StudentEventArgs item in data)
            {
                ListViewItem listViewItem = new ListViewItem(item.Name);
                listViewItem.SubItems.Add(item.Speciality);
                listViewItem.SubItems.Add(item.Group);
                listView1.Items.Add(listViewItem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteDataEvent?.Invoke(listView1.SelectedIndices[0]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddDataEvent?.Invoke(new StudentEventArgs()
            {
                Name = textBox1.Text,
                Speciality = textBox2.Text,
                Group = textBox3.Text,
            });
        }
    }
}
