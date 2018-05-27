using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListBox;

namespace hw
{
    public partial class Form1 : Form
    {
        private List<string> _leftList;
        private List<string> _rightList;

        public Form1()
        {
            InitializeComponent();
            CreateList();
            SetListBoxDataSource();
            ChangeData();
        }

        private void CreateList()
        {
            _leftList = new List<string>
            {
                "農夫","狼","羊","菜"
            };
            _rightList = new List<string>();
        }
        private void SetListBoxDataSource()
        {
            listBox1.SelectionMode = SelectionMode.One;
            listBox2.SelectionMode = SelectionMode.One;
        }
        private void ChangeData()
        {
            listBox1.DataSource = null;
            listBox2.DataSource = null;
            listBox1.DataSource = _leftList;
            listBox2.DataSource = _rightList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string farmer = "農夫";
            string w = "狼";
            string g = "羊";
            string s = "菜";
            if (_leftList.Contains(farmer))         //判斷有沒有農夫
            {
                if ((string)listBox1.SelectedItem == farmer) //農夫自己渡河
                {
                    _leftList.Remove(farmer); //左邊移除農夫
                    _rightList.Add(farmer);   //右邊增加農夫
                    ChangeData(); // 重整
                }
                else
                {
                    string item = (string)listBox1.SelectedItem;  // 農夫帶東西過去
                    _leftList.Remove(farmer); //左邊移除農夫
                    _rightList.Add(farmer);   //右邊增加農夫
                    _leftList.Remove(item);   //左邊移除東西
                    _rightList.Add(item);     //右邊增加東西
                    ChangeData();             // 重整
                }
                if (_leftList.Contains(w) && _leftList.Contains(g))
                {
                    MessageBox.Show("羊被吃了！失敗！！！");
                }
                if (_leftList.Contains(g) && _leftList.Contains(s))
                {
                    MessageBox.Show("菜被吃了！失敗！！！");
                }
                if (_rightList.Contains(w) && _rightList.Contains(g) && _rightList.Contains(s))
                {
                    MessageBox.Show("渡河成功");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string farmer = "農夫";
            string w = "狼";
            string g = "羊";
            string s = "菜";
            if (_rightList.Contains(farmer))         //判斷有沒有農夫
            {
                if ((string)listBox2.SelectedItem == farmer)
                {
                    _rightList.Remove(farmer);
                    _leftList.Add(farmer);
                    ChangeData();
                }
                else
                {
                    string item = (string)listBox2.SelectedItem;
                    _rightList.Remove(farmer);
                    _leftList.Add(farmer);
                    _rightList.Remove(item);
                    _leftList.Add(item);
                    ChangeData();
                }

                if (_rightList.Contains(w) && _rightList.Contains(g))
                {
                    MessageBox.Show("羊被吃了！失敗！！！");
                }
                if (_rightList.Contains(g) && _rightList.Contains(s))
                {
                    MessageBox.Show("菜被吃了！失敗！！！");
                }

            }
        }
    }
}
