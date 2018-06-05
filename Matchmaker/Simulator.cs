using MatchmakerEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Matchmaker {
    public partial class Simulator : Form {
        public float TimeScale = 10;

        List<SimulatedPlayer> Playerbase;
        SimulatedQueue Queue;
        Timer SimulatorTimer;
        float SimulatedTime;
        string LastEvent;

        public Simulator() {
            InitializeComponent();
            SimulatorPanel.Enabled = false;
            Distribution.Visible = false;
        }

        void UpdateSetup() {
            Queue.SkillRange = SkillDistributionSlider.Value;
            Player.MedianGain = MedianGainSlider.Value / 10000f;
            MedianGainDisplay.Text = ((int)(Player.MedianGain * Queue.SkillRange)).ToString();
        }

        void RegeneratePlayerbase_Click(object sender, EventArgs e) {
            int PlayerCount = int.Parse(PlayerbaseSize.Text);
            Player.RedistributionCenter = float.Parse(SkillCenter.Text) / 100;
            Playerbase = new List<SimulatedPlayer>(PlayerCount);
            for (int i = 0; i < PlayerCount; ++i)
                Playerbase.Add(new SimulatedPlayer());
            Queue = new SimulatedQueue();
            SimulatedTime = 0;
            LastEvent = string.Empty;
            SimulatorPanel.Enabled = true;
            UpdateDistribution();
            Distribution.Visible = true;
            UpdateSetup();
        }

        void UpdateDistribution() {
            Distribution.Series.Clear();
            Series Plot = new Series {
                ChartType = SeriesChartType.Candlestick,
                Color = Color.Red,
                IsValueShownAsLabel = false,
                IsXValueIndexed = true
            };
            Distribution.Series.Add(Plot);
            const int Precision = 100;
            int[] Groups = new int[Precision + 1];
            if (SimulatedTime != 0)
                for (int i = 0, c = Playerbase.Count; i < c; ++i)
                    ++Groups[(int)(Playerbase[i].SkillRating * Precision)];
            else
                for (int i = 0, c = Playerbase.Count; i < c; ++i)
                    ++Groups[(int)(Playerbase[i].ActualSkill * Precision)];
            int Peak = 0;
            for (int i = 0; i <= Precision; ++i) {
                Plot.Points.AddXY(i * Queue.SkillRange / Precision, Groups[i]);
                if (Peak < Groups[i])
                    Peak = Groups[i];
            }
            Axis Y = Distribution.ChartAreas[0].AxisY;
            Y.Enabled = AxisEnabled.False;
            Y.Maximum = Peak;
            Distribution.Invalidate();
        }

        void SimulatorTick(object sender, EventArgs e) {
            float Tick = TimeScale * SimulatorTimer.Interval / 1000;
            SimulatedTime += Tick;
            for (int i = 0, c = Playerbase.Count; i < c; ++i)
                Playerbase[i].QueueSimulation(Queue, Tick);
            Queue.SimulatorTick(Tick);
            if (Queue.Result.Length != 0) {
                LastEvent = Queue.Result.ToString().TrimEnd();
                Queue.Result = new StringBuilder();
                UpdateDistribution();
            }
            StringBuilder Display = new StringBuilder();
            Display.Append("Simulated time: ").AppendLine(TimeSpan.FromSeconds(SimulatedTime).ToString())
                .Append("Players in queue: ").AppendLine(Queue.PlayersIn.ToString())
                .Append("Matches played: ").AppendLine(Queue.MatchesPlayed.ToString())
                .AppendLine().Append(LastEvent);
            MatchResults.Text = Display.ToString();
        }

        void StartSimulation_Click(object sender, EventArgs e) {
            if (StartSimulation.Text == "Start") {
                StartSimulation.Text = "Pause";
                SimulatorTimer = new Timer() { Interval = 10 };
                SimulatorTimer.Tick += SimulatorTick;
                SimulatorTimer.Start();
            } else {
                StartSimulation.Text = "Start";
                SimulatorTimer.Stop();
                SimulatorTimer.Dispose();
            }
        }

        void SkillDistributionSlider_Scroll(object sender, EventArgs e) {
            SkillDistributionDisplay.Text = SkillDistributionSlider.Value.ToString();
            UpdateSetup();
        }

        private void MedianGainSlider_Scroll(object sender, EventArgs e) {
            UpdateSetup();
        }
    }
}