﻿using System;
using System.Windows.Forms;
using UltimateFishBot.Classes;

namespace UltimateFishBot.Forms
{
    public partial class FrmStats : Form
    {
        private static FrmStats inst;
        public static FrmStats GetForm(Manager manag)
        {
            if (inst == null || inst.IsDisposed)
                inst = new FrmStats(manag);
            return inst;
        }

        public FrmStats(Manager manager)
        {
            InitializeComponent();

            m_manager = manager;
            UpdateStats();
        }

        private void frmStats_Load(object sender, EventArgs e)
        {
            this.Text = Translate.GetTranslate("frmStats", "TITLE");
            labelSuccess.Text = Translate.GetTranslate("frmStats", "LABEL_SUCCESS");
            labelNotFound.Text = Translate.GetTranslate("frmStats", "LABEL_NOT_FOUND");
            labelNotEared.Text = Translate.GetTranslate("frmStats", "LABEL_NOT_EARED");
            labelTotal.Text = Translate.GetTranslate("frmStats", "LABEL_TOTAL");
            buttonReset.Text = Translate.GetTranslate("frmStats", "BUTTON_RESET");
            buttonClose.Text = Translate.GetTranslate("frmStats", "BUTTON_CLOSE");
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            labelSuccessCount.Text = "0";
            labelNotFoundCount.Text = "0";
            labelNotEaredCount.Text = "0";
            labelTotalCount.Text = "0";

            m_manager.ResetFishingStats();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timerUpdateStats_Tick(object sender, EventArgs e)
        {
            UpdateStats();
        }

        private void UpdateStats()
        {
            UltimateFishBot.Classes.FishingStats stats = m_manager.GetFishingStats();
            labelSuccessCount.Text = stats.TotalSuccessFishing.ToString();
            labelNotFoundCount.Text = stats.TotalNotFoundFish.ToString();
            labelNotEaredCount.Text = stats.TotalNotHeardFish.ToString();
            labelTotalCount.Text = stats.Total().ToString();
        }

        Manager m_manager;
    }
}
