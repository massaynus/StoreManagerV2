using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Manager
{
    public partial class Statistiques : UserControl
    {
        public Statistiques()
        {
            InitializeComponent();
        }

        private void Statistiques_Load(object sender, EventArgs e)
        {
            Statistics.StatsManager(1);
            chartMonthly.Series["Ventes/Mois"].Points.AddXY("Janvier", Statistics.ItemsPerMonth[0]);
            chartMonthly.Series["Ventes/Mois"].Points.AddXY("Fevrier", Statistics.ItemsPerMonth[1]);
            chartMonthly.Series["Ventes/Mois"].Points.AddXY("Mars", Statistics.ItemsPerMonth[2]);
            chartMonthly.Series["Ventes/Mois"].Points.AddXY("Avril", Statistics.ItemsPerMonth[3]);
            chartMonthly.Series["Ventes/Mois"].Points.AddXY("Mai", Statistics.ItemsPerMonth[4]);
            chartMonthly.Series["Ventes/Mois"].Points.AddXY("juin", Statistics.ItemsPerMonth[5]);
            chartMonthly.Series["Ventes/Mois"].Points.AddXY("juillet", Statistics.ItemsPerMonth[6]);
            chartMonthly.Series["Ventes/Mois"].Points.AddXY("Août", Statistics.ItemsPerMonth[7]);
            chartMonthly.Series["Ventes/Mois"].Points.AddXY("Spetembre", Statistics.ItemsPerMonth[8]);
            chartMonthly.Series["Ventes/Mois"].Points.AddXY("Octobre", Statistics.ItemsPerMonth[9]);
            chartMonthly.Series["Ventes/Mois"].Points.AddXY("Novembre", Statistics.ItemsPerMonth[10]);
            chartMonthly.Series["Ventes/Mois"].Points.AddXY("Dècembre", Statistics.ItemsPerMonth[11]);
        }
    }
}
