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
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;

namespace EagleEye
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void axMapControl1_OnBeforeScreenDraw(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnBeforeScreenDrawEvent e)
        {
           // axMapControl1.MousePointer = esriControlsMousePointer.esriPointerHourglass;
        }

        private void axMapControl1_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            IEnvelope pEnvelope = e.newEnvelope as IEnvelope;
            IGraphicsContainer pGraphicsContainer = axMapControl2.Map as IGraphicsContainer;
            IActiveView pActview = pGraphicsContainer as IActiveView;
            pGraphicsContainer.DeleteAllElements();
            IElement pElement = new RectangleElementClass();
            pElement.Geometry = pEnvelope;
            //填充区（）需要有填充符号，而填充符号（）需要填充线符号（）作为边界
            ILineSymbol pLineSymbol = new SimpleLineSymbolClass();
            IRgbColor pRgb = new RgbColorClass();
            pRgb.Red = 255; pRgb.Blue = 0; pRgb.Green = 0;
            pLineSymbol.Color = pRgb;
            pLineSymbol.Width = 2;
            IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Outline = pLineSymbol;
            pRgb.Red = 9; pRgb.Blue = 0; pRgb.Green = 0;
            pRgb.Transparency = 0;
            pFillSymbol.Color = pRgb;
            IFillShapeElement pFillShapeElement = pElement as IFillShapeElement;
            pFillShapeElement.Symbol = pFillSymbol;
            


            pGraphicsContainer.AddElement((IElement)pFillShapeElement, 0);
            
            
            axMapControl2.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private void axMapControl2_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            IPoint pPt = new PointClass();
            pPt.X = e.mapX; pPt.Y = e.mapY;
            axMapControl1.CenterAt(pPt);
        }
    }
}
