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
                        advanceNode.Nodes.Add(new TreeNode($"AdvanceCoilTextSym: {advanceCoilTextSym}"));
                        advanceNode.Nodes.Add(new TreeNode($"AdvanceDepthTextSym: {advanceDepthTextSym}"));
                        advanceNode.Nodes.Add(new TreeNode($"AdvanceCoilTextAbs: {advanceCoilTextAbs}"));
                        advanceNode.Nodes.Add(new TreeNode($"AdvanceDepthTextAbs: {advanceDepthTextAbs}"));
                        advanceNode.Nodes.Add(new TreeNode($"ManSeq: {advanceManSeq}"));

                        TreeNode returnNode = new TreeNode("Return");
                        returnNode.Nodes.Add(new TreeNode($"ReturnCoilTextSym: {returnCoilTextSym}"));
                        returnNode.Nodes.Add(new TreeNode($"ReturnDepthTextSym: {returnDepthTextSym}"));
                        returnNode.Nodes.Add(new TreeNode($"ReturnCoilTextAbs: {returnCoilTextAbs}"));
                        returnNode.Nodes.Add(new TreeNode($"ReturnDepthTextAbs: {returnDepthTextAbs}"));
                        returnNode.Nodes.Add(new TreeNode($"ManSeq: {returnManSeq}"));

                        TreeNode motionNode = new TreeNode("Motion");
                        motionNode.Nodes.Add(new TreeNode($"NameSym: {motionNameSym}"));
                        motionNode.Nodes.Add(new TreeNode($"NameAbs: {motionNameAbs}"));

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
                    //   2 => dgvStation2,
                    //    3 => dgvStation3,
                    //    4 => dgvStation4,
                    //   5 => dgvStation5,
                    //   6 => dgvStation6,
                    _ => null
                };
                //for each element of xmlin tvStation1 create a new number from 1-10000 starting at rootNode and put into dgvStation1
                if (targetDataGridView != null)
                {
                    int rowIndex = targetDataGridView.Rows.Add();
                    DataGridViewRow newRow = targetDataGridView.Rows[rowIndex];
                    newRow.Cells["clmNumber"].Value = rowIndex + 1;
                    //add the data from the treeview to the datagridview in clmText from advanceNode, returnNode, motionNode
                   

                }
            }
        }





    }
}
