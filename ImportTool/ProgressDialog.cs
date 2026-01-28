using System;
using System.Windows.Forms;
using System.Threading;

namespace ImportTool
{
    public partial class frmProgress : Form
    {
        private CancellationTokenSource _cts;

        public frmProgress(CancellationTokenSource cts)
        {
            InitializeComponent();
            _cts = cts;
            // Ensure controls exist in designer: progressBar, lblStatus, btnCancel
            lblStatus.Text = "";
            btnCancel.Click += (s, e) => _cts.Cancel();
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            lblStatus.Text = "";

        }

        // Safe UI update from background thread
        public void SetProgress(int percent, string status)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => SetProgress(percent, status)));
                return;
            }

            progressBar1.Value = Math.Min(Math.Max(percent, 0), 100);
            lblStatus.Text = status;
        }

        private void progressBar_Load(object sender, EventArgs e)
        {

        }

        private ProgressBar progressBar1;
        private Label lblStatus;
        private Button btnCancel;

        private void InitializeComponent()
        {
            progressBar1 = new ProgressBar();
            lblStatus = new Label();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(62, 77);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(100, 23);
            progressBar1.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(62, 39);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(125, 15);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Waiting For Progress...";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(87, 126);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmProgress
            // 
            ClientSize = new Size(257, 177);
            Controls.Add(btnCancel);
            Controls.Add(lblStatus);
            Controls.Add(progressBar1);
            Name = "frmProgress";
            Load += progressBar_Load;
            ResumeLayout(false);
            PerformLayout();

        }
    }
}