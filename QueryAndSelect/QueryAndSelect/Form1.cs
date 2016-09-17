using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
namespace QueryAndSelect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        UInt16 m_Flag = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            m_Flag = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m_Flag = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            m_Flag = 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            m_Flag = 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            axMapControl1.Map.ClearSelection();
            axMapControl1.Refresh();
            m_Flag = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string strSearchName = this.textBox1.Text.Trim();
            //MessageBox.Show(strSearchName);
            IQueryFilter pQueryFilter = new QueryFilterClass();
            pQueryFilter.WhereClause = "NAME ='" + strSearchName + "'";
            IFeatureCursor pFeatureCussor;
            ILayer pLayer=axMapControl1.Map.get_Layer(0);
            IFeatureLayer pFeatureLayer=pLayer as IFeatureLayer;
            IFeatureClass pFeatureClass=pFeatureLayer.FeatureClass;
            pFeatureCussor = pFeatureClass.Search(pQueryFilter, true);
            IFeature pFeature = pFeatureCussor.NextFeature();
            if (pFeature != null)
            {
                axMapControl1.Map.SelectFeature(axMapControl1.get_Layer(0), pFeature);
                axMapControl1.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            }
        }

        private void axMapControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 1)
            {
                IGeometry pGeometry = null;
                switch (m_Flag)
                {
                    case 1:
                        IPoint pPt = new PointClass();
                        pPt.X = e.mapX; pPt.Y = e.mapY;
                        pGeometry = pPt as IGeometry;
                        //axMapControl1.DrawShape(pGeometry);
                        //axMapControl1.DrawText(pGeometry, "x=" + pPt.X.ToString("f") + "y=" + pPt.Y.ToString("f"));
                        break;
                    case 2:
                        pGeometry = axMapControl1.TrackCircle();
                        break;
                    case 3:
                        pGeometry = axMapControl1.TrackRectangle();
                        break;
                    case 4:
                        pGeometry = axMapControl1.TrackPolygon();
                        break;
                }
                if (pGeometry != null)
                {
                    //ISelectionEnvironment pSelectionEnvironment = new SelectionEnvironmentClass();
                    //pSelectionEnvironment.PointSearchDistance = 100;
                    axMapControl1.Map.SelectByShape(pGeometry, null, false);
                    axMapControl1.Refresh();
                    //axMapControl1.Refresh(esriViewDrawPhase.esriViewGeoSelection,null,null);
                }
            }
            if (e.button == 4)
            {
                axMapControl1.MousePointer = esriControlsMousePointer.esriPointerHand;
                axMapControl1.Pan();
                axMapControl1.MousePointer = esriControlsMousePointer.esriPointerDefault;
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
/*
            OpenFileDialog pOpenFileDialog=new OpenFileDialog();
            pOpenFileDialog.Title = "Select file...";
            pOpenFileDialog.Filter = "mxd file|*.mxd|All file|*.*";
            if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string strMxdFilename = pOpenFileDialog.FileName;
                axMapControl1.LoadMxFile(strMxdFilename);
            }*/
        }

        private void axMapControl1_OnAfterDraw(object sender, IMapControlEvents2_OnAfterDrawEvent e)
        {
            axMapControl1.Focus();
        }
    }
}
