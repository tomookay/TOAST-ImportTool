namespace ImportTool
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnLoadProject_Click(object sender, EventArgs e)
        {
            // Show the Open File Dialog to select a TOAST project file
            if (OpenTOASTprojectDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                string projectPath = OpenTOASTprojectDialog.FileName;
                // Update the label to show the selected project path
                lblProjectPath.Text = projectPath;
            }

            // Prepare cancellation and progress UI
            var cts = new System.Threading.CancellationTokenSource();
            using var progressDlg = new frmProgress(cts);
            progressDlg.Show(this);


            //search for all files with the file extention and name in the selected project folder or sub folder
            //S1_01_Motion_1.TcPOU, S1_01_Motion_2.TcPOU, etc
            //S2_01_Motion_1.TcPOU, S2_01_Motion_2.TcPOU etc
            //etc
            //were S1 is the station number from 1 to 6 and put each file found in a lstbxStation1Files, lstbxStation2Files
            for (int stationNumber = 1; stationNumber <= 6; stationNumber++)
            {
                string searchPattern = $"S{stationNumber}_01_Motion_*.TcPOU";
                string projectDirectory = Path.GetDirectoryName(lblProjectPath.Text);
                if (projectDirectory != null)
                {
                    //sort by natural sort, not alphabetical which gives 1,2,3,4,5,6,7,8,9,90,91 etc
                    string[] foundFiles = NaturalSort.GetFilesNaturalSort(projectDirectory, searchPattern, SearchOption.AllDirectories);
                    ListBox targetListBox = stationNumber switch
                    {
                        1 => lstbxStation1Files,
                        2 => lstbxStation2Files,
                        3 => lstbxStation3Files,
                        4 => lstbxStation4Files,
                        5 => lstbxStation5Files,
                        6 => lstbxStation6Files,
                        _ => null
                    };
                    if (targetListBox != null)
                    {
                        targetListBox.Items.Clear();
                        foreach (string file in foundFiles)
                        {
                            targetListBox.Items.Add(file);
                        }
                    }
                }
            }

            // Now parse each file in the lstbxStation1Files, lstbxStation2Files, etc
            for (int stationNumber = 1; stationNumber <= 6; stationNumber++)
            {
                //select the file box
                ListBox targetListBox = stationNumber switch
                {
                    1 => lstbxStation1Files,
                    2 => lstbxStation2Files,
                    3 => lstbxStation3Files,
                    4 => lstbxStation4Files,
                    5 => lstbxStation5Files,
                    6 => lstbxStation6Files,
                    _ => null
                };
                //...and select the tree view
                TreeView targetTreeView = stationNumber switch
                {
                    1 => tvStation1,
                    2 => tvStation2,
                    3 => tvStation3,
                    4 => tvStation4,
                    5 => tvStation5,
                    6 => tvStation6,
                    _ => null
                };

                if (targetListBox == null || targetTreeView == null)
                    continue;

                targetTreeView.Nodes.Clear();

                foreach (var item in targetListBox.Items)
                {
                    if (item is not string filePath || string.IsNullOrWhiteSpace(filePath))
                        continue;

                    try
                    {
                        //get the data from the xml file and use custom logic to extract the required elements
                        string fileContent = File.ReadAllText(filePath);
                        // Replace encoded tags
                        string xmlContent = fileContent.Replace("&lt;", "<").Replace("&gt;", ">");
                        var xmlDoc = new System.Xml.XmlDocument();
                        xmlDoc.LoadXml(xmlContent);

                        // like all this shit going on here
                        string rowNumber = xmlDoc.SelectSingleNode("//RowNumber")?.InnerText ?? "Unknown";
                        string advanceCoilTextSym = xmlDoc.SelectSingleNode("//Advance/AdvanceCoilTextSym")?.InnerText ?? "";
                        string advanceDepthTextSym = xmlDoc.SelectSingleNode("//Advance/AdvanceDepthTextSym")?.InnerText ?? "";
                        string advanceCoilTextAbs = xmlDoc.SelectSingleNode("//Advance/AdvanceCoilTextAbs")?.InnerText ?? "";
                        string advanceDepthTextAbs = xmlDoc.SelectSingleNode("//Advance/AdvanceDepthTextAbs")?.InnerText ?? "";
                        string advanceManSeq = xmlDoc.SelectSingleNode("//Advance/ManSeq")?.InnerText ?? "";

                        string returnCoilTextSym = xmlDoc.SelectSingleNode("//Return/ReturnCoilTextSym")?.InnerText ?? "";
                        string returnDepthTextSym = xmlDoc.SelectSingleNode("//Return/ReturnDepthTextSym")?.InnerText ?? "";
                        string returnCoilTextAbs = xmlDoc.SelectSingleNode("//Return/ReturnCoilTextAbs")?.InnerText ?? "";
                        string returnDepthTextAbs = xmlDoc.SelectSingleNode("//Return/ReturnDepthTextAbs")?.InnerText ?? "";
                        string returnManSeq = xmlDoc.SelectSingleNode("//Return/ManSeq")?.InnerText ?? "";

                        string motionNameSym = xmlDoc.SelectSingleNode("//Motion/NameSym")?.InnerText ?? "";
                        string motionNameAbs = xmlDoc.SelectSingleNode("//Motion/NameAbs")?.InnerText ?? "";

                        // Build and add the TreeNode
                        // TreeNode rootNode = new TreeNode($"{rowNumber}");
                        TreeNode rootNode = new TreeNode($"Row {rowNumber}");
                        TreeNode advanceNode = new TreeNode("Advance");
                        advanceNode.Nodes.Add(new TreeNode($"{advanceCoilTextSym}"));
                        advanceNode.Nodes.Add(new TreeNode($"{advanceDepthTextSym}"));
                        advanceNode.Nodes.Add(new TreeNode($"{advanceCoilTextAbs}"));
                        advanceNode.Nodes.Add(new TreeNode($"{advanceDepthTextAbs}"));
                        advanceNode.Nodes.Add(new TreeNode($"{advanceManSeq}"));

                        TreeNode returnNode = new TreeNode("Return");
                        returnNode.Nodes.Add(new TreeNode($"{returnCoilTextSym}"));
                        returnNode.Nodes.Add(new TreeNode($"{returnDepthTextSym}"));
                        returnNode.Nodes.Add(new TreeNode($"{returnCoilTextAbs}"));
                        returnNode.Nodes.Add(new TreeNode($"{returnDepthTextAbs}"));
                        returnNode.Nodes.Add(new TreeNode($"{returnManSeq}"));

                        TreeNode motionNode = new TreeNode("Motion");
                        motionNode.Nodes.Add(new TreeNode($"{motionNameSym}"));
                        motionNode.Nodes.Add(new TreeNode($"{motionNameAbs}"));

                        rootNode.Nodes.Add(advanceNode);
                        rootNode.Nodes.Add(returnNode);
                        rootNode.Nodes.Add(motionNode);

                        targetTreeView.Nodes.Add(rootNode);


                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error parsing '{filePath}': {ex.Message}");
                        // Continue to next file on error
                    }


                }
                //populate the dgvStation1 with the extracted data from the xml files
                //the values are from clmNumber, and the text is from the other extracted elements into clmText
                DataGridView targetDataGridView = stationNumber switch
                {
                    1 => dgvStation1,
                    2 => dgvStation2,
                    3 => dgvStation3,
                    4 => dgvStation4,
                    5 => dgvStation5,
                    6 => dgvStation6,
                    _ => null
                };

                if (targetDataGridView != null)
                {
                    // Clear existing rows to avoid accumulating rows across repeated loads
                    targetDataGridView.Rows.Clear();
                    targetDataGridView.SuspendLayout();

                    int motionIndex = 0; // counts only processed "Row " nodes so baseNumber is stable per motion

                    foreach (TreeNode rootNode in targetTreeView.Nodes)
                    {
                        if (!rootNode.Text.StartsWith("Row "))
                            continue;

                        int baseNumber = stationNumber * 10000 + motionIndex * 20;
                        int rowOffset = 0;

                        // Iterate Advance / Return / Motion groups and their data nodes
                        foreach (TreeNode childNode in rootNode.Nodes)
                        {
                            foreach (TreeNode dataNode in childNode.Nodes)
                            {
                                string text = dataNode?.Text ?? string.Empty;
                                targetDataGridView.Rows.Add(baseNumber + rowOffset, text);
                                rowOffset++;
                            }

                            // Add one spare after each child-group to keep fields in predictable positions
                            int spareId = baseNumber + rowOffset;
                            targetDataGridView.Rows.Add(spareId, $"spare ({spareId})");
                            rowOffset++;
                        }

                        // Pad the block to exactly 20 entries
                        while (rowOffset < 20)
                        {
                            int spareId = baseNumber + rowOffset;
                            targetDataGridView.Rows.Add(spareId, $"spare ({spareId})");
                            rowOffset++;
                        }

                        motionIndex++;
                    }

                    targetDataGridView.ResumeLayout();

                    //reorder the dgvStation1 with the row number in neumerical order
                    targetDataGridView.Sort(targetDataGridView.Columns[0], System.ComponentModel.ListSortDirection.Ascending);

                }

                // Process stations 1 through 6
                for (int stationNumberexp = 1; stationNumberexp <= 6; stationNumberexp++)
                    ProcessStationAlarms(stationNumberexp);

                //process station 1 through 6 prompts
                for (int stationNumberexp = 1; stationNumberexp <= 6; stationNumberexp++)
                    ProcessStationPrompts(stationNumberexp);


                progressDlg.SetProgress(100, "Finished");
                progressDlg.Close();
            }
        }

        void ProcessStationAlarms(int stationNumber)
        {
            string projectDir = Path.GetDirectoryName(lblProjectPath.Text) ?? string.Empty;
            string searchPattern = $"S{stationNumber}_Alarms.TcTLO";
            string stationAlarmsFile = Directory.GetFiles(projectDir, searchPattern, SearchOption.AllDirectories).FirstOrDefault();

            // Map controls for the station
            Label lblStationAlarmsPath = stationNumber switch
            {
                1 => lblStation1AlarmsFilePath,
                2 => lblStation2AlarmsFilePath,
                3 => lblStation3AlarmsFilePath,
                4 => lblStation4AlarmsFilePath,
                5 => lblStation5AlarmsFilePath,
                6 => lblStation6AlarmsFilePath,
                _ => null
            };

            TreeView tvStationAlarms = stationNumber switch
            {
                1 => tvStationAlarms1,
                2 => tvStationAlarms2,
                3 => tvStationAlarms3,
                4 => tvStationAlarms4,
                5 => tvStationAlarms5,
                6 => tvStationAlarms6,
                _ => null
            };

            DataGridView dgvStationAlarms = stationNumber switch
            {
                1 => dgvStationAlarms1,
                2 => dgvStationAlarms2,
                3 => dgvStationAlarms3,
                4 => dgvStationAlarms4,
                5 => dgvStationAlarms5,
                6 => dgvStationAlarms6,
                _ => null
            };

            if (lblStationAlarmsPath != null)
                lblStationAlarmsPath.Text = stationAlarmsFile ?? "Alarms file not found.";

            tvStationAlarms?.Nodes.Clear();

            if (string.IsNullOrEmpty(stationAlarmsFile) || !File.Exists(stationAlarmsFile))
            {
                // No file - leave empty tree/grid
                return;
            }

            string[] alarmFileLines = File.ReadAllLines(stationAlarmsFile);
            TreeNode rootAlarmNode = new TreeNode("Alarms");

            for (int i = 0; i < alarmFileLines.Length; i++)
            {
                string line = alarmFileLines[i];
                if (!line.Contains("<v n=\"TextID\">"))
                    continue;

                int gt = line.IndexOf('>');
                int lt = (gt >= 0) ? line.IndexOf('<', gt + 1) : -1;
                if (!(gt >= 0 && lt > gt))
                    continue;

                string inner = line.Substring(gt + 1, lt - gt - 1); // e.g. "\"0\""
                string textID = inner.Trim().Trim('"');

                // Look ahead for TextDefault
                string textDefault = string.Empty;
                if (i + 1 < alarmFileLines.Length && alarmFileLines[i + 1].Contains("<v n=\"TextDefault\">"))
                {
                    string nextLine = alarmFileLines[i + 1];
                    int gtDef = nextLine.IndexOf('>');
                    int ltDef = (gtDef >= 0) ? nextLine.IndexOf('<', gtDef + 1) : -1;
                    if (gtDef >= 0 && ltDef > gtDef)
                    {
                        string innerDef = nextLine.Substring(gtDef + 1, ltDef - gtDef - 1);
                        textDefault = innerDef.Trim().Trim('"');
                    }
                }

                TreeNode alarmNode = new TreeNode($"{textID} - {textDefault}");
                rootAlarmNode.Nodes.Add(alarmNode);
            }

            if (tvStationAlarms != null)
            {
                tvStationAlarms.Nodes.Add(rootAlarmNode);
                tvStationAlarms.ExpandAll();
            }

            if (dgvStationAlarms != null)
            {
                dgvStationAlarms.Rows.Clear();
                foreach (TreeNode alarmNode in rootAlarmNode.Nodes)
                {
                    string[] parts = alarmNode.Text.Split(new string[] { " - " }, StringSplitOptions.None);
                    if (parts.Length == 2)
                    {
                        string alarmNumber = parts[0];
                        string alarmText = parts[1];
                        dgvStationAlarms.Rows.Add(alarmNumber, alarmText);
                    }
                }
            }
        }

        void ProcessStationPrompts(int stationNumber)
        {
            // Similar to ProcessStationAlarms but for prompts - can be implemented if needed   
            string projectDir = Path.GetDirectoryName(lblProjectPath.Text) ?? string.Empty;
            string searchPattern = $"S{stationNumber}_Prompts.TcTLO";
            string stationAlarmsFile = Directory.GetFiles(projectDir, searchPattern, SearchOption.AllDirectories).FirstOrDefault();

            // Map controls for the station
            Label lblStationPromptsPath = stationNumber switch
            {
                1 => lblStation1PromptsFilePath,
                2 => lblStation2PromptsFilePath,
                3 => lblStation3PromptsFilePath,
                4 => lblStation4PromptsFilePath,
                5 => lblStation5PromptsFilePath,
                6 => lblStation6PromptsFilePath,
                _ => null
            };

            TreeView tvStationPrompts = stationNumber switch
            {
                1 => tvStationPrompts1,
                2 => tvStationPrompts2,
                3 => tvStationPrompts3,
                4 => tvStationPrompts4,
                5 => tvStationPrompts5,
                6 => tvStationPrompts6,
                _ => null
            };

            DataGridView dgvStationAlarms = stationNumber switch
            {
                1 => dgvStationAlarms1,
                2 => dgvStationAlarms2,
                3 => dgvStationAlarms3,
                4 => dgvStationAlarms4,
                5 => dgvStationAlarms5,
                6 => dgvStationAlarms6,
                _ => null
            };

            if (lblStationPromptsPath != null)
                lblStationPromptsPath.Text = stationAlarmsFile ?? "Prompts file not found.";
                tvStationPrompts?.Nodes.Clear();
                if (string.IsNullOrEmpty(stationAlarmsFile) || !File.Exists(stationAlarmsFile))
                {
                    // No file - leave empty tree/grid
                    return;
            }
            // Similar parsing logic to ProcessStationAlarms can be implemented here to populate the prompts tree/grid
            string[] alarmFileLines = File.ReadAllLines(stationAlarmsFile);
            TreeNode rootAlarmNode = new TreeNode("Prompts");

            for (int i = 0; i < alarmFileLines.Length; i++)
            {
                string line = alarmFileLines[i];
                if (!line.Contains("<v n=\"TextID\">"))
                    continue;

                int gt = line.IndexOf('>');
                int lt = (gt >= 0) ? line.IndexOf('<', gt + 1) : -1;
                if (!(gt >= 0 && lt > gt))
                    continue;

                string inner = line.Substring(gt + 1, lt - gt - 1); // e.g. "\"0\""
                string textID = inner.Trim().Trim('"');

                // Look ahead for TextDefault
                string textDefault = string.Empty;
                if (i + 1 < alarmFileLines.Length && alarmFileLines[i + 1].Contains("<v n=\"TextDefault\">"))
                {
                    string nextLine = alarmFileLines[i + 1];
                    int gtDef = nextLine.IndexOf('>');
                    int ltDef = (gtDef >= 0) ? nextLine.IndexOf('<', gtDef + 1) : -1;
                    if (gtDef >= 0 && ltDef > gtDef)
                    {
                        string innerDef = nextLine.Substring(gtDef + 1, ltDef - gtDef - 1);
                        textDefault = innerDef.Trim().Trim('"');
                    }
                }

                TreeNode alarmNode = new TreeNode($"{textID} - {textDefault}");
                rootAlarmNode.Nodes.Add(alarmNode);
            }

            if (tvStationPrompts != null)
            {
                tvStationPrompts.Nodes.Add(rootAlarmNode);
                tvStationPrompts.ExpandAll();
            }

            if (dgvStationAlarms != null)
            {
                dgvStationAlarms.Rows.Clear();
                foreach (TreeNode alarmNode in rootAlarmNode.Nodes)
                {
                    string[] parts = alarmNode.Text.Split(new string[] { " - " }, StringSplitOptions.None);
                    if (parts.Length == 2)
                    {
                        string alarmNumber = parts[0];
                        string alarmText = parts[1];
                        dgvStationAlarms.Rows.Add(alarmNumber, alarmText);
                    }
                }
            }


        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            /*
            Pseudocode / Plan (detailed):
            - Validate project directory exists and find MotionRowText.TcTLO file.
            - Build a dictionary textMap mapping TextID -> TextDefault by scanning all station DataGridViews (1..6).
              For each station:
                - Get corresponding DataGridView (dgv).
                - For each row in dgv (skip new-row template):
                  - Determine column names for this station:
                    - clmNumberColumn = "clmNumber" + stationNumber
                    - clmTextColumn   = "clmText"   + stationNumber
                  - If dgv.Columns contains clmNumberColumn, read id from that column.
                    Otherwise fall back to first column index 0.
                  - If dgv.Columns contains clmTextColumn, read text from that column.
                    Otherwise fall back to second column index 1 (if available).
                  - Trim and validate id; if valid store/overwrite textMap[id] = textDefault.
            - If no entries in textMap show a warning and abort.
            - Read MotionRowText.TcTLO into fileLines and create newLines.
            - For each line in fileLines:
              - If line contains "<v n=\"TextID\">" extract the id value.
              - If textMap contains that id:
                - Remove any previously injected TextDefault line at end of newLines.
                - Add the TextID line.
                - Determine indentation from the TextID line and inject a new TextDefault line with the mapped text.
                - Skip any immediate following original TextDefault lines in fileLines.
              - Otherwise append the line unchanged.
            - Write newLines back to the file and show success message.
            - Catch exceptions and show error message.
            */

            try


            {

                // Prepare cancellation and progress UI
                var cts = new System.Threading.CancellationTokenSource();
                using var progressDlg = new frmProgress(cts);
                progressDlg.Show(this);


                string projectDirectory = Path.GetDirectoryName(lblProjectPath.Text);
                if (string.IsNullOrEmpty(projectDirectory) || !Directory.Exists(projectDirectory))
                {
                    MessageBox.Show("Please load a valid TOAST project first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string[] motionRowTextFiles = Directory.GetFiles(projectDirectory, "MotionRowText.TcTLO", SearchOption.AllDirectories);
                if (motionRowTextFiles.Length == 0)
                {
                    MessageBox.Show("MotionRowText.TcTLO file not found in the project.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string motionRowTextFilePath = motionRowTextFiles[0];

                // Build lookup of TextID -> TextDefault from all station DataGridViews (1..6)
                var textMap = new Dictionary<string, string>();
                for (int stationNumber = 1; stationNumber <= 6; stationNumber++)
                {
                    DataGridView dgv = stationNumber switch
                    {
                        1 => dgvStation1,
                        2 => dgvStation2,
                        3 => dgvStation3,
                        4 => dgvStation4,
                        5 => dgvStation5,
                        6 => dgvStation6,
                        _ => null
                    };
                    if (dgv == null) continue;

                    string clmNumberName = $"clmNumber{stationNumber}";
                    string clmTextName = $"clmText{stationNumber}";

                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row == null || row.IsNewRow) continue;

                        // Try to access by station-specific column name first, fall back to index if necessary
                        object idObj = null;
                        object textObj = null;

                        if (dgv.Columns.Contains(clmNumberName))
                        {
                            idObj = row.Cells[clmNumberName].Value;
                        }
                        else if (row.Cells.Count > 0)
                        {
                            idObj = row.Cells[0].Value;
                        }

                        if (dgv.Columns.Contains(clmTextName))
                        {
                            textObj = row.Cells[clmTextName].Value;
                        }
                        else if (row.Cells.Count > 1)
                        {
                            textObj = row.Cells[1].Value;
                        }

                        string id = idObj?.ToString()?.Trim();
                        if (string.IsNullOrEmpty(id)) continue;

                        string textDefault = textObj?.ToString() ?? string.Empty;

                        // store/overwrite mapping
                        textMap[id] = textDefault;
                    }
                }

                if (textMap.Count == 0)
                {
                    MessageBox.Show("No TextID/Text entries found in the station tables to export.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<string> fileLines = File.ReadAllLines(motionRowTextFilePath).ToList();
                List<string> newLines = new List<string>();

                //// Prepare cancellation and progress UI
                //var cts = new System.Threading.CancellationTokenSource();
                //using var progressDlg = new frmProgress(cts);
                //progressDlg.Show(this);

                var token = cts.Token;

                Task.Run(() =>
                {
                    try
                    {
                        for (int i = 0; i < fileLines.Count; i++)
                        {
                            if (token.IsCancellationRequested)
                                token.ThrowIfCancellationRequested();

                            string line = fileLines[i];
                            bool matched = false;

                            if (line.Contains("<v n=\"TextID\">"))
                            {
                                int gt = line.IndexOf('>');
                                int lt = (gt >= 0) ? line.IndexOf('<', gt + 1) : -1;
                                if (gt >= 0 && lt > gt)
                                {
                                    string inner = line.Substring(gt + 1, lt - gt - 1); // e.g. "\"10000\""
                                    string id = inner.Trim().Trim('"');
                                    if (!string.IsNullOrEmpty(id) && textMap.TryGetValue(id, out string textDefault))
                                    {
                                        // If the last line we added was a TextDefault, remove it (preserve earlier behavior)
                                        if (newLines.Count > 0 && newLines.Last().Contains("<v n=\"TextDefault\">"))
                                        {
                                            newLines.RemoveAt(newLines.Count - 1);
                                        }

                                        // Append the TextID line
                                        newLines.Add(line);

                                        // Determine indentation from the current line (leading whitespace)
                                        int indentLen = 0;
                                        while (indentLen < line.Length && char.IsWhiteSpace(line[indentLen])) indentLen++;
                                        string indent = line.Substring(0, indentLen);

                                        // Append the new TextDefault line with same indentation
                                        newLines.Add(indent + $"<v n=\"TextDefault\">\"{textDefault}\"</v>");

                                        // Skip any immediate following original TextDefault lines
                                        while (i + 1 < fileLines.Count && fileLines[i + 1].Contains("<v n=\"TextDefault\">"))
                                        {
                                            i++;
                                        }

                                        matched = true;
                                    }
                                }
                            }

                            if (!matched)
                            {
                                newLines.Add(line);
                            }

                            // Update progress periodically (every 20 lines or on last)
                            if ((i % 20) == 0 || i == fileLines.Count - 1)
                            {
                                int percent = fileLines.Count == 0 ? 100 : (int)(((i + 1) * 100L) / fileLines.Count);
                                progressDlg.SetProgress(percent, $"Processing line {i + 1} of {fileLines.Count} ({percent}%)");
                            }
                        }

                        // If canceled after loop exit, respect it
                        if (token.IsCancellationRequested)
                            token.ThrowIfCancellationRequested();

                        File.WriteAllLines(motionRowTextFilePath, newLines);

                        // Close progress and notify success on UI thread
                        progressDlg.BeginInvoke(new Action(() =>
                        {
                            progressDlg.SetProgress(100, "Finished");
                            progressDlg.Close();
                            MessageBox.Show(this, "Data exported successfully to MotionRowText.TcTLO.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }));
                    }
                    catch (OperationCanceledException)
                    {
                        progressDlg.BeginInvoke(new Action(() =>
                        {
                            progressDlg.Close();
                            MessageBox.Show(this, "Export canceled by user.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }));
                    }
                    catch (Exception ex)
                    {
                        progressDlg.BeginInvoke(new Action(() =>
                        {
                            progressDlg.Close();
                            MessageBox.Show(this, $"Error exporting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }
                }, token);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // Extracted reusable function to generate alarms for any station (1..6).
        private void ApplyAlarmsForStation(int stationNumber)
        {
            DataGridView dgvSource = stationNumber switch
            {
                1 => dgvStation1,
                2 => dgvStation2,
                3 => dgvStation3,
                4 => dgvStation4,
                5 => dgvStation5,
                6 => dgvStation6,
                _ => null
            };

            DataGridView dgvAlarms = stationNumber switch
            {
                1 => dgvStationAlarms1,
                2 => dgvStationAlarms2,
                3 => dgvStationAlarms3,
                4 => dgvStationAlarms4,
                5 => dgvStationAlarms5,
                6 => dgvStationAlarms6,
                _ => null
            };

            if (dgvSource == null || dgvAlarms == null)
            {
                MessageBox.Show($"Invalid station number {stationNumber}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvAlarms.Rows.Clear();

            // Prevent UI re-layout while we bulk-add rows and disable automatic column sorting
            dgvAlarms.SuspendLayout();
            foreach (DataGridViewColumn col in dgvAlarms.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

            // Build id -> text map from dgvSource
            var map = new Dictionary<int, string>();
            string clmNumberName = $"clmNumber{stationNumber}";
            string clmTextName = $"clmText{stationNumber}";
            bool hasNamedCols = dgvSource.Columns.Contains(clmNumberName) && dgvSource.Columns.Contains(clmTextName);

            foreach (DataGridViewRow row in dgvSource.Rows)
            {
                if (row == null || row.IsNewRow) continue;

                object idObj = null;
                object textObj = null;

                if (hasNamedCols)
                {
                    idObj = row.Cells[clmNumberName].Value;
                    textObj = row.Cells[clmTextName].Value;
                }
                else
                {
                    if (row.Cells.Count > 0) idObj = row.Cells[0].Value;
                    if (row.Cells.Count > 1) textObj = row.Cells[1].Value;
                }

                if (idObj == null) continue;
                if (!int.TryParse(idObj.ToString(), out int id)) continue;

                string text = textObj?.ToString() ?? string.Empty;
                map[id] = text;
            }

            // Helper to get text for an id (falls back to "<id>" if missing)
            string GetText(int id)
            {
                return map.TryGetValue(id, out var t) && !string.IsNullOrEmpty(t) ? t : $"<{id}>";
            }

            // Track which motion bases we've already processed so we only create alarms once per motion block
            var processedBases = new HashSet<int>();

            // For each motion row generate 10 alarms based on id arithmetic and lookup
            foreach (DataGridViewRow motionRow in dgvSource.Rows)
            {
                if (motionRow == null || motionRow.IsNewRow) continue;

                object numberObj = null;
                if (hasNamedCols)
                    numberObj = motionRow.Cells[clmNumberName].Value;
                else if (motionRow.Cells.Count > 0)
                    numberObj = motionRow.Cells[0].Value;

                if (numberObj == null) continue;
                if (!int.TryParse(numberObj.ToString(), out int rowNumber)) continue;

                // Compute block base (start of the 20-entry motion block)
                int baseNumber = rowNumber - (rowNumber % 20);
                if (processedBases.Contains(baseNumber))
                    continue; // already created alarms for this motion

                processedBases.Add(baseNumber);

                for (int i = 0; i < 10; i++)
                {
                    string alarmText;
                    switch (i)
                    {
                        case 0:
                            alarmText = $"{GetText(baseNumber + 12)} {GetText(baseNumber + 13)} Failed to {GetText(baseNumber + 0)}... Check {GetText(baseNumber + 2)}...";
                            break;
                        case 1:
                            alarmText = $"{GetText(baseNumber + 12)} {GetText(baseNumber + 13)} Failed to {GetText(baseNumber + 6)}... Check {GetText(baseNumber + 8)}...";
                            break;
                        case 2:
                            alarmText = $"{GetText(baseNumber + 12)} {GetText(baseNumber + 13)} Lost {GetText(baseNumber + 1)}... Check {GetText(baseNumber + 3)}...";
                            break;
                        case 3:
                            alarmText = $"{GetText(baseNumber + 12)} {GetText(baseNumber + 13)} Lost {GetText(baseNumber + 7)}... Check {GetText(baseNumber + 9)}...";
                            break;
                        case 4:
                            alarmText = $"{GetText(baseNumber + 12)} {GetText(baseNumber + 13)} Switch Fault... Check {GetText(baseNumber + 3)}, {GetText(baseNumber + 9)}...";
                            break;
                        default:
                            alarmText = "Spare";
                            break;
                    }

                    int actualId = baseNumber + i;

                    // Use the actual numeric alarm id as the displayed id so rows remain synchronized with the source IDs.
                    int newRowIndex = dgvAlarms.Rows.Add(actualId, alarmText);
                    dgvAlarms.Rows[newRowIndex].Tag = actualId;
                }
            }

            dgvAlarms.ResumeLayout();

            // In dgvStationNAlarms, rename the numbers in the sNAlarmNumber column to go from 0 to N
            string alarmNumberColumnName = $"s{stationNumber}AlarmNumber";
            for (int i = 0; i < dgvAlarms.Rows.Count; i++)
            {
                DataGridViewRow row = dgvAlarms.Rows[i];
                if (row == null || row.IsNewRow) continue;

                if (dgvAlarms.Columns.Contains(alarmNumberColumnName))
                {
                    row.Cells[alarmNumberColumnName].Value = i;
                }
                else if (row.Cells.Count > 0)
                {
                    row.Cells[0].Value = i;
                }
            }
        }

        private void btnApplyAlarmsS1_Click(object sender, EventArgs e)
        {
            ApplyAlarmsForStation(1);
        }

        private void btnExporttoAlarmS1_Click(object sender, EventArgs e)
        {
            ExportAlarmsToFile(1, lblStation1AlarmsFilePath.Text);
        }

        private void ExportAlarmsToFile(int stationNumber, string filepath)
        {
            DataGridView dgvStationAlarms = stationNumber switch
            {
                1 => dgvStationAlarms1,
                2 => dgvStationAlarms2,
                3 => dgvStationAlarms3,
                4 => dgvStationAlarms4,
                5 => dgvStationAlarms5,
                6 => dgvStationAlarms6,
                _ => null
            };

            if (filepath == null || dgvStationAlarms == null)
            {
                MessageBox.Show($"Invalid station number {stationNumber}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string alarmsFilePath = filepath;
            if (string.IsNullOrWhiteSpace(alarmsFilePath) || !File.Exists(alarmsFilePath))
            {
                MessageBox.Show("Alarms file path is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> fileLines = File.ReadAllLines(alarmsFilePath).ToList();
            List<string> newLines = new List<string>();

            string alarmNumberColumnName = $"s{stationNumber}AlarmNumber";
            string alarmTextColumnName = $"s{stationNumber}AlarmText";

            for (int i = 0; i < fileLines.Count; i++)
            {
                string line = fileLines[i];
                bool matched = false;

                if (line.Contains("<v n=\"TextID\">"))
                {
                    int gt = line.IndexOf('>');
                    int lt = (gt >= 0) ? line.IndexOf('<', gt + 1) : -1;
                    if (gt >= 0 && lt > gt)
                    {
                        string inner = line.Substring(gt + 1, lt - gt - 1); // e.g. "\"0\""
                        string idStr = inner.Trim().Trim('"');
                        if (int.TryParse(idStr, out int id))
                        {
                            // Find corresponding row in the station's alarms grid
                            foreach (DataGridViewRow alarmRow in dgvStationAlarms.Rows)
                            {
                                if (alarmRow == null || alarmRow.IsNewRow) continue;

                                // Prefer matching against the displayed sNAlarmNumber cell value (renumbered 0..N).
                                int displayedNumber = int.MinValue;
                                object displayedObj = null;

                                if (dgvStationAlarms.Columns.Contains(alarmNumberColumnName))
                                    displayedObj = alarmRow.Cells[alarmNumberColumnName].Value;
                                else if (alarmRow.Cells.Count > 0)
                                    displayedObj = alarmRow.Cells[0].Value;

                                if (displayedObj != null && int.TryParse(displayedObj.ToString(), out int parsedDisplayed))
                                    displayedNumber = parsedDisplayed;

                                bool isMatch = (displayedNumber != int.MinValue && displayedNumber == id);

                                // Fallback: check Tag if previously stored there
                                if (!isMatch && alarmRow.Tag is int tagId && tagId == id)
                                    isMatch = true;

                                if (isMatch)
                                {
                                    string alarmText = null;
                                    if (dgvStationAlarms.Columns.Contains(alarmTextColumnName))
                                        alarmText = alarmRow.Cells[alarmTextColumnName].Value?.ToString();
                                    else if (alarmRow.Cells.Count > 1)
                                        alarmText = alarmRow.Cells[1].Value?.ToString();

                                    alarmText = alarmText ?? string.Empty;

                                    // Append the TextID line
                                    newLines.Add(line);

                                    // Determine indentation from the current line (leading whitespace)
                                    int indentLen = 0;
                                    while (indentLen < line.Length && char.IsWhiteSpace(line[indentLen])) indentLen++;
                                    string indent = line.Substring(0, indentLen);

                                    // Append the new TextDefault line with same indentation
                                    newLines.Add(indent + $"<v n=\"TextDefault\">\"{alarmText}\"</v>");

                                    // Skip any immediate following original TextDefault lines
                                    while (i + 1 < fileLines.Count && fileLines[i + 1].Contains("<v n=\"TextDefault\">"))
                                        i++;

                                    matched = true;
                                    break;
                                }
                            }
                        }
                    }
                }

                if (!matched)
                    newLines.Add(line);
            }

            File.WriteAllLines(alarmsFilePath, newLines);
            MessageBox.Show($"Alarms exported successfully to {Path.GetFileName(alarmsFilePath)}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnApplyAlarmsS2_Click(object sender, EventArgs e)
        {
            ApplyAlarmsForStation(2);
        }

        private void btnExporttoAlarmS2_Click(object sender, EventArgs e)
        {
            ExportAlarmsToFile(2, lblStation2AlarmsFilePath.Text);
        }

        private void btnExporttoAlarmS3_Click(object sender, EventArgs e)
        {
            ExportAlarmsToFile(3, lblStation3AlarmsFilePath.Text);
        }

        private void btnExporttoAlarmS4_Click(object sender, EventArgs e)
        {
            ExportAlarmsToFile(4, lblStation4AlarmsFilePath.Text);
        }

        private void btnExporttoAlarmS5_Click(object sender, EventArgs e)
        {
            ExportAlarmsToFile(5, lblStation5AlarmsFilePath.Text);
        }

        private void btnExporttoAlarmS6_Click(object sender, EventArgs e)
        {
            ExportAlarmsToFile(6, lblStation6AlarmsFilePath.Text);
        }

        private void btnApplyAlarmsS3_Click(object sender, EventArgs e)
        {
            ApplyAlarmsForStation(3);
        }

        private void btnApplyAlarmsS4_Click(object sender, EventArgs e)
        {
            ApplyAlarmsForStation(4);
        }

        private void btnApplyAlarmsS5_Click(object sender, EventArgs e)
        {
            ApplyAlarmsForStation(5);
        }

        private void btnApplyAlarmsS6_Click(object sender, EventArgs e)
        {
            ApplyAlarmsForStation(6);
        }
    }

}