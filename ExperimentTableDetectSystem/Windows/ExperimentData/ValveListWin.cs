using ExperimentTableDetectSystem.NPOI;
using ExperimentTableDetectSystem.service;
using ExperimentTableDetectSystem.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExperimentTableDetectSystem.Windows.ExperimentData
{
    public partial class ValveListWin : MetroFramework.Forms.MetroForm
    {
        public string Sql;
        public string StartTime;
        public string EndTime;
        public static string id;
        public static int n;
        SearchHelper searchhelper;
        DBHelper dbhelper;
        NPOIHelper npoi = new NPOIHelper();

        public ValveListWin()
        {
            InitializeComponent();
        }

        private void ValveListWin_Load(object sender, EventArgs e)
        {
            searchhelper = SearchHelper.GetInstance();
            this.StartTime = DataSearchByTimeWin.startTime;
            this.EndTime = DataSearchByTimeWin.endTime;
            searchhelper.SearchByTime(StartTime, EndTime, dgv);

        }


        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView dataRowView = this.dgv.SelectedRows[0].DataBoundItem as DataRowView;
            
            object temp1 = dataRowView[0];
            object temp2 = dataRowView[1];
            id = temp1.ToString();
            n = Convert.ToInt32(temp2);
            HistoryDataWin2 win = new HistoryDataWin2();
            win.Show();
            

        }
    }
}
