using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;
namespace DrawFeature
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        UInt16 m_Flag = 0;

        private void axMapControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            //MessageBox.Show(m_Flag.ToString("d"));
           
            IGeometry pGeometry = null;
            switch(m_Flag)
            {
                case 1:
                    pGeometry = axMapControl1.TrackLine();
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
                case 5:
                    IPoint pPt = new PointClass();
                    pPt.X = e.mapX;pPt.Y=e.mapY;
                    pGeometry = pPt as IGeometry;
                    axMapControl1.DrawText(pGeometry, "x=" + pPt.X.ToString("f") + "y=" + pPt.Y.ToString("f"));
                    break;
                default:
                    {
                        break;
                    }                   
            }
            if (null!=pGeometry) axMapControl1.DrawShape(pGeometry);
            axMapControl1.Refresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeography, null, null);
            
        }

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
            m_Flag = 5;
        }

        private void axMapControl1_OnBeforeScreenDraw(object sender, IMapControlEvents2_OnBeforeScreenDrawEvent e)
        {
            axMapControl1.MousePointer = esriControlsMousePointer.esriPointerCrosshair;
        }
    }
}
