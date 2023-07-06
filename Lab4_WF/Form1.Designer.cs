
namespace Lab4_WF
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.sourceFileNameTextBox = new System.Windows.Forms.TextBox();
            this.destFileNameTextBox = new System.Windows.Forms.TextBox();
            this.openButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.packButton = new System.Windows.Forms.Button();
            this.unpackButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // sourceFileNameTextBox
            // 
            this.sourceFileNameTextBox.Location = new System.Drawing.Point(40, 50);
            this.sourceFileNameTextBox.Name = "sourceFileNameTextBox";
            this.sourceFileNameTextBox.Size = new System.Drawing.Size(516, 22);
            this.sourceFileNameTextBox.TabIndex = 0;
            // 
            // destFileNameTextBox
            // 
            this.destFileNameTextBox.Location = new System.Drawing.Point(40, 129);
            this.destFileNameTextBox.Name = "destFileNameTextBox";
            this.destFileNameTextBox.Size = new System.Drawing.Size(516, 22);
            this.destFileNameTextBox.TabIndex = 1;
            // 
            // openButton
            // 
            this.openButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openButton.Location = new System.Drawing.Point(585, 46);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(87, 31);
            this.openButton.TabIndex = 2;
            this.openButton.Text = "Открыть";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveButton.Location = new System.Drawing.Point(579, 125);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(95, 31);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // packButton
            // 
            this.packButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.packButton.Location = new System.Drawing.Point(112, 182);
            this.packButton.Name = "packButton";
            this.packButton.Size = new System.Drawing.Size(75, 31);
            this.packButton.TabIndex = 4;
            this.packButton.Text = "Pack";
            this.packButton.UseVisualStyleBackColor = true;
            this.packButton.Click += new System.EventHandler(this.packButton_Click);
            // 
            // unpackButton
            // 
            this.unpackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.unpackButton.Location = new System.Drawing.Point(412, 183);
            this.unpackButton.Name = "unpackButton";
            this.unpackButton.Size = new System.Drawing.Size(75, 30);
            this.unpackButton.TabIndex = 5;
            this.unpackButton.Text = "Unpack";
            this.unpackButton.UseVisualStyleBackColor = true;
            this.unpackButton.Click += new System.EventHandler(this.unpackButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stopButton.Location = new System.Drawing.Point(585, 228);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 30);
            this.stopButton.TabIndex = 6;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(65, 235);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(453, 23);
            this.progressBar.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 270);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.unpackButton);
            this.Controls.Add(this.packButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.destFileNameTextBox);
            this.Controls.Add(this.sourceFileNameTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sourceFileNameTextBox;
        private System.Windows.Forms.TextBox destFileNameTextBox;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button packButton;
        private System.Windows.Forms.Button unpackButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

