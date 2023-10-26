namespace Interfaz
{
    partial class CategoriasGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoriasGUI));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabIndex = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.grillaCategorias = new System.Windows.Forms.DataGridView();
            this.nombreCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transaccionesCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalGastado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.presupuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mesPresupuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Añadir = new System.Windows.Forms.TabPage();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.btnAñadir = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPresupuestoAñadir = new System.Windows.Forms.TextBox();
            this.txtNombreAñadir = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cbMesEditar = new System.Windows.Forms.ComboBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPresupuestoEditar = new System.Windows.Forms.TextBox();
            this.txtNombreEditar = new System.Windows.Forms.TextBox();
            this.lblMes = new System.Windows.Forms.Label();
            this.lblPresupuesto = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNombreEliminar = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabIndex.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaCategorias)).BeginInit();
            this.Añadir.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(10)))), ((int)(((byte)(48)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(138, 467);
            this.panel1.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button5);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 119);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(138, 331);
            this.panel3.TabIndex = 4;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(10)))), ((int)(((byte)(48)))));
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(0, 244);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(138, 45);
            this.button5.TabIndex = 6;
            this.button5.Text = "Salir";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(10)))), ((int)(((byte)(48)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(0, 188);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(135, 45);
            this.button4.TabIndex = 4;
            this.button4.Text = "Informes y Graficos";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(10)))), ((int)(((byte)(48)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 45);
            this.button1.TabIndex = 1;
            this.button1.Text = "Inicio";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(10)))), ((int)(((byte)(48)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(0, 137);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(138, 45);
            this.button3.TabIndex = 3;
            this.button3.Text = "Categorias";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(10)))), ((int)(((byte)(48)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(0, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 45);
            this.button2.TabIndex = 2;
            this.button2.Text = "Transacciones";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(138, 119);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Interfaz.Properties.Resources.Logo___copia;
            this.pictureBox1.Location = new System.Drawing.Point(12, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(111, 113);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabIndex
            // 
            this.tabIndex.Controls.Add(this.tabPage1);
            this.tabIndex.Controls.Add(this.Añadir);
            this.tabIndex.Controls.Add(this.tabPage3);
            this.tabIndex.Controls.Add(this.tabPage2);
            this.tabIndex.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Bold);
            this.tabIndex.Location = new System.Drawing.Point(144, 12);
            this.tabIndex.Name = "tabIndex";
            this.tabIndex.SelectedIndex = 0;
            this.tabIndex.Size = new System.Drawing.Size(646, 449);
            this.tabIndex.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(10)))), ((int)(((byte)(48)))));
            this.tabPage1.Controls.Add(this.panel5);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(638, 423);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Categorias";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label1);
            this.panel5.Location = new System.Drawing.Point(42, 24);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(553, 46);
            this.panel5.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(150, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "Categorias Registradas";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.grillaCategorias);
            this.panel4.Location = new System.Drawing.Point(42, 85);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(554, 329);
            this.panel4.TabIndex = 13;
            // 
            // grillaCategorias
            // 
            this.grillaCategorias.BackgroundColor = System.Drawing.Color.White;
            this.grillaCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaCategorias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreCategoria,
            this.transaccionesCategoria,
            this.totalGastado,
            this.presupuesto,
            this.mesPresupuesto});
            this.grillaCategorias.Location = new System.Drawing.Point(4, 3);
            this.grillaCategorias.Name = "grillaCategorias";
            this.grillaCategorias.RowHeadersWidth = 51;
            this.grillaCategorias.Size = new System.Drawing.Size(547, 326);
            this.grillaCategorias.TabIndex = 10;
            // 
            // nombreCategoria
            // 
            this.nombreCategoria.HeaderText = "Categoria";
            this.nombreCategoria.MinimumWidth = 6;
            this.nombreCategoria.Name = "nombreCategoria";
            this.nombreCategoria.Width = 125;
            // 
            // transaccionesCategoria
            // 
            this.transaccionesCategoria.HeaderText = "Transacciones";
            this.transaccionesCategoria.MinimumWidth = 6;
            this.transaccionesCategoria.Name = "transaccionesCategoria";
            this.transaccionesCategoria.Width = 125;
            // 
            // totalGastado
            // 
            this.totalGastado.HeaderText = "Total Gastado";
            this.totalGastado.MinimumWidth = 6;
            this.totalGastado.Name = "totalGastado";
            this.totalGastado.Width = 125;
            // 
            // presupuesto
            // 
            this.presupuesto.HeaderText = "Presupuesto";
            this.presupuesto.MinimumWidth = 6;
            this.presupuesto.Name = "presupuesto";
            this.presupuesto.Width = 125;
            // 
            // mesPresupuesto
            // 
            this.mesPresupuesto.HeaderText = "Mes";
            this.mesPresupuesto.MinimumWidth = 6;
            this.mesPresupuesto.Name = "mesPresupuesto";
            this.mesPresupuesto.Width = 125;
            // 
            // Añadir
            // 
            this.Añadir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(10)))), ((int)(((byte)(48)))));
            this.Añadir.Controls.Add(this.cbMes);
            this.Añadir.Controls.Add(this.btnAñadir);
            this.Añadir.Controls.Add(this.label8);
            this.Añadir.Controls.Add(this.txtPresupuestoAñadir);
            this.Añadir.Controls.Add(this.txtNombreAñadir);
            this.Añadir.Controls.Add(this.label4);
            this.Añadir.Controls.Add(this.label3);
            this.Añadir.Controls.Add(this.label2);
            this.Añadir.Location = new System.Drawing.Point(4, 22);
            this.Añadir.Name = "Añadir";
            this.Añadir.Padding = new System.Windows.Forms.Padding(3);
            this.Añadir.Size = new System.Drawing.Size(638, 423);
            this.Añadir.TabIndex = 1;
            this.Añadir.Text = "Añadir";
            // 
            // cbMes
            // 
            this.cbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.cbMes.Location = new System.Drawing.Point(319, 169);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(124, 21);
            this.cbMes.TabIndex = 13;
            this.cbMes.SelectedIndexChanged += new System.EventHandler(this.cbMes_SelectedIndexChanged);
            // 
            // btnAñadir
            // 
            this.btnAñadir.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnAñadir.Location = new System.Drawing.Point(284, 231);
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.Size = new System.Drawing.Size(75, 23);
            this.btnAñadir.TabIndex = 12;
            this.btnAñadir.Text = "Añadir";
            this.btnAñadir.UseVisualStyleBackColor = true;
            this.btnAñadir.Click += new System.EventHandler(this.btnAñadir_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(226, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(188, 25);
            this.label8.TabIndex = 11;
            this.label8.Text = "Añadir categoria";
            // 
            // txtPresupuestoAñadir
            // 
            this.txtPresupuestoAñadir.Location = new System.Drawing.Point(319, 139);
            this.txtPresupuestoAñadir.Name = "txtPresupuestoAñadir";
            this.txtPresupuestoAñadir.Size = new System.Drawing.Size(124, 20);
            this.txtPresupuestoAñadir.TabIndex = 4;
            // 
            // txtNombreAñadir
            // 
            this.txtNombreAñadir.Location = new System.Drawing.Point(319, 104);
            this.txtNombreAñadir.Name = "txtNombreAñadir";
            this.txtNombreAñadir.Size = new System.Drawing.Size(124, 20);
            this.txtNombreAñadir.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(282, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(234, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Presupuesto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(168, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre de la categoria:";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(10)))), ((int)(((byte)(48)))));
            this.tabPage3.Controls.Add(this.cbMesEditar);
            this.tabPage3.Controls.Add(this.btnActualizar);
            this.tabPage3.Controls.Add(this.btnBuscar);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.txtPresupuestoEditar);
            this.tabPage3.Controls.Add(this.txtNombreEditar);
            this.tabPage3.Controls.Add(this.lblMes);
            this.tabPage3.Controls.Add(this.lblPresupuesto);
            this.tabPage3.Controls.Add(this.lblNombre);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(638, 423);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Editar";
            // 
            // cbMesEditar
            // 
            this.cbMesEditar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMesEditar.FormattingEnabled = true;
            this.cbMesEditar.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.cbMesEditar.Location = new System.Drawing.Point(341, 177);
            this.cbMesEditar.Name = "cbMesEditar";
            this.cbMesEditar.Size = new System.Drawing.Size(124, 21);
            this.cbMesEditar.TabIndex = 22;
            this.cbMesEditar.Visible = false;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Enabled = false;
            this.btnActualizar.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.Location = new System.Drawing.Point(348, 244);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 21;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.Location = new System.Drawing.Point(244, 244);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 20;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(227, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 25);
            this.label5.TabIndex = 19;
            this.label5.Text = "Editar categoria";
            // 
            // txtPresupuestoEditar
            // 
            this.txtPresupuestoEditar.Location = new System.Drawing.Point(341, 142);
            this.txtPresupuestoEditar.Name = "txtPresupuestoEditar";
            this.txtPresupuestoEditar.Size = new System.Drawing.Size(124, 20);
            this.txtPresupuestoEditar.TabIndex = 17;
            this.txtPresupuestoEditar.Visible = false;
            // 
            // txtNombreEditar
            // 
            this.txtNombreEditar.Location = new System.Drawing.Point(341, 104);
            this.txtNombreEditar.Name = "txtNombreEditar";
            this.txtNombreEditar.Size = new System.Drawing.Size(124, 20);
            this.txtNombreEditar.TabIndex = 16;
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblMes.ForeColor = System.Drawing.SystemColors.Control;
            this.lblMes.Location = new System.Drawing.Point(296, 180);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(31, 15);
            this.lblMes.TabIndex = 15;
            this.lblMes.Text = "Mes:";
            this.lblMes.Visible = false;
            // 
            // lblPresupuesto
            // 
            this.lblPresupuesto.AutoSize = true;
            this.lblPresupuesto.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblPresupuesto.ForeColor = System.Drawing.SystemColors.Control;
            this.lblPresupuesto.Location = new System.Drawing.Point(248, 144);
            this.lblPresupuesto.Name = "lblPresupuesto";
            this.lblPresupuesto.Size = new System.Drawing.Size(79, 15);
            this.lblPresupuesto.TabIndex = 14;
            this.lblPresupuesto.Text = "Presupuesto:";
            this.lblPresupuesto.Visible = false;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.SystemColors.Control;
            this.lblNombre.Location = new System.Drawing.Point(122, 108);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(205, 15);
            this.lblNombre.TabIndex = 13;
            this.lblNombre.Text = "Digite el nombre de la categoria:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(10)))), ((int)(((byte)(48)))));
            this.tabPage2.Controls.Add(this.btnEliminar);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.txtNombreEliminar);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(638, 423);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Eliminar";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.Location = new System.Drawing.Point(262, 183);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 30;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(215, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(210, 25);
            this.label10.TabIndex = 28;
            this.label10.Text = "Eliminar categoria";
            // 
            // txtNombreEliminar
            // 
            this.txtNombreEliminar.Location = new System.Drawing.Point(329, 110);
            this.txtNombreEliminar.Name = "txtNombreEliminar";
            this.txtNombreEliminar.Size = new System.Drawing.Size(124, 20);
            this.txtNombreEliminar.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.Control;
            this.label13.Location = new System.Drawing.Point(116, 114);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(205, 15);
            this.label13.TabIndex = 22;
            this.label13.Text = "Digite el nombre de la categoria:";
            // 
            // CategoriasGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 467);
            this.Controls.Add(this.tabIndex);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CategoriasGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CategoriasGUI";
            this.Load += new System.EventHandler(this.Categorias_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabIndex.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grillaCategorias)).EndInit();
            this.Añadir.ResumeLayout(false);
            this.Añadir.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabIndex;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView grillaCategorias;
        private System.Windows.Forms.TabPage Añadir;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn transaccionesCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalGastado;
        private System.Windows.Forms.DataGridViewTextBoxColumn presupuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn mesPresupuesto;
        private System.Windows.Forms.Button btnAñadir;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPresupuestoAñadir;
        private System.Windows.Forms.TextBox txtNombreAñadir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPresupuestoEditar;
        private System.Windows.Forms.TextBox txtNombreEditar;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.Label lblPresupuesto;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNombreEliminar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.ComboBox cbMesEditar;
    }
}