using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pseudo_assembly_interpreter
{
    public partial class Form1 : Form
    {
        OS os = new OS();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            register_labels = new System.Windows.Forms.Label[20];
            for (int i = 0; i < 16; i++)
            {
                this.register_labels[i] = new System.Windows.Forms.Label();
                this.RegisterPanel.Controls.Add(this.register_labels[i]);

                this.register_labels[i].AutoSize = true;
                this.register_labels[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.register_labels[i].Location = new System.Drawing.Point(3, 0);
                this.register_labels[i].MaximumSize = new System.Drawing.Size(100, 100);
                this.register_labels[i].MinimumSize = new System.Drawing.Size(200, 0);
                this.register_labels[i].Name = "register_label" + i;
                this.register_labels[i].Size = new System.Drawing.Size(200, 26);
                this.register_labels[i].TabIndex = 2;
                this.register_labels[i].Text = "R" + i + ": ";
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void execute_button_Click(object sender, EventArgs e) {
            List<string> codeLines = new List<string>();

            foreach (string line in UserInput.Lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    codeLines.Add(line);
                    //Console.Out.WriteLine(line);
                }
            }

            os.process_program(codeLines);            
        }
    }
}
