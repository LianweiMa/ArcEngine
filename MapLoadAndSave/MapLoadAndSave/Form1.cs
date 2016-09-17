using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
namespace MapLoadAndSave
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string strFilename;
        IMapDocument pMapDocument = new MapDocument();
        private void MapLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog pOpenFileDialog=new OpenFileDialog();
            pOpenFileDialog.InitialDirectory = @"D:\D_DataProcessingProject\ArcGIS\A_Test";
            pOpenFileDialog.Filter = "Mxd file|*.mxd|All file|*.*";
            pOpenFileDialog.RestoreDirectory = true;
            pOpenFileDialog.FilterIndex = 1;
            if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                strFilename=pOpenFileDialog.FileName;
               this.Text = System.IO.Path.GetFileName(strFilename);
               pMapDocument.Open(strFilename);
               int iMapCount = pMapDocument.MapCount;
               axMapControl1.Map = pMapDocument.get_Map(0);
                //axMapControl1.AddShapeFile(System.IO.Path.GetDirectoryName(strFilename), System.IO.Path.GetFileNameWithoutExtension(strFilename));
            }
  
        }

        private void MapSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog pSaveFileDialog = new SaveFileDialog();
            pSaveFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(strFilename);
            pSaveFileDialog.Filter = "Mxd file|*.mxd|All file|*.*";
            pSaveFileDialog.FilterIndex = 1;
            if (pSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                strFilename=pSaveFileDialog.FileName;
                pMapDocument.SaveAs(strFilename);
            }
        }
    }
}
