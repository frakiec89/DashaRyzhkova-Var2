using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DashaRyzhkova
{
    public partial class Form1 : Form
    {
        private const int n = 40; // кол-во недель

        private WeeksManager vs = new WeeksManager(n);


        public Form1()
        {
            InitializeComponent();

            tbHeight.Text = "160";
            tbWeight.Text = "60";

            this.Text = "Калькулятор  веса";
            cbTerm.DataSource = vs.Weeks;
        }

        public void BtCalculate_Click(object sender, EventArgs e)
        {
            double x, y;
            y = 0;
            try
            {
                 x = Convert.ToDouble(tbHeight.Text);
                 y = Convert.ToDouble(tbWeight.Text);
            }
            catch
            {
                tbRezult.Text = "Введите нормальные значения";
                return;
            }

             var  z=cbTerm.SelectedItem as Week;

            tbRezult.Text = Convert.ToString(y+ z.Key*0.4 + " кг на " +  z.Key +" неделе" );
            
      
        }
    }

    public class WeeksManager
    {
        public List<Week> Weeks { get; private set; }  

        public WeeksManager (int count)
        {
            Weeks = new List<Week>();
            for (int i = 1; i <= count; i++)
            Weeks.Add(new Week { Name = string.Format("{0} неделя ", i), Key = i });
        }
    }



    public  class Week
    {
        public string  Name { get;  set; }

        public int Key { get;  set; }

        public override string ToString()
        {
            return Name; 
        }
    }
}
