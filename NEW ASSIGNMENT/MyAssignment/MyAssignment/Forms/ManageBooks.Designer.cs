namespace MyAssignment.Forms
{
    partial class ManageBooks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageBooks));
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            bId = new TextBox();
            bTitle = new TextBox();
            bAuthor = new TextBox();
            bIsbn = new TextBox();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(661, 277);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(286, 362);
            button1.Name = "button1";
            button1.Size = new Size(135, 38);
            button1.TabIndex = 1;
            button1.Text = "Add Book";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(439, 362);
            button2.Name = "button2";
            button2.Size = new Size(154, 38);
            button2.TabIndex = 2;
            button2.Text = "Remove Book";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(771, 362);
            button3.Name = "button3";
            button3.Size = new Size(135, 38);
            button3.TabIndex = 3;
            button3.Text = "Refresh";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(715, 51);
            label1.Name = "label1";
            label1.Size = new Size(86, 25);
            label1.TabIndex = 4;
            label1.Text = "Book ID :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(744, 92);
            label2.Name = "label2";
            label2.Size = new Size(57, 25);
            label2.TabIndex = 5;
            label2.Text = "Title :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(717, 130);
            label3.Name = "label3";
            label3.Size = new Size(84, 25);
            label3.TabIndex = 6;
            label3.Text = "Author : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(735, 168);
            label4.Name = "label4";
            label4.Size = new Size(66, 25);
            label4.TabIndex = 7;
            label4.Text = "ISBN : ";
            label4.Click += label4_Click;
            // 
            // bId
            // 
            bId.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            bId.Location = new Point(815, 51);
            bId.Name = "bId";
            bId.Size = new Size(199, 32);
            bId.TabIndex = 9;
            // 
            // bTitle
            // 
            bTitle.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            bTitle.Location = new Point(815, 89);
            bTitle.Name = "bTitle";
            bTitle.Size = new Size(199, 32);
            bTitle.TabIndex = 10;
            // 
            // bAuthor
            // 
            bAuthor.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            bAuthor.Location = new Point(815, 127);
            bAuthor.Name = "bAuthor";
            bAuthor.Size = new Size(199, 32);
            bAuthor.TabIndex = 11;
            // 
            // bIsbn
            // 
            bIsbn.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            bIsbn.Location = new Point(815, 165);
            bIsbn.Name = "bIsbn";
            bIsbn.Size = new Size(199, 32);
            bIsbn.TabIndex = 12;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button4.Location = new Point(612, 362);
            button4.Name = "button4";
            button4.Size = new Size(135, 38);
            button4.TabIndex = 14;
            button4.Text = "Go Back";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // ManageBooks
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1043, 450);
            Controls.Add(button4);
            Controls.Add(bIsbn);
            Controls.Add(bAuthor);
            Controls.Add(bTitle);
            Controls.Add(bId);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "ManageBooks";
            Text = "ManageBooks";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox bId;
        private TextBox bTitle;
        private TextBox bAuthor;
        private TextBox bIsbn;
        private Button button4;
    }
}