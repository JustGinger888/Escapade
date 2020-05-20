namespace URL
{
    partial class MainGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbx_MainItem = new System.Windows.Forms.PictureBox();
            this._GridMainMap = new System.Windows.Forms.Panel();
            this._lblRetry = new System.Windows.Forms.Label();
            this._GridMiniMap = new System.Windows.Forms.Panel();
            this._tmrMovementCheck = new System.Windows.Forms.Timer(this.components);
            this._tmrInputCheck = new System.Windows.Forms.Timer(this.components);
            this._BombCount = new System.Windows.Forms.Label();
            this._KeyCount = new System.Windows.Forms.Label();
            this._ChestCount = new System.Windows.Forms.Label();
            this._CoinCount = new System.Windows.Forms.Label();
            this._tmrEnemyMovement = new System.Windows.Forms.Timer(this.components);
            this._tmrBulletCheck = new System.Windows.Forms.Timer(this.components);
            this._pnlEnemyHealthGrid = new System.Windows.Forms.Panel();
            this._pnlCharacterHealthGrid = new System.Windows.Forms.Panel();
            this._tmrAStar = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_MainItem)).BeginInit();
            this._GridMainMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbx_MainItem
            // 
            this.pbx_MainItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbx_MainItem.Location = new System.Drawing.Point(47, 15);
            this.pbx_MainItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbx_MainItem.Name = "pbx_MainItem";
            this.pbx_MainItem.Size = new System.Drawing.Size(76, 70);
            this.pbx_MainItem.TabIndex = 0;
            this.pbx_MainItem.TabStop = false;
            // 
            // _GridMainMap
            // 
            this._GridMainMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this._GridMainMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._GridMainMap.Controls.Add(this._lblRetry);
            this._GridMainMap.Location = new System.Drawing.Point(341, 167);
            this._GridMainMap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._GridMainMap.Name = "_GridMainMap";
            this._GridMainMap.Size = new System.Drawing.Size(707, 398);
            this._GridMainMap.TabIndex = 15;
            // 
            // _lblRetry
            // 
            this._lblRetry.AutoSize = true;
            this._lblRetry.BackColor = System.Drawing.Color.Transparent;
            this._lblRetry.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lblRetry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblRetry.ForeColor = System.Drawing.Color.Lime;
            this._lblRetry.Location = new System.Drawing.Point(308, 324);
            this._lblRetry.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblRetry.Name = "_lblRetry";
            this._lblRetry.Size = new System.Drawing.Size(79, 27);
            this._lblRetry.TabIndex = 23;
            this._lblRetry.Text = "RETRY";
            this._lblRetry.Visible = false;
            this._lblRetry.Click += new System.EventHandler(this._lblRetry_Click);
            // 
            // _GridMiniMap
            // 
            this._GridMiniMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this._GridMiniMap.Location = new System.Drawing.Point(1152, 427);
            this._GridMiniMap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._GridMiniMap.Name = "_GridMiniMap";
            this._GridMiniMap.Size = new System.Drawing.Size(151, 139);
            this._GridMiniMap.TabIndex = 16;
            // 
            // _tmrMovementCheck
            // 
            this._tmrMovementCheck.Interval = 200;
            this._tmrMovementCheck.Tick += new System.EventHandler(this._tmrMovementCheck_Tick);
            // 
            // _tmrInputCheck
            // 
            this._tmrInputCheck.Interval = 1000;
            this._tmrInputCheck.Tick += new System.EventHandler(this._tmrInputCheck_Tick);
            // 
            // _BombCount
            // 
            this._BombCount.AutoSize = true;
            this._BombCount.BackColor = System.Drawing.Color.Transparent;
            this._BombCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._BombCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._BombCount.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this._BombCount.Location = new System.Drawing.Point(91, 154);
            this._BombCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._BombCount.Name = "_BombCount";
            this._BombCount.Size = new System.Drawing.Size(67, 27);
            this._BombCount.TabIndex = 17;
            this._BombCount.Text = "TEST";
            // 
            // _KeyCount
            // 
            this._KeyCount.AutoSize = true;
            this._KeyCount.BackColor = System.Drawing.Color.Transparent;
            this._KeyCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._KeyCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._KeyCount.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this._KeyCount.Location = new System.Drawing.Point(91, 209);
            this._KeyCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._KeyCount.Name = "_KeyCount";
            this._KeyCount.Size = new System.Drawing.Size(67, 27);
            this._KeyCount.TabIndex = 18;
            this._KeyCount.Text = "TEST";
            // 
            // _ChestCount
            // 
            this._ChestCount.AutoSize = true;
            this._ChestCount.BackColor = System.Drawing.Color.Transparent;
            this._ChestCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._ChestCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ChestCount.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this._ChestCount.Location = new System.Drawing.Point(91, 257);
            this._ChestCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._ChestCount.Name = "_ChestCount";
            this._ChestCount.Size = new System.Drawing.Size(67, 27);
            this._ChestCount.TabIndex = 19;
            this._ChestCount.Text = "TEST";
            // 
            // _CoinCount
            // 
            this._CoinCount.AutoSize = true;
            this._CoinCount.BackColor = System.Drawing.Color.Transparent;
            this._CoinCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._CoinCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CoinCount.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this._CoinCount.Location = new System.Drawing.Point(91, 306);
            this._CoinCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._CoinCount.Name = "_CoinCount";
            this._CoinCount.Size = new System.Drawing.Size(67, 27);
            this._CoinCount.TabIndex = 20;
            this._CoinCount.Text = "TEST";
            // 
            // _tmrEnemyMovement
            // 
            this._tmrEnemyMovement.Interval = 200;
            this._tmrEnemyMovement.Tick += new System.EventHandler(this._tmrEnemyMovement_Tick);
            // 
            // _tmrBulletCheck
            // 
            this._tmrBulletCheck.Interval = 50;
            this._tmrBulletCheck.Tick += new System.EventHandler(this._tmrBulletCheck_Tick);
            // 
            // _pnlEnemyHealthGrid
            // 
            this._pnlEnemyHealthGrid.BackColor = System.Drawing.Color.Transparent;
            this._pnlEnemyHealthGrid.Location = new System.Drawing.Point(1011, 15);
            this._pnlEnemyHealthGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._pnlEnemyHealthGrid.Name = "_pnlEnemyHealthGrid";
            this._pnlEnemyHealthGrid.Size = new System.Drawing.Size(344, 32);
            this._pnlEnemyHealthGrid.TabIndex = 21;
            // 
            // _pnlCharacterHealthGrid
            // 
            this._pnlCharacterHealthGrid.BackColor = System.Drawing.Color.Transparent;
            this._pnlCharacterHealthGrid.Location = new System.Drawing.Point(132, 15);
            this._pnlCharacterHealthGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._pnlCharacterHealthGrid.Name = "_pnlCharacterHealthGrid";
            this._pnlCharacterHealthGrid.Size = new System.Drawing.Size(693, 32);
            this._pnlCharacterHealthGrid.TabIndex = 22;
            // 
            // _tmrAStar
            // 
            this._tmrAStar.Enabled = true;
            this._tmrAStar.Tick += new System.EventHandler(this._tmrAStar_Tick);
            // 
            // MainGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::URL.Properties.Resources.BG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1404, 766);
            this.Controls.Add(this._pnlCharacterHealthGrid);
            this.Controls.Add(this._pnlEnemyHealthGrid);
            this.Controls.Add(this._CoinCount);
            this.Controls.Add(this._ChestCount);
            this.Controls.Add(this._KeyCount);
            this.Controls.Add(this._BombCount);
            this.Controls.Add(this._GridMiniMap);
            this.Controls.Add(this._GridMainMap);
            this.Controls.Add(this.pbx_MainItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainGame";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_MainItem)).EndInit();
            this._GridMainMap.ResumeLayout(false);
            this._GridMainMap.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbx_MainItem;
        private System.Windows.Forms.Panel _GridMainMap;
        private System.Windows.Forms.Panel _GridMiniMap;
        private System.Windows.Forms.Timer _tmrInputCheck;
        private System.Windows.Forms.Label _BombCount;
        private System.Windows.Forms.Label _KeyCount;
        private System.Windows.Forms.Label _ChestCount;
        private System.Windows.Forms.Label _CoinCount;
        public System.Windows.Forms.Timer _tmrMovementCheck;
        private System.Windows.Forms.Timer _tmrEnemyMovement;
        private System.Windows.Forms.Timer _tmrBulletCheck;
        private System.Windows.Forms.Panel _pnlEnemyHealthGrid;
        private System.Windows.Forms.Panel _pnlCharacterHealthGrid;
        private System.Windows.Forms.Timer _tmrAStar;
        private System.Windows.Forms.Label _lblRetry;
    }
}

