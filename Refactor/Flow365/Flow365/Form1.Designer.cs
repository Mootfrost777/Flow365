namespace Flow365
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.carsDataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panelsDataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.destinationsDataGridView = new System.Windows.Forms.DataGridView();
            this.refresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.endOfWorkDate = new System.Windows.Forms.DateTimePicker();
            this.startOfWorkDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.floorsCount = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.createPatternButton = new System.Windows.Forms.Button();
            this.loadFolderButton = new System.Windows.Forms.Button();
            this.saveFolderButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.createPlanButton = new System.Windows.Forms.Button();
            this.isWarn = new System.Windows.Forms.CheckBox();
            this.isProtected = new System.Windows.Forms.CheckBox();
            this.loadedFiles = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carsDataGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelsDataGridView)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.destinationsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.floorsCount)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(588, 336);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.carsDataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(580, 308);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Машины";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // carsDataGridView
            // 
            this.carsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.carsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.carsDataGridView.Name = "carsDataGridView";
            this.carsDataGridView.RowTemplate.Height = 25;
            this.carsDataGridView.Size = new System.Drawing.Size(580, 308);
            this.carsDataGridView.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panelsDataGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(580, 308);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Панели";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panelsDataGridView
            // 
            this.panelsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.panelsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.panelsDataGridView.Name = "panelsDataGridView";
            this.panelsDataGridView.RowTemplate.Height = 25;
            this.panelsDataGridView.Size = new System.Drawing.Size(580, 308);
            this.panelsDataGridView.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.destinationsDataGridView);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(580, 308);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Объекты";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // destinationsDataGridView
            // 
            this.destinationsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.destinationsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.destinationsDataGridView.Name = "destinationsDataGridView";
            this.destinationsDataGridView.RowTemplate.Height = 25;
            this.destinationsDataGridView.Size = new System.Drawing.Size(580, 308);
            this.destinationsDataGridView.TabIndex = 0;
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(429, 338);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(159, 23);
            this.refresh.TabIndex = 1;
            this.refresh.Text = "Обновить информацию";
            this.refresh.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Количество этажей:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Дата завершения работ:";
            // 
            // endOfWorkDate
            // 
            this.endOfWorkDate.Location = new System.Drawing.Point(6, 107);
            this.endOfWorkDate.Name = "endOfWorkDate";
            this.endOfWorkDate.Size = new System.Drawing.Size(186, 23);
            this.endOfWorkDate.TabIndex = 7;
            // 
            // startOfWorkDate
            // 
            this.startOfWorkDate.Location = new System.Drawing.Point(6, 50);
            this.startOfWorkDate.Name = "startOfWorkDate";
            this.startOfWorkDate.Size = new System.Drawing.Size(186, 23);
            this.startOfWorkDate.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Дата начала работ:";
            // 
            // floorsCount
            // 
            this.floorsCount.Location = new System.Drawing.Point(6, 165);
            this.floorsCount.Name = "floorsCount";
            this.floorsCount.Size = new System.Drawing.Size(186, 23);
            this.floorsCount.TabIndex = 10;
            this.floorsCount.ValueChanged += new System.EventHandler(this.floorsCount_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.createPatternButton);
            this.groupBox1.Controls.Add(this.endOfWorkDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.floorsCount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.startOfWorkDate);
            this.groupBox1.Location = new System.Drawing.Point(590, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 222);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Новый шаблон";
            // 
            // createPatternButton
            // 
            this.createPatternButton.Enabled = false;
            this.createPatternButton.Location = new System.Drawing.Point(6, 193);
            this.createPatternButton.Name = "createPatternButton";
            this.createPatternButton.Size = new System.Drawing.Size(186, 23);
            this.createPatternButton.TabIndex = 11;
            this.createPatternButton.Text = "Создать";
            this.createPatternButton.UseVisualStyleBackColor = true;
            this.createPatternButton.Click += new System.EventHandler(this.createPatternButton_Click);
            // 
            // loadFolderButton
            // 
            this.loadFolderButton.Location = new System.Drawing.Point(4, 338);
            this.loadFolderButton.Name = "loadFolderButton";
            this.loadFolderButton.Size = new System.Drawing.Size(75, 23);
            this.loadFolderButton.TabIndex = 12;
            this.loadFolderButton.Text = "Открыть";
            this.loadFolderButton.UseVisualStyleBackColor = true;
            // 
            // saveFolderButton
            // 
            this.saveFolderButton.Location = new System.Drawing.Point(85, 338);
            this.saveFolderButton.Name = "saveFolderButton";
            this.saveFolderButton.Size = new System.Drawing.Size(75, 23);
            this.saveFolderButton.TabIndex = 14;
            this.saveFolderButton.Text = "Сохранить";
            this.saveFolderButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.createPlanButton);
            this.groupBox2.Controls.Add(this.isWarn);
            this.groupBox2.Controls.Add(this.isProtected);
            this.groupBox2.Location = new System.Drawing.Point(590, 260);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(198, 101);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "График монтажа";
            // 
            // createPlanButton
            // 
            this.createPlanButton.Enabled = false;
            this.createPlanButton.Location = new System.Drawing.Point(6, 72);
            this.createPlanButton.Name = "createPlanButton";
            this.createPlanButton.Size = new System.Drawing.Size(186, 23);
            this.createPlanButton.TabIndex = 2;
            this.createPlanButton.Text = "Создать";
            this.createPlanButton.UseVisualStyleBackColor = true;
            // 
            // isWarn
            // 
            this.isWarn.AutoSize = true;
            this.isWarn.Location = new System.Drawing.Point(6, 47);
            this.isWarn.Name = "isWarn";
            this.isWarn.Size = new System.Drawing.Size(162, 19);
            this.isWarn.TabIndex = 1;
            this.isWarn.Text = "Сообщения об ошибках";
            this.isWarn.UseVisualStyleBackColor = true;
            // 
            // isProtected
            // 
            this.isProtected.AutoSize = true;
            this.isProtected.Location = new System.Drawing.Point(6, 22);
            this.isProtected.Name = "isProtected";
            this.isProtected.Size = new System.Drawing.Size(187, 19);
            this.isProtected.TabIndex = 0;
            this.isProtected.Text = "Защитить от редактирования";
            this.isProtected.UseVisualStyleBackColor = true;
            // 
            // loadedFiles
            // 
            this.loadedFiles.FormattingEnabled = true;
            this.loadedFiles.ItemHeight = 15;
            this.loadedFiles.Items.AddRange(new object[] {
            "Ничего не загруженно"});
            this.loadedFiles.Location = new System.Drawing.Point(12, 389);
            this.loadedFiles.Name = "loadedFiles";
            this.loadedFiles.Size = new System.Drawing.Size(148, 49);
            this.loadedFiles.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 371);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "Загруженные файлы:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(795, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.loadedFiles);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.saveFolderButton);
            this.Controls.Add(this.loadFolderButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.carsDataGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelsDataGridView)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.destinationsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.floorsCount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Button refresh;
        private Label label1;
        private Label label2;
        private DateTimePicker endOfWorkDate;
        private DateTimePicker startOfWorkDate;
        private Label label3;
        private NumericUpDown floorsCount;
        private GroupBox groupBox1;
        private Button createPatternButton;
        private Button loadFolderButton;
        private Button saveFolderButton;
        private GroupBox groupBox2;
        private Button createPlanButton;
        private CheckBox isWarn;
        private CheckBox isProtected;
        private ListBox loadedFiles;
        private Label label4;
        private TabPage tabPage1;
        private DataGridView carsDataGridView;
        private DataGridView panelsDataGridView;
        private DataGridView destinationsDataGridView;
        private FolderBrowserDialog folderBrowserDialog;
    }
}