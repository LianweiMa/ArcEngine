using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System.IO;
using System.Text;
namespace ASCII2Shp
{
    class Program
    {
        public static void CreatePointShp(string strASCIIFile, string strShapeFile)
        {
            //新建shapefile工作空间
            IWorkspaceFactory pWorkspaceFactory = new ShapefileWorkspaceFactoryClass();
            //打开图层工作空间
            IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(System.IO.Path.GetDirectoryName(strShapeFile), 0);
            if (pWorkspace == null)
            {
                Console.WriteLine("打开Shape图层失败！");
                return;
            }
            //转换工作空间类型
            IFeatureWorkspace pFeatureWorkspace = pWorkspace as IFeatureWorkspace;
            //定义要素类
            IFeatureClass pFeatureClass;
            if (File.Exists(strShapeFile))
            {
                pFeatureClass = pFeatureWorkspace.OpenFeatureClass(System.IO.Path.GetFileName(strShapeFile));//fileName为文件名(不包含路径)
                IDataset pFeaDataset = pFeatureClass as IDataset;
                pFeaDataset.Delete();
            }
            //创建必要字段
            IFeatureClassDescription pFeatureClassDescription = new FeatureClassDescriptionClass();
            IObjectClassDescription pObjectClassDescription = (IObjectClassDescription)pFeatureClassDescription;
            //创建字段
            IFields pFields = new FieldsClass();
            IFieldsEdit pFieldsEdit = pFields as IFieldsEdit;
            IField pField = new FieldClass();
            IFieldEdit pFieldEdit = pField as IFieldEdit;
            pFieldEdit.Name_2 = "SHAPE";
            pFieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;
            //set up geometry definition
            IGeometryDef pGeometryDef = new GeometryDefClass();
            IGeometryDefEdit pGeometryDefEdit=pGeometryDef as IGeometryDefEdit;
            pGeometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPoint;
            pGeometryDefEdit.HasZ_2 = true;
            //设定坐标系
            ISpatialReferenceFactory pSpatialReferenceFactory=new SpatialReferenceEnvironmentClass();
            IProjectedCoordinateSystem pProjectedCoordinateSystem=pSpatialReferenceFactory.CreateProjectedCoordinateSystem((int)esriSRProjCS4Type.esriSRProjCS_Xian1980_3_Degree_GK_Zone_39);
            pGeometryDefEdit.SpatialReference_2=pProjectedCoordinateSystem;

            pFieldEdit.GeometryDef_2 = pGeometryDef;
            pFieldsEdit.AddField(pField);
            //新建字段
            pField = new FieldClass();
            pFieldEdit = pField as IFieldEdit;
            pFieldEdit.Length_2 = 15;
            pFieldEdit.Name_2 = "X";
            pFieldEdit.AliasName_2 = "X";
            pFieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
            pFieldsEdit.AddField(pField);
            pField = new FieldClass();
            pFieldEdit = pField as IFieldEdit;
            pFieldEdit.Length_2 = 15;
            pFieldEdit.Name_2 = "Y";
            pFieldEdit.AliasName_2 = "Y";
            pFieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
            pFieldsEdit.AddField(pField);
            pField = new FieldClass();
            pFieldEdit = pField as IFieldEdit;
            pFieldEdit.Length_2 = 15;
            pFieldEdit.Name_2 = "Z";
            pFieldEdit.AliasName_2 = "Z";
            pFieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
            pFieldsEdit.AddField(pField);
    
            pFeatureClass = pFeatureWorkspace.CreateFeatureClass((System.IO.Path.GetFileName(strShapeFile)), pFields, pObjectClassDescription.InstanceCLSID, pObjectClassDescription.ClassExtensionCLSID, esriFeatureType.esriFTSimple, "shape", "");
            
            IFeature pFeature;
            IPoint pPoint=new PointClass(); 
            //读取ASCIIFile内的坐标点文件
            StreamReader pStreamReader = new StreamReader(strASCIIFile);
            String strTemp;
           double lfX = 0.0, lfY = 0.0, lfZ=0.0;
            while ((strTemp = pStreamReader.ReadLine()) != null)
            {
                pFeature = pFeatureClass.CreateFeature();
               string []strSplit=strTemp.Split(new char[]{','});
               lfX = Convert.ToDouble(strSplit[2]);
               lfY = Convert.ToDouble(strSplit[3]);
               lfZ = Convert.ToDouble(strSplit[4]);

               int nIndex = pFeature.Fields.FindField("X");
               pFeature.set_Value(nIndex, lfX);
               nIndex = pFeature.Fields.FindField("Y");
               pFeature.set_Value(nIndex, lfY);
               nIndex = pFeature.Fields.FindField("Z");
               pFeature.set_Value(nIndex, lfZ);

               pPoint.PutCoords(lfX, lfY);
               //IMAware pMAware = pPoint as IMAware;
               //pMAware.MAware = true;
               IZAware pZAware = pPoint as IZAware;
               pZAware.ZAware = true;
               pPoint.Z = lfZ;
                //pPoint.M = 10;
                pFeature.Shape = pPoint;
                pFeature.Store();
            }
        }
        
