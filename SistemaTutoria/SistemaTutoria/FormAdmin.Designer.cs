
namespace SistemaTutoria
{
    partial class FormAdmin
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenuBar = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMenuAlumnos = new System.Windows.Forms.Button();
            this.btnMenuTutores = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lNombre = new System.Windows.Forms.Label();
            this.lApellido1 = new System.Windows.Forms.Label();
            this.lApellido2 = new System.Windows.Forms.Label();
            this.panelMenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenuBar
            // 
            this.panelMenuBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.panelMenuBar.Controls.Add(this.lApellido2);
            this.panelMenuBar.Controls.Add(this.lApellido1);
            this.panelMenuBar.Controls.Add(this.lNombre);
            this.panelMenuBar.Controls.Add(this.panel1);
            this.panelMenuBar.Controls.Add(this.label4);
            this.panelMenuBar.Controls.Add(this.pictureBox1);
            this.panelMenuBar.Controls.Add(this.btnMenuAlumnos);
            this.panelMenuBar.Controls.Add(this.btnMenuTutores);
            this.panelMenuBar.Location = new System.Drawing.Point(0, 0);
            this.panelMenuBar.Margin = new System.Windows.Forms.Padding(4);
            this.panelMenuBar.Name = "panelMenuBar";
            this.panelMenuBar.Size = new System.Drawing.Size(267, 862);
            this.panelMenuBar.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(68)))));
            this.panel1.Location = new System.Drawing.Point(99, 197);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(67, 1);
            this.panel1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(95, 150);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "UNSAAC";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.pictureBox1.BackgroundImage = global::SistemaTutoria.Properties.Resources.logosmall;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(267, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnMenuAlumnos
            // 
            this.btnMenuAlumnos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnMenuAlumnos.FlatAppearance.BorderSize = 0;
            this.btnMenuAlumnos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnMenuAlumnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuAlumnos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuAlumnos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnMenuAlumnos.Image = global::SistemaTutoria.Properties.Resources.icons8_colegial_en_un_escritorio_32;
            this.btnMenuAlumnos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuAlumnos.Location = new System.Drawing.Point(0, 366);
            this.btnMenuAlumnos.Margin = new System.Windows.Forms.Padding(4);
            this.btnMenuAlumnos.Name = "btnMenuAlumnos";
            this.btnMenuAlumnos.Size = new System.Drawing.Size(267, 49);
            this.btnMenuAlumnos.TabIndex = 0;
            this.btnMenuAlumnos.Text = "     Alumnos";
            this.btnMenuAlumnos.UseVisualStyleBackColor = true;
            this.btnMenuAlumnos.Click += new System.EventHandler(this.btnMenuAlumnos_Click);
            // 
            // btnMenuTutores
            // 
            this.btnMenuTutores.FlatAppearance.BorderSize = 0;
            this.btnMenuTutores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnMenuTutores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuTutores.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuTutores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnMenuTutores.Image = global::SistemaTutoria.Properties.Resources.icons8_profesor_32;
            this.btnMenuTutores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuTutores.Location = new System.Drawing.Point(0, 308);
            this.btnMenuTutores.Margin = new System.Windows.Forms.Padding(4);
            this.btnMenuTutores.Name = "btnMenuTutores";
            this.btnMenuTutores.Size = new System.Drawing.Size(267, 49);
            this.btnMenuTutores.TabIndex = 0;
            this.btnMenuTutores.Text = "    Tutores";
            this.btnMenuTutores.UseVisualStyleBackColor = true;
            this.btnMenuTutores.Click += new System.EventHandler(this.btnMenuTutores_Click);
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(287, 62);
            this.panel.Margin = new System.Windows.Forms.Padding(4);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1253, 763);
            this.panel.TabIndex = 1;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.White;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(195)))));
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Image = global::SistemaTutoria.Properties.Resources.icons8_macos_minimizar_31;
            this.btnMinimize.Location = new System.Drawing.Point(1430, 11);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(4);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(47, 43);
            this.btnMinimize.TabIndex = 2;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(224)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::SistemaTutoria.Properties.Resources.icons8_macos_cerrar_31;
            this.btnClose.Location = new System.Drawing.Point(1485, 11);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(47, 43);
            this.btnClose.TabIndex = 2;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(267, 62);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1333, 800);
            this.panel2.TabIndex = 3;
            // 
            // lNombre
            // 
            this.lNombre.AutoSize = true;
            this.lNombre.BackColor = System.Drawing.Color.Transparent;
            this.lNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNombre.ForeColor = System.Drawing.Color.White;
            this.lNombre.Location = new System.Drawing.Point(12, 202);
            this.lNombre.Name = "lNombre";
            this.lNombre.Size = new System.Drawing.Size(81, 25);
            this.lNombre.TabIndex = 4;
            this.lNombre.Text = "Nombre";
            this.lNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lApellido1
            // 
            this.lApellido1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lApellido1.AutoSize = true;
            this.lApellido1.BackColor = System.Drawing.Color.Transparent;
            this.lApellido1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lApellido1.ForeColor = System.Drawing.Color.White;
            this.lApellido1.Location = new System.Drawing.Point(12, 234);
            this.lApellido1.Name = "lApellido1";
            this.lApellido1.Size = new System.Drawing.Size(155, 25);
            this.lApellido1.TabIndex = 5;
            this.lApellido1.Text = "Apellido Paterno";
            this.lApellido1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lApellido2
            // 
            this.lApellido2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lApellido2.AutoSize = true;
            this.lApellido2.BackColor = System.Drawing.Color.Transparent;
            this.lApellido2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lApellido2.ForeColor = System.Drawing.Color.White;
            this.lApellido2.Location = new System.Drawing.Point(12, 266);
            this.lApellido2.Name = "lApellido2";
            this.lApellido2.Size = new System.Drawing.Size(159, 25);
            this.lApellido2.TabIndex = 6;
            this.lApellido2.Text = "Apellido Materno";
            this.lApellido2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1600, 862);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.panelMenuBar);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormAdmin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "miapp";
            this.Load += new System.EventHandler(this.Crud_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Crud_MouseDown);
            this.panelMenuBar.ResumeLayout(false);
            this.panelMenuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelMenuBar;
        private System.Windows.Forms.Button btnMenuTutores;
        private System.Windows.Forms.Button btnMenuAlumnos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lNombre;
        private System.Windows.Forms.Label lApellido2;
        private System.Windows.Forms.Label lApellido1;
    }
}

