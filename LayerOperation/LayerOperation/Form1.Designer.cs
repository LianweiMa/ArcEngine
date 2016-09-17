namespace LayerOperation
{
    partial class LayerOP
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayerOP));
            this.AddLayer = new System.Windows.Forms.Button();
            this.AddShape = new System.Windows.Forms.Button();
            this.DeleteLayer = new System.Windows.Forms.Button();
            this.MoveLayer = new System.Windows.Forms.Button();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // AddLayer
            // 
            this.AddLayer.Location = new System.Drawing.Point(628, 38);
            this.AddLayer.Name = "AddLayer";
            this.AddLayer.Size = new System.Drawing.Size(75, 23);
            this.AddLayer.TabIndex = 0;
            this.AddLayer.Text = "添加图层";
            this.AddLayer.UseVisualStyleBackColor = true;
            this.AddLayer.Click += new System.EventHandler(this.AddLayer_Click);
            // 
            // AddShape
            // 
            this.AddShape.Location = new System.Drawing.Point(628, 119);
            this.AddShape.Name = "AddShape";
            this.AddShape.Size = new System.Drawing.Size(75, 23);
            this.AddShape.TabIndex = 1;
            this.AddShape.Text = "添加Shape";
            this.AddShape.UseVisualStyleBackColor = true;
            this.AddShape.Click += new System.EventHandler(this.AddShape_Click);
            // 
            // DeleteLayer
            // 
            this.DeleteLayer.Location = new System.Drawing.Point(628, 211);
            this.DeleteLayer.Name = "DeleteLayer";
            this.DeleteLayer.Size = new System.Drawing.Size(75, 23);
            this.DeleteLayer.TabIndex = 2;
            this.DeleteLayer.Text = "删除图层";
            this.DeleteLayer.UseVisualStyleBackColor = true;
            this.DeleteLayer.Click += new System.EventHandler(this.DeleteLayer_Click);
            // 
            // MoveLayer
            // 
            this.MoveLayer.Location = new System.Drawing.Point(628, 312);
            this.MoveLayer.Name = "MoveLayer";
            this.MoveLayer.Size = new System.Drawing.Size(75, 23);
            this.MoveLayer.TabIndex = 3;
            this.MoveLayer.Text = "移动图层";
            this.MoveLayer.UseVisualStyleBackColor = true;
            this.MoveLayer.Click += new System.EventHandler(this.MoveLayer_Click);
            // 
            // axMapControl1
            // 
            this.axMapControl1.Location = new System.Drawing.Point(13, 13);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(587, 442);
            this.axMapControl1.TabIndex = 4;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(653, 412);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(629, 412);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "全图";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LayerOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 467);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axMapControl1);
            this.Controls.Add(this.MoveLayer);
            this.Controls.Add(this.DeleteLayer);
            this.Controls.Add(this.AddShape);
            this.Controls.Add(this.AddLayer);
            this.Name = "LayerOP";
            this.Text = "图层操作";
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddLayer;
        private System.Windows.Forms.Button AddShape;
        private System.Windows.Forms.Button DeleteLayer;
        private System.Windows.Forms.Button MoveLayer;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.Button button1;
    }
}

