namespace Matchmaker {
    partial class Simulator {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.PlayerbaseSize = new System.Windows.Forms.TextBox();
            this.RegeneratePlayerbase = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SimulatorPanel = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.MedianGainDisplay = new System.Windows.Forms.Label();
            this.MedianGainSlider = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SkillDistributionDisplay = new System.Windows.Forms.Label();
            this.SkillDistributionSlider = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.StartSimulation = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.MatchResults = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Distribution = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label6 = new System.Windows.Forms.Label();
            this.SkillCenter = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SimulatorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MedianGainSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SkillDistributionSlider)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Distribution)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player count:";
            // 
            // PlayerbaseSize
            // 
            this.PlayerbaseSize.Location = new System.Drawing.Point(81, 19);
            this.PlayerbaseSize.Name = "PlayerbaseSize";
            this.PlayerbaseSize.Size = new System.Drawing.Size(41, 20);
            this.PlayerbaseSize.TabIndex = 1;
            this.PlayerbaseSize.Text = "10000";
            // 
            // RegeneratePlayerbase
            // 
            this.RegeneratePlayerbase.Location = new System.Drawing.Point(6, 84);
            this.RegeneratePlayerbase.Name = "RegeneratePlayerbase";
            this.RegeneratePlayerbase.Size = new System.Drawing.Size(116, 23);
            this.RegeneratePlayerbase.TabIndex = 3;
            this.RegeneratePlayerbase.Text = "Regenerate players";
            this.RegeneratePlayerbase.UseVisualStyleBackColor = true;
            this.RegeneratePlayerbase.Click += new System.EventHandler(this.RegeneratePlayerbase_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.SkillCenter);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.RegeneratePlayerbase);
            this.groupBox1.Controls.Add(this.PlayerbaseSize);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(128, 114);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Playerbase";
            // 
            // SimulatorPanel
            // 
            this.SimulatorPanel.Controls.Add(this.label5);
            this.SimulatorPanel.Controls.Add(this.MedianGainDisplay);
            this.SimulatorPanel.Controls.Add(this.MedianGainSlider);
            this.SimulatorPanel.Controls.Add(this.label4);
            this.SimulatorPanel.Controls.Add(this.label3);
            this.SimulatorPanel.Controls.Add(this.SkillDistributionDisplay);
            this.SimulatorPanel.Controls.Add(this.SkillDistributionSlider);
            this.SimulatorPanel.Controls.Add(this.label2);
            this.SimulatorPanel.Controls.Add(this.StartSimulation);
            this.SimulatorPanel.Location = new System.Drawing.Point(147, 13);
            this.SimulatorPanel.Name = "SimulatorPanel";
            this.SimulatorPanel.Size = new System.Drawing.Size(285, 236);
            this.SimulatorPanel.TabIndex = 4;
            this.SimulatorPanel.TabStop = false;
            this.SimulatorPanel.Text = "Simulator";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(273, 41);
            this.label5.TabIndex = 8;
            this.label5.Text = "Most likely amount of skill rating to be awarded or taken away after a match. A l" +
    "ower value means more precise adaptation, but using higher values is faster.";
            // 
            // MedianGainDisplay
            // 
            this.MedianGainDisplay.Location = new System.Drawing.Point(179, 119);
            this.MedianGainDisplay.Name = "MedianGainDisplay";
            this.MedianGainDisplay.Size = new System.Drawing.Size(100, 13);
            this.MedianGainDisplay.TabIndex = 7;
            this.MedianGainDisplay.Text = "25";
            this.MedianGainDisplay.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MedianGainSlider
            // 
            this.MedianGainSlider.LargeChange = 10;
            this.MedianGainSlider.Location = new System.Drawing.Point(6, 135);
            this.MedianGainSlider.Maximum = 200;
            this.MedianGainSlider.Name = "MedianGainSlider";
            this.MedianGainSlider.Size = new System.Drawing.Size(273, 45);
            this.MedianGainSlider.TabIndex = 6;
            this.MedianGainSlider.TickFrequency = 10;
            this.MedianGainSlider.Value = 50;
            this.MedianGainSlider.Scroll += new System.EventHandler(this.MedianGainSlider_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Median gain:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(273, 41);
            this.label3.TabIndex = 4;
            this.label3.Text = "Skill rating multiplier. As skill ratings are internally represented as numbers b" +
    "etween 0 and 1, this will make displaying them more human-friendly.";
            // 
            // SkillDistributionDisplay
            // 
            this.SkillDistributionDisplay.Location = new System.Drawing.Point(179, 16);
            this.SkillDistributionDisplay.Name = "SkillDistributionDisplay";
            this.SkillDistributionDisplay.Size = new System.Drawing.Size(100, 13);
            this.SkillDistributionDisplay.TabIndex = 3;
            this.SkillDistributionDisplay.Text = "5000";
            this.SkillDistributionDisplay.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SkillDistributionSlider
            // 
            this.SkillDistributionSlider.LargeChange = 1000;
            this.SkillDistributionSlider.Location = new System.Drawing.Point(6, 32);
            this.SkillDistributionSlider.Maximum = 10000;
            this.SkillDistributionSlider.Minimum = 1000;
            this.SkillDistributionSlider.Name = "SkillDistributionSlider";
            this.SkillDistributionSlider.Size = new System.Drawing.Size(273, 45);
            this.SkillDistributionSlider.SmallChange = 100;
            this.SkillDistributionSlider.TabIndex = 2;
            this.SkillDistributionSlider.TickFrequency = 1000;
            this.SkillDistributionSlider.Value = 5000;
            this.SkillDistributionSlider.Scroll += new System.EventHandler(this.SkillDistributionSlider_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Skill distribution:";
            // 
            // StartSimulation
            // 
            this.StartSimulation.Location = new System.Drawing.Point(204, 207);
            this.StartSimulation.Name = "StartSimulation";
            this.StartSimulation.Size = new System.Drawing.Size(75, 23);
            this.StartSimulation.TabIndex = 0;
            this.StartSimulation.Text = "Start";
            this.StartSimulation.UseVisualStyleBackColor = true;
            this.StartSimulation.Click += new System.EventHandler(this.StartSimulation_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.MatchResults);
            this.groupBox3.Location = new System.Drawing.Point(439, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(241, 236);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Last match results";
            // 
            // MatchResults
            // 
            this.MatchResults.Location = new System.Drawing.Point(6, 18);
            this.MatchResults.Multiline = true;
            this.MatchResults.Name = "MatchResults";
            this.MatchResults.ReadOnly = true;
            this.MatchResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MatchResults.Size = new System.Drawing.Size(229, 212);
            this.MatchResults.TabIndex = 0;
            this.MatchResults.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Distribution);
            this.groupBox2.Location = new System.Drawing.Point(12, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(128, 117);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Skill distribution";
            // 
            // Distribution
            // 
            this.Distribution.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.Distribution.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.Distribution.Legends.Add(legend2);
            this.Distribution.Location = new System.Drawing.Point(0, 19);
            this.Distribution.Name = "Distribution";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.Distribution.Series.Add(series2);
            this.Distribution.Size = new System.Drawing.Size(122, 92);
            this.Distribution.TabIndex = 0;
            this.Distribution.TabStop = false;
            this.Distribution.Text = "chart1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Center (%):";
            // 
            // SkillCenter
            // 
            this.SkillCenter.Location = new System.Drawing.Point(81, 45);
            this.SkillCenter.Name = "SkillCenter";
            this.SkillCenter.Size = new System.Drawing.Size(41, 20);
            this.SkillCenter.TabIndex = 2;
            this.SkillCenter.Text = "40";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Relative initial ranking.";
            // 
            // Simulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 261);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.SimulatorPanel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Simulator";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Matchmaking Simulator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.SimulatorPanel.ResumeLayout(false);
            this.SimulatorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MedianGainSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SkillDistributionSlider)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Distribution)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PlayerbaseSize;
        private System.Windows.Forms.Button RegeneratePlayerbase;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox SimulatorPanel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox MatchResults;
        private System.Windows.Forms.Button StartSimulation;
        private System.Windows.Forms.TrackBar SkillDistributionSlider;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label SkillDistributionDisplay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label MedianGainDisplay;
        private System.Windows.Forms.TrackBar MedianGainSlider;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart Distribution;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox SkillCenter;
        private System.Windows.Forms.Label label7;
    }
}

