
namespace SistemaTutoria
{
    partial class FormFichaTutoria
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
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNombres = new System.Windows.Forms.TextBox();
            this.tbCodEscuela = new System.Windows.Forms.TextBox();
            this.lblCodEscuela = new System.Windows.Forms.Label();
            this.tbApPaterno = new System.Windows.Forms.TextBox();
            this.tbCodigo = new System.Windows.Forms.TextBox();
            this.lblApPaterno = new System.Windows.Forms.Label();
            this.lblNombres = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblApMaterno = new System.Windows.Forms.Label();
            this.tbApMaterno = new System.Windows.Forms.TextBox();
            this.lblSituacion = new System.Windows.Forms.Label();
            this.tbSituacion = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSesion1 = new System.Windows.Forms.Label();
            this.lblSesion3 = new System.Windows.Forms.Label();
            this.lblSesion2 = new System.Windows.Forms.Label();
            this.lblFecha1 = new System.Windows.Forms.Label();
            this.lblFecha2 = new System.Windows.Forms.Label();
            this.lblFecha3 = new System.Windows.Forms.Label();
            this.dTP_Sesion1 = new System.Windows.Forms.DateTimePicker();
            this.dTP_Sesion2 = new System.Windows.Forms.DateTimePicker();
            this.dTP_Sesion3 = new System.Windows.Forms.DateTimePicker();
            this.cB_Tipo1 = new System.Windows.Forms.ComboBox();
            this.cB_Tipo2 = new System.Windows.Forms.ComboBox();
            this.cB_Tipo3 = new System.Windows.Forms.ComboBox();
            this.panelTitulo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(195)))));
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Image = global::SistemaTutoria.Properties.Resources.icons8_macos_minimizar_31;
            this.btnMinimize.Location = new System.Drawing.Point(685, 4);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(4);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(47, 43);
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(224)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::SistemaTutoria.Properties.Resources.icons8_macos_cerrar_31;
            this.btnClose.Location = new System.Drawing.Point(740, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(47, 43);
            this.btnClose.TabIndex = 4;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.panelTitulo.Controls.Add(this.label1);
            this.panelTitulo.Controls.Add(this.btnMinimize);
            this.panelTitulo.Controls.Add(this.btnClose);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(800, 48);
            this.panelTitulo.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(316, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ficha Tutoria";
            // 
            // tbNombres
            // 
            this.tbNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombres.Location = new System.Drawing.Point(155, 48);
            this.tbNombres.Margin = new System.Windows.Forms.Padding(4);
            this.tbNombres.Name = "tbNombres";
            this.tbNombres.ReadOnly = true;
            this.tbNombres.Size = new System.Drawing.Size(262, 26);
            this.tbNombres.TabIndex = 17;
            // 
            // tbCodEscuela
            // 
            this.tbCodEscuela.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCodEscuela.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCodEscuela.Location = new System.Drawing.Point(155, 184);
            this.tbCodEscuela.Margin = new System.Windows.Forms.Padding(4);
            this.tbCodEscuela.Name = "tbCodEscuela";
            this.tbCodEscuela.ReadOnly = true;
            this.tbCodEscuela.Size = new System.Drawing.Size(262, 26);
            this.tbCodEscuela.TabIndex = 18;
            // 
            // lblCodEscuela
            // 
            this.lblCodEscuela.AutoSize = true;
            this.lblCodEscuela.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodEscuela.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.lblCodEscuela.Location = new System.Drawing.Point(39, 186);
            this.lblCodEscuela.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodEscuela.Name = "lblCodEscuela";
            this.lblCodEscuela.Size = new System.Drawing.Size(89, 20);
            this.lblCodEscuela.TabIndex = 11;
            this.lblCodEscuela.Text = "Escuela P.";
            // 
            // tbApPaterno
            // 
            this.tbApPaterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbApPaterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbApPaterno.Location = new System.Drawing.Point(155, 82);
            this.tbApPaterno.Margin = new System.Windows.Forms.Padding(4);
            this.tbApPaterno.Name = "tbApPaterno";
            this.tbApPaterno.ReadOnly = true;
            this.tbApPaterno.Size = new System.Drawing.Size(262, 26);
            this.tbApPaterno.TabIndex = 21;
            // 
            // tbCodigo
            // 
            this.tbCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCodigo.Location = new System.Drawing.Point(155, 14);
            this.tbCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.ReadOnly = true;
            this.tbCodigo.Size = new System.Drawing.Size(262, 26);
            this.tbCodigo.TabIndex = 22;
            // 
            // lblApPaterno
            // 
            this.lblApPaterno.AutoSize = true;
            this.lblApPaterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApPaterno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.lblApPaterno.Location = new System.Drawing.Point(39, 84);
            this.lblApPaterno.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApPaterno.Name = "lblApPaterno";
            this.lblApPaterno.Size = new System.Drawing.Size(96, 20);
            this.lblApPaterno.TabIndex = 14;
            this.lblApPaterno.Text = "Ap. Paterno";
            this.lblApPaterno.Click += new System.EventHandler(this.lblApPaterno_Click);
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombres.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.lblNombres.Location = new System.Drawing.Point(39, 50);
            this.lblNombres.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(77, 20);
            this.lblNombres.TabIndex = 15;
            this.lblNombres.Text = "Nombres";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.lblCodigo.Location = new System.Drawing.Point(39, 16);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(61, 20);
            this.lblCodigo.TabIndex = 16;
            this.lblCodigo.Text = "Codigo";
            // 
            // lblApMaterno
            // 
            this.lblApMaterno.AutoSize = true;
            this.lblApMaterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApMaterno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.lblApMaterno.Location = new System.Drawing.Point(39, 118);
            this.lblApMaterno.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApMaterno.Name = "lblApMaterno";
            this.lblApMaterno.Size = new System.Drawing.Size(99, 20);
            this.lblApMaterno.TabIndex = 13;
            this.lblApMaterno.Text = "Ap. Materno";
            // 
            // tbApMaterno
            // 
            this.tbApMaterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbApMaterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbApMaterno.Location = new System.Drawing.Point(155, 116);
            this.tbApMaterno.Margin = new System.Windows.Forms.Padding(4);
            this.tbApMaterno.Name = "tbApMaterno";
            this.tbApMaterno.ReadOnly = true;
            this.tbApMaterno.Size = new System.Drawing.Size(262, 26);
            this.tbApMaterno.TabIndex = 20;
            // 
            // lblSituacion
            // 
            this.lblSituacion.AutoSize = true;
            this.lblSituacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSituacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.lblSituacion.Location = new System.Drawing.Point(39, 152);
            this.lblSituacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSituacion.Name = "lblSituacion";
            this.lblSituacion.Size = new System.Drawing.Size(78, 20);
            this.lblSituacion.TabIndex = 12;
            this.lblSituacion.Text = "Situación";
            // 
            // tbSituacion
            // 
            this.tbSituacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSituacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSituacion.Location = new System.Drawing.Point(155, 150);
            this.tbSituacion.Margin = new System.Windows.Forms.Padding(4);
            this.tbSituacion.Name = "tbSituacion";
            this.tbSituacion.ReadOnly = true;
            this.tbSituacion.Size = new System.Drawing.Size(262, 26);
            this.tbSituacion.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCodigo);
            this.panel1.Controls.Add(this.tbNombres);
            this.panel1.Controls.Add(this.lblNombres);
            this.panel1.Controls.Add(this.tbCodEscuela);
            this.panel1.Controls.Add(this.lblApPaterno);
            this.panel1.Controls.Add(this.tbSituacion);
            this.panel1.Controls.Add(this.tbCodigo);
            this.panel1.Controls.Add(this.lblCodEscuela);
            this.panel1.Controls.Add(this.lblApMaterno);
            this.panel1.Controls.Add(this.tbApMaterno);
            this.panel1.Controls.Add(this.tbApPaterno);
            this.panel1.Controls.Add(this.lblSituacion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 229);
            this.panel1.TabIndex = 23;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.cB_Tipo3);
            this.panel2.Controls.Add(this.cB_Tipo2);
            this.panel2.Controls.Add(this.cB_Tipo1);
            this.panel2.Controls.Add(this.dTP_Sesion3);
            this.panel2.Controls.Add(this.dTP_Sesion2);
            this.panel2.Controls.Add(this.dTP_Sesion1);
            this.panel2.Controls.Add(this.lblFecha3);
            this.panel2.Controls.Add(this.lblFecha2);
            this.panel2.Controls.Add(this.lblFecha1);
            this.panel2.Controls.Add(this.lblSesion2);
            this.panel2.Controls.Add(this.lblSesion3);
            this.panel2.Controls.Add(this.lblSesion1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 277);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 773);
            this.panel2.TabIndex = 24;
            // 
            // lblSesion1
            // 
            this.lblSesion1.AutoSize = true;
            this.lblSesion1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSesion1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.lblSesion1.Location = new System.Drawing.Point(39, 19);
            this.lblSesion1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSesion1.Name = "lblSesion1";
            this.lblSesion1.Size = new System.Drawing.Size(74, 20);
            this.lblSesion1.TabIndex = 16;
            this.lblSesion1.Text = "Sesión 1";
            // 
            // lblSesion3
            // 
            this.lblSesion3.AutoSize = true;
            this.lblSesion3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSesion3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.lblSesion3.Location = new System.Drawing.Point(39, 447);
            this.lblSesion3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSesion3.Name = "lblSesion3";
            this.lblSesion3.Size = new System.Drawing.Size(74, 20);
            this.lblSesion3.TabIndex = 17;
            this.lblSesion3.Text = "Sesión 3";
            // 
            // lblSesion2
            // 
            this.lblSesion2.AutoSize = true;
            this.lblSesion2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSesion2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.lblSesion2.Location = new System.Drawing.Point(39, 225);
            this.lblSesion2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSesion2.Name = "lblSesion2";
            this.lblSesion2.Size = new System.Drawing.Size(74, 20);
            this.lblSesion2.TabIndex = 18;
            this.lblSesion2.Text = "Sesión 2";
            // 
            // lblFecha1
            // 
            this.lblFecha1.AutoSize = true;
            this.lblFecha1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.lblFecha1.Location = new System.Drawing.Point(200, 19);
            this.lblFecha1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha1.Name = "lblFecha1";
            this.lblFecha1.Size = new System.Drawing.Size(116, 20);
            this.lblFecha1.TabIndex = 19;
            this.lblFecha1.Text = "Fecha y hora :";
            // 
            // lblFecha2
            // 
            this.lblFecha2.AutoSize = true;
            this.lblFecha2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.lblFecha2.Location = new System.Drawing.Point(200, 225);
            this.lblFecha2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha2.Name = "lblFecha2";
            this.lblFecha2.Size = new System.Drawing.Size(116, 20);
            this.lblFecha2.TabIndex = 20;
            this.lblFecha2.Text = "Fecha y hora :";
            // 
            // lblFecha3
            // 
            this.lblFecha3.AutoSize = true;
            this.lblFecha3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.lblFecha3.Location = new System.Drawing.Point(200, 447);
            this.lblFecha3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha3.Name = "lblFecha3";
            this.lblFecha3.Size = new System.Drawing.Size(116, 20);
            this.lblFecha3.TabIndex = 21;
            this.lblFecha3.Text = "Fecha y hora :";
            // 
            // dTP_Sesion1
            // 
            this.dTP_Sesion1.Location = new System.Drawing.Point(323, 19);
            this.dTP_Sesion1.Name = "dTP_Sesion1";
            this.dTP_Sesion1.Size = new System.Drawing.Size(81, 22);
            this.dTP_Sesion1.TabIndex = 22;
            // 
            // dTP_Sesion2
            // 
            this.dTP_Sesion2.Location = new System.Drawing.Point(323, 225);
            this.dTP_Sesion2.Name = "dTP_Sesion2";
            this.dTP_Sesion2.Size = new System.Drawing.Size(81, 22);
            this.dTP_Sesion2.TabIndex = 23;
            // 
            // dTP_Sesion3
            // 
            this.dTP_Sesion3.Location = new System.Drawing.Point(323, 447);
            this.dTP_Sesion3.Name = "dTP_Sesion3";
            this.dTP_Sesion3.Size = new System.Drawing.Size(81, 22);
            this.dTP_Sesion3.TabIndex = 24;
            // 
            // cB_Tipo1
            // 
            this.cB_Tipo1.FormattingEnabled = true;
            this.cB_Tipo1.Items.AddRange(new object[] {
            "Academico",
            "Personal",
            "Profesional"});
            this.cB_Tipo1.Location = new System.Drawing.Point(493, 19);
            this.cB_Tipo1.Name = "cB_Tipo1";
            this.cB_Tipo1.Size = new System.Drawing.Size(97, 24);
            this.cB_Tipo1.TabIndex = 25;
            this.cB_Tipo1.Text = "Tipo";
            // 
            // cB_Tipo2
            // 
            this.cB_Tipo2.FormattingEnabled = true;
            this.cB_Tipo2.Items.AddRange(new object[] {
            "Academico",
            "Personal",
            "Profesional"});
            this.cB_Tipo2.Location = new System.Drawing.Point(493, 225);
            this.cB_Tipo2.Name = "cB_Tipo2";
            this.cB_Tipo2.Size = new System.Drawing.Size(97, 24);
            this.cB_Tipo2.TabIndex = 26;
            this.cB_Tipo2.Text = "Tipo";
            // 
            // cB_Tipo3
            // 
            this.cB_Tipo3.FormattingEnabled = true;
            this.cB_Tipo3.Items.AddRange(new object[] {
            "Academico",
            "Personal",
            "Profesional"});
            this.cB_Tipo3.Location = new System.Drawing.Point(493, 449);
            this.cB_Tipo3.Name = "cB_Tipo3";
            this.cB_Tipo3.Size = new System.Drawing.Size(97, 24);
            this.cB_Tipo3.TabIndex = 27;
            this.cB_Tipo3.Text = "Tipo";
            // 
            // FormFichaTutoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 1050);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormFichaTutoria";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormFichaTutoria";
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNombres;
        private System.Windows.Forms.TextBox tbCodEscuela;
        private System.Windows.Forms.Label lblCodEscuela;
        private System.Windows.Forms.TextBox tbApPaterno;
        private System.Windows.Forms.TextBox tbCodigo;
        private System.Windows.Forms.Label lblApPaterno;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblApMaterno;
        private System.Windows.Forms.TextBox tbApMaterno;
        private System.Windows.Forms.Label lblSituacion;
        private System.Windows.Forms.TextBox tbSituacion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblFecha3;
        private System.Windows.Forms.Label lblFecha2;
        private System.Windows.Forms.Label lblFecha1;
        private System.Windows.Forms.Label lblSesion2;
        private System.Windows.Forms.Label lblSesion3;
        private System.Windows.Forms.Label lblSesion1;
        private System.Windows.Forms.DateTimePicker dTP_Sesion1;
        private System.Windows.Forms.DateTimePicker dTP_Sesion3;
        private System.Windows.Forms.DateTimePicker dTP_Sesion2;
        private System.Windows.Forms.ComboBox cB_Tipo3;
        private System.Windows.Forms.ComboBox cB_Tipo2;
        private System.Windows.Forms.ComboBox cB_Tipo1;
    }
}