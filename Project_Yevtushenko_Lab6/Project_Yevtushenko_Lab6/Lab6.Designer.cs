namespace Project_Yevtushenko_Lab6
{
    partial class Lab6
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();

            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();

            // dataGridView1
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Size = new Size(500, 250);

            // button1
            button1.Location = new Point(12, 280);
            button1.Size = new Size(100, 30);
            button1.Text = "Додати";
            button1.Click += button1_Click;

            // button2
            button2.Location = new Point(120, 280);
            button2.Size = new Size(100, 30);
            button2.Text = "Видалити";
            button2.Click += button2_Click;

            // button3
            button3.Location = new Point(230, 280);
            button3.Size = new Size(100, 30);
            button3.Text = "Зберегти";
            button3.Click += button3_Click;

            // button4
            button4.Location = new Point(340, 280);
            button4.Size = new Size(100, 30);
            button4.Text = "Відкрити";
            button4.Click += button4_Click;

            // form
            ClientSize = new Size(550, 340);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(button4);

            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
    }
}