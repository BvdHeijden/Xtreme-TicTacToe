using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xtreme_TicTacToe
{
    public partial class Form1 : Form
    {
        public int turn = 1;

        public List<List<Control>> fields = new List<List<Control>>();
        public List<Control> field1 = new List<Control>();
        public List<Control> field2 = new List<Control>();
        public List<Control> field3 = new List<Control>();
        public List<Control> field4 = new List<Control>();
        public List<Control> field5 = new List<Control>();
        public List<Control> field6 = new List<Control>();
        public List<Control> field7 = new List<Control>();
        public List<Control> field8 = new List<Control>();
        public List<Control> field9 = new List<Control>();

        public List<List<int>> wins = new List<List<int>>();
        public List<bool> won = new List<bool>() { false, false, false, false, false, false, false, false, false };

        public Form1()
        {
            InitializeComponent();

            def_fields();

            foreach (Control btn in this.Controls)
            {
                btn.Tag = "-";
            }

        }

        private void button_Click(object sender, EventArgs e)
        {
            Control btn = sender as Control;
            int field = 0;
            int pos = 0;

            //check in welk field
            foreach (List<Control> fld in fields)
            {
                if (fld.IndexOf(btn) != -1)
                {
                    field = fields.IndexOf(fld) + 1;
                    pos = fld.IndexOf(btn) + 1;
                    break;
                }
            }


            // vul X of O in
            btn.Enabled = false;

            if (turn == 1)
            {
                btn.BackgroundImage = Properties.Resources.cross;
                btn.Tag = "x";
            }
            else if (turn == -1)
            {
                btn.BackgroundImage = Properties.Resources.circle;
                btn.Tag = "o";
            }

            //check voor 3opeenrij
            check_rijtje(field-1, btn.Tag.ToString());

            //Zet de goede knopjes aan voor de volgende
            set_board(pos);

            //volgende is aan de beurt
            turn = turn * -1;
        }

        private void set_board(int pos)
        {
            //set everything disabled
            foreach(Control b in this.Controls)
            {
                b.Enabled = false;
            }

            //Make everything grey except finished fields
            foreach(List<Control> f in fields)
            {
                if (!won[fields.IndexOf(f)])
                {
                    foreach(Control b in f)
                    {
                        b.BackColor = Color.LightGray;
                    }
                }
            }

            //Check if field is still available
            if (!won[pos - 1])
            {
                foreach (Control b in fields[pos - 1])
                {
                    if (b.Tag.ToString()== "-")
                    {
                        b.Enabled = true;
                        b.BackColor = Color.White;
                    }
                }
            }
            else
            {
                foreach (List<Control> f in fields)
                {
                    if (!won[fields.IndexOf(f)])
                    {
                        foreach(Control bt in f)
                        {
                            if(bt.Tag.ToString() == "-")
                            {
                                bt.Enabled = true;
                            }
                            bt.BackColor = Color.White;
                        }
                    } 
                }
            }
            
        }

        private void check_rijtje(int fld, string turn)
        {
            List<Control> field = fields[fld];

            foreach(List<int> win in wins)
            {
                if (field[win[0]-1].Tag.ToString() == turn && field[win[1]-1].Tag.ToString() == turn && field[win[2]-1].Tag.ToString() == turn)
                {
                    if (turn == "x")
                    {
                        foreach (Control b in field)
                        {
                            b.BackColor = Color.Red;
                        }
                    } else if (turn == "o"){
                        foreach (Control b in field)
                        {
                            b.BackColor = Color.Blue;
                        }
                    }

                    won[fld] = true;
                }
            }

        }

        private void def_fields()
        {

            wins.Add(new List<int>() { 1, 2, 3 });
            wins.Add(new List<int>() { 4, 5, 6 });
            wins.Add(new List<int>() { 7, 8, 9 });
            wins.Add(new List<int>() { 1, 4, 7 });
            wins.Add(new List<int>() { 2, 5, 8 });
            wins.Add(new List<int>() { 3, 6, 9 });
            wins.Add(new List<int>() { 1, 5, 9 });
            wins.Add(new List<int>() { 3, 5, 7 });


            field1.Add(button1_1);
            field1.Add(button1_2);
            field1.Add(button1_3);
            field1.Add(button1_4);
            field1.Add(button1_5);
            field1.Add(button1_6);
            field1.Add(button1_7);
            field1.Add(button1_8);
            field1.Add(button1_9);
            fields.Add(field1);

            field2.Add(button2_1);
            field2.Add(button2_2);
            field2.Add(button2_3);
            field2.Add(button2_4);
            field2.Add(button2_5);
            field2.Add(button2_6);
            field2.Add(button2_7);
            field2.Add(button2_8);
            field2.Add(button2_9);
            fields.Add(field2);

            field3.Add(button3_1);
            field3.Add(button3_2);
            field3.Add(button3_3);
            field3.Add(button3_4);
            field3.Add(button3_5);
            field3.Add(button3_6);
            field3.Add(button3_7);
            field3.Add(button3_8);
            field3.Add(button3_9);
            fields.Add(field3);

            field4.Add(button4_1);
            field4.Add(button4_2);
            field4.Add(button4_3);
            field4.Add(button4_4);
            field4.Add(button4_5);
            field4.Add(button4_6);
            field4.Add(button4_7);
            field4.Add(button4_8);
            field4.Add(button4_9);
            fields.Add(field4);

            field5.Add(button5_1);
            field5.Add(button5_2);
            field5.Add(button5_3);
            field5.Add(button5_4);
            field5.Add(button5_5);
            field5.Add(button5_6);
            field5.Add(button5_7);
            field5.Add(button5_8);
            field5.Add(button5_9);
            fields.Add(field5);

            field6.Add(button6_1);
            field6.Add(button6_2);
            field6.Add(button6_3);
            field6.Add(button6_4);
            field6.Add(button6_5);
            field6.Add(button6_6);
            field6.Add(button6_7);
            field6.Add(button6_8);
            field6.Add(button6_9);
            fields.Add(field6);

            field7.Add(button7_1);
            field7.Add(button7_2);
            field7.Add(button7_3);
            field7.Add(button7_4);
            field7.Add(button7_5);
            field7.Add(button7_6);
            field7.Add(button7_7);
            field7.Add(button7_8);
            field7.Add(button7_9);
            fields.Add(field7);

            field8.Add(button8_1);
            field8.Add(button8_2);
            field8.Add(button8_3);
            field8.Add(button8_4);
            field8.Add(button8_5);
            field8.Add(button8_6);
            field8.Add(button8_7);
            field8.Add(button8_8);
            field8.Add(button8_9);
            fields.Add(field8);

            field9.Add(button9_1);
            field9.Add(button9_2);
            field9.Add(button9_3);
            field9.Add(button9_4);
            field9.Add(button9_5);
            field9.Add(button9_6);
            field9.Add(button9_7);
            field9.Add(button9_8);
            field9.Add(button9_9);
            fields.Add(field9);


        }
    }
}