        public void ShapeFunc(string strShapeFile)
        {
            //新建shapefile工作空间
            IWorkspaceFactory pSrcWorkspaceFactory = new ShapefileWorkspaceFactoryClass();
            //打开图层工作空间
            IWorkspace pSrcWorkspace = pSrcWorkspaceFactory.OpenFromFile(System.IO.Path.GetDirectoryName(strShapeFile), 0);
            if (pSrcWorkspace == null)
            {
                Console.WriteLine("打开Shape图层失败！");
                return;
            }
            //转换工作空间类型
            IFeatureWorkspace pSrcFeatureWorkspace = pSrcWorkspace as IFeatureWorkspace;
            //打开图层要素类
            IFeatureClass pFeatureClass = pSrcFeatureWorkspace.OpenFeatureClass(System.IO.Path.GetFileNameWithoutExtension(strShapeFile));
            if (pFeatureClass == null)
            {
                Console.WriteLine("打开Shape图层失败！");
                return;
            }
            //获得要素
            IFeatureCursor pFeatureCussor = pFeatureClass.Search(null, false);
            IFeature pFeature = pFeatureCussor.NextFeature();
            object objValue = null;
            while (pFeature != null)
            {
                IFields pFields = pFeature.Fields;//字段a
                int nIndex = pFields.FindField("a");
                objValue = pFeature.get_Value(nIndex);
                double valA = Convert.ToDouble(objValue);
                //字段b
                nIndex = pFields.FindField("b");
                objValue = pFeature.get_Value(nIndex);
                double valB = Convert.ToDouble(objValue);
                //字段c
                double valC = valA+valB;//利用字段a和字段b的值，计算字段c的值
                nIndex = pFields.FindField("c");
                pFeature.set_Value(nIndex, valC);
                //保存字段c的值
                pFeature.Store();
                pFeature = pFeatureCussor.NextFeature();
            }
            //释放com资源
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pFeatureCussor);
        }
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Warnning: no argument!");
                Console.WriteLine("Note: ASCII2Shp.exe  ASCIIfile  Shapefile");
                return;
            }
            ESRI.ArcGIS.RuntimeManager.BindLicense(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
            ESRI.ArcGIS.esriSystem.IAoInitialize aoInitialize = new ESRI.ArcGIS.esriSystem.AoInitialize();
            ESRI.ArcGIS.esriSystem.esriLicenseStatus licenseStatus = ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseUnavailable;
            licenseStatus = aoInitialize.Initialize(ESRI.ArcGIS.esriSystem.esriLicenseProductCode.esriLicenseProductCodeAdvanced);
            if (licenseStatus == ESRI.ArcGIS.esriSystem.esriLicenseStatus.esriLicenseNotInitialized)
            {
                Console.WriteLine("没有esriLicenseProductCodeAdvanced许可！");
                return;
            }
            string strASCIIFile = args[0];
            string strShpFile = args[1];
            CreatePointShp(strASCIIFile,strShpFile);
        }
    }
}
