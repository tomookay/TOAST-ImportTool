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


            // for each lstbxStation1Files.Items as a file path, read the file in as xml and
            // 
            //&lt; StationNumber & gt; 1 & lt;/ StationNumber & gt;
            //&lt; RowNumber & gt; 1 & lt;/ RowNumber & gt;
            //&lt; Advance & gt;
            //&lt; AdvanceCoilTextSym & gt; Advance & lt;/ AdvanceCoilTextSym & gt;
            //&lt; AdvanceDepthTextSym & gt; Advanced & lt;/ AdvanceDepthTextSym & gt;
            //&lt; AdvanceCoilTextAbs & gt; Q1.0 & lt;/ AdvanceCoilTextAbs & gt;
            //&lt; AdvanceDepthTextAbs & gt; I1.0 & lt;/ AdvanceDepthTextAbs & gt;
            //&lt; ManSeq & gt; 1 & lt;/ ManSeq & gt;
            //&lt;/ Advance & gt;
            //&lt; Return & gt;
            //&lt; ReturnCoilTextSym & gt; Return & lt;/ ReturnCoilTextSym & gt;
            //&lt; ReturnDepthTextSym & gt; Returned & lt;/ ReturnDepthTextSym & gt;
            //&lt; ReturnCoilTextAbs & gt; Q1.1 & lt;/ ReturnCoilTextAbs & gt;
            //&lt; ReturnDepthTextAbs & gt; I1.1 & lt;/ ReturnDepthTextAbs & gt;
            //&lt; ManSeq & gt; 2 & lt;/ ManSeq & gt;
            //&lt;/ Return & gt;
            //&lt; Motion & gt;
            //&lt; NameSym & gt; Clamp Cylinder&lt;/ NameSym & gt;
            //&lt; NameAbs & gt; A1 & lt;/ NameAbs & gt;
            //&lt;/ Motion & gt;
            //&lt;/ MotionRow & gt;

            //replace the &lt; and &gt; with < and > respectively to make it valid xml and parse it

            //obtain the following elemements and the data
            //StationNumber, could be 1-6
            //RowNumber, could be 1-99
            //Advance structure
            //AdvanceCoilTextSym, free text
            //AdvanceDepthTextSym, free text
            //AdvanceCoilTextAbs, free text
            //AdvanceDepthTextAbs, free text
            //ManSeq, an integer 
            //Return structure
            //ReturnCoilTextSym, free text
            //ReturnDepthTextSym, free text
            //ReturnCoilTextAbs, free text
            //ReturnDepthTextAbs, free text
            //ManSeq, an integer
            //Motion structure
            //NameSym, free text
            //NameAbs, free text

            foreach (string filePath in lstbxStation1Files.Items)
            {
                string fileContent = File.ReadAllText(filePath);
                // Replace &lt; and &gt; with < and >
                string xmlContent = fileContent.Replace("&lt;", "<").Replace("&gt;", ">");
                // Load the XML content
                System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.LoadXml(xmlContent);
                // Extract the required elements
                string stationNumber = xmlDoc.SelectSingleNode("//StationNumber")?.InnerText;
                string rowNumber = xmlDoc.SelectSingleNode("//RowNumber")?.InnerText;
                string advanceCoilTextSym = xmlDoc.SelectSingleNode("//Advance/AdvanceCoilTextSym")?.InnerText;
                string advanceDepthTextSym = xmlDoc.SelectSingleNode("//Advance/AdvanceDepthTextSym")?.InnerText;
                string advanceCoilTextAbs = xmlDoc.SelectSingleNode("//Advance/AdvanceCoilTextAbs")?.InnerText;
                string advanceDepthTextAbs = xmlDoc.SelectSingleNode("//Advance/AdvanceDepthTextAbs")?.InnerText;
                string advanceManSeq = xmlDoc.SelectSingleNode("//Advance/ManSeq")?.InnerText;
                string returnCoilTextSym = xmlDoc.SelectSingleNode("//Return/ReturnCoilTextSym")?.InnerText;
                string returnDepthTextSym = xmlDoc.SelectSingleNode("//Return/ReturnDepthTextSym")?.InnerText;
                string returnCoilTextAbs = xmlDoc.SelectSingleNode("//Return/ReturnCoilTextAbs")?.InnerText;
                string returnDepthTextAbs = xmlDoc.SelectSingleNode("//Return/ReturnDepthTextAbs")?.InnerText;
                string returnManSeq = xmlDoc.SelectSingleNode("//Return/ManSeq")?.InnerText;
                string motionNameSym = xmlDoc.SelectSingleNode("//Motion/NameSym")?.InnerText;
                string motionNameAbs = xmlDoc.SelectSingleNode("//Motion/NameAbs")?.InnerText;

                //populate a tvStation1Motions with the xmlDoc
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
                tvStation1Motions.Nodes.Add(rootNode);





            }










        }
        }
}
