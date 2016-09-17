using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
namespace LayerOperation
{
    public partial class LayerOP : Form
    {
        public LayerOP()
        {
            InitializeComponent();
        }

        private void AddLayer_Click(object sender, EventArgs e)
        {
            OpenFileDialog pOpenFileDialog = new OpenFileDialog();
            pOpenFileDialog.InitialDirectory = @"D:\D_DataProcessingProject\ArcGIS\A_Test";
            pOpenFileDialog.Filter = "Layer file|*.lyr|All file|*.*";
            pOpenFileDialog.RestoreDirectory = true;
            pOpenFileDialog.FilterIndex = 1;
            if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string strFileName = pOpenFileDialog.FileName;
               // IWorkspaceFactory pWorkspaceFactory=new WorkspaceFactory();
                //IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(System.IO.Path.GetDirectoryName(strFileName),0);
                
                /*IFeatureWorkspace pFeatureWorkspace = pWorkspace as IFeatureWorkspace;
                IFeatureClass pFeatureClass = pFeatureWorkspace.OpenFeatureClass(System.IO.Path.GetFileName(strFileName));
                pFeatureClass.*/
                axMapControl1.AddLayerFromFile(strFileName);
            }
        }

        private void AddShape_Click(object sender, EventArgs e)
        {
            OpenFileDialog pOpenFileDialog = new OpenFileDialog();
            pOpenFileDialog.InitialDirectory = @"D:\D_DataProcessingProject\ArcGIS\A_Test";
            pOpenFileDialog.Filter = "Shape file|*.shp|All file|*.*";
            pOpenFileDialog.RestoreDirectory = true;
            pOpenFileDialog.FilterIndex = 1;
            if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string strFileName = pOpenFileDialog.FileName;
                axMapControl1.AddShapeFile(System.IO.Path.GetDirectoryName(strFileName),System.IO.Path.GetFileNameWithoutExtension(strFileName));
            }
        }

        private void DeleteLayer_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < axMapControl1.LayerCount;i++ )
                axMapControl1.DeleteLayer(i);
        }

        private void axMapControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            axMapControl1.Pan();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            axMapControl1.Extent = axMapControl1.FullExtent;
            axMapControl1.get_Layer(1).Visible=true;
        }

        private void MoveLayer_Click(object sender, EventArgs e)
        {
            axMapControl1.MoveLayerTo(1, 0);
        }
    }
}
