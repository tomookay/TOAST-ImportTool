using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace ImportTool
{
    public partial class frmProgress : Form
    {
        private readonly CancellationTokenSource? _cts;
        private readonly Stopwatch _stopwatch;
        private readonly System.Windows.Forms.Timer _uiTimer;
        private bool _isIndeterminate;

        private ProgressBar progressBar1;
        private Label lblStatus;
        private Label lblPercent;
        private Button btnCancel;

        public frmProgress(CancellationTokenSource? cts)
        {
            _cts = cts;
            InitializeComponent();

            // basic progress config
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            lblStatus.Text = string.Empty;
            lblPercent.Text = "0%";

            // wire cancel only if token source provided
            if (_cts != null)
            {
                btnCancel.Click += BtnCancel_Click;
                btnCancel.Enabled = true;
                btnCancel.Visible = true;
            }
            else
            {
                btnCancel.Visible = false;
            }

            // prevent form being closed by the X; user should cancel via button
            ControlBox = _cts != null ? true : true; // keep control box so user can still close if needed
            StartPosition = FormStartPosition.CenterParent;
            Text = "Processing";

            _stopwatch = Stopwatch.StartNew();
            _uiTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            _uiTimer.Tick += UiTimer_Tick;
            _uiTimer.Start();
        }

        // Safe UI update from background thread
        public void SetProgress(int percent, string status)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => SetProgress(percent, status)));
                return;
            }

            // If percent < 0 use indeterminate mode (marquee)
            if (percent < 0)
            {
                if (!_isIndeterminate)
                {
                    _isIndeterminate = true;
                    progressBar1.Style = ProgressBarStyle.Marquee;
                }

                lblPercent.Text = string.Empty;
                lblStatus.Text = status ?? string.Empty;
            }
            else
            {
                if (_isIndeterminate)
                {
                    _isIndeterminate = false;
                    progressBar1.Style = ProgressBarStyle.Continuous;
                }

                int clamped = Math.Min(Math.Max(percent, progressBar1.Minimum), progressBar1.Maximum);
                try
                {
                    progressBar1.Value = clamped;
                }
                catch
                {
                    // In rare cases Value can throw if set too quickly; clamp fallback
                    progressBar1.Value = Math.Min(clamped, progressBar1.Maximum);
                }

                lblPercent.Text = $"{clamped}%";
                lblStatus.Text = status ?? string.Empty;
                Text = $"Processing - {clamped}%";
            }

            // When complete show finished and stop timer
            if (percent >= progressBar1.Maximum)
            {
                lblStatus.Text = "Finished";
                lblPercent.Text = "100%";
                _uiTimer.Stop();
            }
        }

        public bool CancelRequested => _cts?.IsCancellationRequested ?? false;

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            btnCancel.Text = "Cancelling...";
            _cts?.Cancel();
        }

        private void UiTimer_Tick(object? sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => UiTimer_Tick(sender, e)));
                return;
            }

            var elapsed = _stopwatch.Elapsed;
            string elapsedText = string.Format("{0:D2}:{1:D2}", elapsed.Minutes, elapsed.Seconds);
            // Append elapsed time to status without overwriting it
            if (!string.IsNullOrEmpty(lblStatus.Text))
                lblStatus.Text = $"{lblStatus.Text.Split(new[] { " - " }, StringSplitOptions.None)[0]} - elapsed {elapsedText}";
            else
                lblStatus.Text = $"elapsed {elapsedText}";
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            try
            {
                _uiTimer.Stop();
                _uiTimer.Tick -= UiTimer_Tick;
                _uiTimer.Dispose();
            }
            catch { }

            try
            {
                _stopwatch.Stop();
            }
            catch { }
        }

        private void InitializeComponent()
        {
            progressBar1 = new ProgressBar();
            lblStatus = new Label();
            lblPercent = new Label();
            btnCancel = new Button();

            SuspendLayout();

            // progressBar1
            progressBar1.Location = new Point(16, 40);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(360, 22);
            progressBar1.TabIndex = 0;
            progressBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // lblStatus
            lblStatus.AutoSize = false;
            lblStatus.Location = new Point(16, 12);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(360, 18);
            lblStatus.TabIndex = 1;
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            lblStatus.Text = "Waiting for operation...";

            // lblPercent
            lblPercent.AutoSize = false;
            lblPercent.Location = new Point(16, 68);
            lblPercent.Name = "lblPercent";
            lblPercent.Size = new Size(360, 18);
            lblPercent.TabIndex = 2;
            lblPercent.TextAlign = ContentAlignment.MiddleLeft;
            lblPercent.Text = "0%";

            // btnCancel
            btnCancel.Location = new Point(300, 88);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 26);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            // frmProgress
            ClientSize = new Size(392, 126);
            Controls.Add(btnCancel);
            Controls.Add(lblPercent);
            Controls.Add(lblStatus);
            Controls.Add(progressBar1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmProgress";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}