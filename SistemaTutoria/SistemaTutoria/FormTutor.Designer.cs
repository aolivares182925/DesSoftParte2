
namespace SistemaTutoria
{
    partial class FormTutor
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lApellido1 = new System.Windows.Forms.Label();
            this.lNombre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lApellido2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lApellido2);
            this.panel1.Controls.Add(this.lApellido1);
            this.panel1.Controls.Add(this.lNombre);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 604);
            this.panel1.TabIndex = 0;
            // 
            // lApellido1
            // 
            this.lApellido1.AutoSize = true;
            this.lApellido1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lApellido1.Location = new System.Drawing.Point(101, 200);
            this.lApellido1.Name = "lApellido1";
            this.lApellido1.Size = new System.Drawing.Size(64, 25);
            this.lApellido1.TabIndex = 2;
            this.lApellido1.Text = "label2";
            // 
            // lNombre
            // 
            this.lNombre.AutoSize = true;
            this.lNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNombre.Location = new System.Drawing.Point(99, 157);
            this.lNombre.Name = "lNombre";
            this.lNombre.Size = new System.Drawing.Size(64, 25);
            this.lNombre.TabIndex = 1;
            this.lNombre.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "BIENVENIDO";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lApellido2
            // 
            this.lApellido2.AutoSize = true;
            this.lApellido2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lApellido2.Location = new System.Drawing.Point(99, 240);
            this.lApellido2.Name = "lApellido2";
            this.lApellido2.Size = new System.Drawing.Size(64, 25);
            this.lApellido2.TabIndex = 3;
            this.lApellido2.Text = "label2";
            // 
            // FormTutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 604);
            this.Controls.Add(this.panel1);
            this.Name = "FormTutor";
            this.Text = "FormTutor";
            this.Load += new System.EventHandler(this.FormTutor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lApellido1;
        private System.Windows.Forms.Label lApellido2;
    }
}