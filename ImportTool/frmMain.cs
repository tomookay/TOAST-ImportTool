using System;
using System.Security.Claims;
using System.Text;

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
                    string[] foundFiles = Directory.GetFiles(projectDirectory, searchPattern, SearchOption.AllDirectories);
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
            for (int stationNumber = 1; stationNumber <= 6; stationNumber++)
            {
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
                        string fileContent = File.ReadAllText(filePath);
                        // Replace encoded tags
                        string xmlContent = fileContent.Replace("&lt;", "<").Replace("&gt;", ">");
                        var xmlDoc = new System.Xml.XmlDocument();
                        xmlDoc.LoadXml(xmlContent);

                        // Extract elements (use safe null-coalescing to avoid null refs)
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
                //insert the data rootNode into the dgvStation1 with each value in a new row
                //start the number at station number (1-6) * 10000
                //the numbers are allways populated from 10000 to 19999 for station 1, and for other stations accordingly
                //the following pattern is used
                //10000 - advanceCoilTextSym
                //10001 - advanceDepthTextSym
                //10002 - spare
                //10003 - returnCoilTextSym
                //10004 - returnDepthTextSym
                //10005 - spare
                //10006 - motionNameSym
                //10007 - spare
                //10008 - spare
                //10009 - spare
                //10010 - advanceCoilTextRel
                //10011 - advanceDepthTextRel
                //10012 - spare
                //10013 - returnCoilTextRel
                //10014 - returnDepthTextRel
                //10015 - spare
                //10016 - motionNameRel
                //10017 - spare
                //10018 - spare
                //10019 - spare
                //10020 - spare
                //start of next row at 10021

                //create 20 strings based on the above pattern for each rootnode xml node parsed
                if (targetDataGridView != null)
                {
                    int baseNumber = stationNumber * 10000;
                    foreach (TreeNode rootNode in targetTreeView.Nodes)
                    {
                        if (rootNode.Text.StartsWith("Row "))
                        {
                            int rowOffset = 0;
                            foreach (TreeNode childNode in rootNode.Nodes)
                            {
                                foreach (TreeNode dataNode in childNode.Nodes)
                                {
                                    if (dataNode.Text != null)
                                    {
                                        targetDataGridView.Rows.Add(baseNumber + rowOffset, dataNode.Text);
                                    }
                                    rowOffset++;
                                }
                                // Add spares as needed
                                if (childNode.Text == "Advance" || childNode.Text == "Return" || childNode.Text == "Motion")
                                {
                                    int spareId = baseNumber + rowOffset;
                                    // include the numeric id on the same line as "spare"
                                    targetDataGridView.Rows.Add(spareId, $"spare ({spareId})");
                                    rowOffset++;
                                }
                            }
                            // Add additional spares to reach 20 entries per row
                            while (rowOffset < 19)
                            {
                                int spareId = baseNumber + rowOffset;
                                targetDataGridView.Rows.Add(spareId, $"spare ({spareId})");
                                rowOffset++;
                            }
                            baseNumber += 20; // Move to the next block for the next row
                        }
                    }

                }
            }
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            //search for the MotionRowText.TcTLO file in the selected project folder or sub folder
            string projectDirectory = Path.GetDirectoryName(lblProjectPath.Text);
            if (string.IsNullOrEmpty(projectDirectory) || !Directory.Exists(projectDirectory))
            {
                //messagebox to show file found
                MessageBox.Show("Please load a valid TOAST project first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] motionRowTextFiles = Directory.GetFiles(projectDirectory, "MotionRowText.TcTLO", SearchOption.AllDirectories);
            if (motionRowTextFiles.Length == 0)
            {
                //messagebox to show file not found
                MessageBox.Show("MotionRowText.TcTLO file not found in the project.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string motionRowTextFilePath = motionRowTextFiles[0];

            if (dgvStation1.Rows.Count == 0)
            {
                //messagebox to show dgvStation1 is empty
                MessageBox.Show("No data to export in Station 1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                List<string> fileLines = File.ReadAllLines(motionRowTextFilePath).ToList();
                List<string> newLines = new List<string>();

                for (int i = 0; i < fileLines.Count; i++)
                {
                    string line = fileLines[i];
                    bool matched = false;

                    // Try to match this line against any TextID from dgvStation1
                    for (int r = 0; r < dgvStation1.Rows.Count; r++)
                    {
                        var row = dgvStation1.Rows[r];
                        if (row.Cells["clmNumber"].Value == null) continue;
                        string textID = row.Cells["clmNumber"].Value.ToString();

                        if (line.Contains($"<v n=\"TextID\">\"{textID}\"</v>"))
                        {
                            // Remove any TextDefault that was directly above (already added to newLines)
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

                            // Prepare TextDefault value (use empty string if null)
                            string textDefault = row.Cells["clmText"].Value?.ToString() ?? "";

                            // Insert the new TextDefault line (with same indentation)
                            newLines.Add(indent + $"<v n=\"TextDefault\">\"{textDefault}\"</v>");

                            // Skip any immediate following original TextDefault lines (remove "below" duplicates)
                            while (i + 1 < fileLines.Count && fileLines[i + 1].Contains("<v n=\"TextDefault\">"))
                            {
                                i++;
                            }

                            matched = true;
                            break; // matched this TextID, move to next file line
                        }
                    }

                    if (!matched)
                    {
                        newLines.Add(line);
                    }
                }

                File.WriteAllLines(motionRowTextFilePath, newLines);
                MessageBox.Show("Data exported successfully to MotionRowText.TcTLO.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}








