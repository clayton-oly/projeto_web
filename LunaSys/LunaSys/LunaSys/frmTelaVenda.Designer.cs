namespace WindowsFormsApp1
{
    partial class frmTelaVenda
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
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.btnSair = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNomeCli = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtVendedor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnVenda = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.lbItens = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.lbVenda = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtVlrTotal = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigoProduto = new System.Windows.Forms.TextBox();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvVendas = new System.Windows.Forms.DataGridView();
            this.txtQuant = new System.Windows.Forms.TextBox();
            this.txtValorUnitario = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEstoque = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.BarraTitulo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).BeginInit();
            this.SuspendLayout();
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BarraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.BarraTitulo.Controls.Add(this.btnSair);
            this.BarraTitulo.Controls.Add(this.label6);
            this.BarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(857, 38);
            this.BarraTitulo.TabIndex = 60;
            // 
            // btnSair
            // 
            this.btnSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Image = global::WindowsFormsApp1.Properties.Resources.Close1;
            this.btnSair.Location = new System.Drawing.Point(819, 0);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(38, 38);
            this.btnSair.TabIndex = 0;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(380, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Tela de Vendas";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.txtNomeCli);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtCliente);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtVendedor);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 45);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(832, 64);
            this.groupBox2.TabIndex = 61;
            this.groupBox2.TabStop = false;
            // 
            // txtNomeCli
            // 
            this.txtNomeCli.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNomeCli.Location = new System.Drawing.Point(196, 31);
            this.txtNomeCli.Margin = new System.Windows.Forms.Padding(4);
            this.txtNomeCli.Name = "txtNomeCli";
            this.txtNomeCli.ReadOnly = true;
            this.txtNomeCli.Size = new System.Drawing.Size(310, 20);
            this.txtNomeCli.TabIndex = 1;
            this.txtNomeCli.TabStop = false;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(193, 14);
            this.label17.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 13);
            this.label17.TabIndex = 33;
            this.label17.Text = "Nome do Cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCliente.Location = new System.Drawing.Point(8, 31);
            this.txtCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtCliente.MaxLength = 14;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(180, 20);
            this.txtCliente.TabIndex = 0;
            this.txtCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCliente_KeyPress);
            this.txtCliente.Validating += new System.ComponentModel.CancelEventHandler(this.txtCliente_Validating);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 14);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "CPF do Cliente";
            // 
            // txtVendedor
            // 
            this.txtVendedor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtVendedor.Location = new System.Drawing.Point(514, 31);
            this.txtVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.ReadOnly = true;
            this.txtVendedor.Size = new System.Drawing.Size(310, 20);
            this.txtVendedor.TabIndex = 4;
            this.txtVendedor.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(511, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vendedor";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.btnVenda);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.btnAdicionar);
            this.groupBox1.Controls.Add(this.lbItens);
            this.groupBox1.Controls.Add(this.lbCodigo);
            this.groupBox1.Controls.Add(this.lbVenda);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtVlrTotal);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCodigoProduto);
            this.groupBox1.Controls.Add(this.txtProduto);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dgvVendas);
            this.groupBox1.Controls.Add(this.txtQuant);
            this.groupBox1.Controls.Add(this.txtValorUnitario);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtEstoque);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(12, 108);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(832, 361);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            // 
            // btnVenda
            // 
            this.btnVenda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnVenda.FlatAppearance.BorderSize = 0;
            this.btnVenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVenda.ForeColor = System.Drawing.Color.White;
            this.btnVenda.Location = new System.Drawing.Point(740, 326);
            this.btnVenda.Name = "btnVenda";
            this.btnVenda.Size = new System.Drawing.Size(81, 28);
            this.btnVenda.TabIndex = 58;
            this.btnVenda.Text = "Confirmar";
            this.btnVenda.UseVisualStyleBackColor = false;
            this.btnVenda.Click += new System.EventHandler(this.btnVenda_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Location = new System.Drawing.Point(653, 326);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(81, 28);
            this.btnRemove.TabIndex = 57;
            this.btnRemove.Text = "Remover -";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdicionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(151)))), ((int)(((byte)(217)))));
            this.btnAdicionar.FlatAppearance.BorderSize = 0;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionar.ForeColor = System.Drawing.Color.White;
            this.btnAdicionar.Location = new System.Drawing.Point(566, 326);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(81, 28);
            this.btnAdicionar.TabIndex = 56;
            this.btnAdicionar.Text = "Adicionar +";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // lbItens
            // 
            this.lbItens.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbItens.AutoSize = true;
            this.lbItens.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbItens.ForeColor = System.Drawing.Color.Red;
            this.lbItens.Location = new System.Drawing.Point(63, 321);
            this.lbItens.Name = "lbItens";
            this.lbItens.Size = new System.Drawing.Size(19, 20);
            this.lbItens.TabIndex = 55;
            this.lbItens.Text = "0";
            // 
            // lbCodigo
            // 
            this.lbCodigo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 33F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCodigo.ForeColor = System.Drawing.Color.Red;
            this.lbCodigo.Location = new System.Drawing.Point(34, 18);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(48, 52);
            this.lbCodigo.TabIndex = 36;
            this.lbCodigo.Text = "0";
            // 
            // lbVenda
            // 
            this.lbVenda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbVenda.AutoSize = true;
            this.lbVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVenda.ForeColor = System.Drawing.Color.Red;
            this.lbVenda.Location = new System.Drawing.Point(433, 321);
            this.lbVenda.Name = "lbVenda";
            this.lbVenda.Size = new System.Drawing.Size(19, 20);
            this.lbVenda.TabIndex = 54;
            this.lbVenda.Text = "0";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(213, 30);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 13);
            this.label16.TabIndex = 53;
            this.label16.Text = "Nome Produto";
            // 
            // txtVlrTotal
            // 
            this.txtVlrTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtVlrTotal.Location = new System.Drawing.Point(613, 46);
            this.txtVlrTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtVlrTotal.Name = "txtVlrTotal";
            this.txtVlrTotal.ReadOnly = true;
            this.txtVlrTotal.Size = new System.Drawing.Size(100, 20);
            this.txtVlrTotal.TabIndex = 52;
            this.txtVlrTotal.TabStop = false;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(610, 29);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 51;
            this.label14.Text = "Valor Total";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 326);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Itens:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(341, 326);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Total da Venda:";
            // 
            // txtCodigoProduto
            // 
            this.txtCodigoProduto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCodigoProduto.Location = new System.Drawing.Point(108, 46);
            this.txtCodigoProduto.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoProduto.MaxLength = 5;
            this.txtCodigoProduto.Name = "txtCodigoProduto";
            this.txtCodigoProduto.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoProduto.TabIndex = 0;
            this.txtCodigoProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProduto_KeyPress);
            this.txtCodigoProduto.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdPedido_Validating);
            // 
            // txtProduto
            // 
            this.txtProduto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtProduto.Location = new System.Drawing.Point(216, 46);
            this.txtProduto.Margin = new System.Windows.Forms.Padding(4);
            this.txtProduto.MaxLength = 100;
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.Size = new System.Drawing.Size(173, 20);
            this.txtProduto.TabIndex = 1;
            this.txtProduto.TextChanged += new System.EventHandler(this.txtProduto_TextChanged);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(394, 29);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Quantidade";
            // 
            // dgvVendas
            // 
            this.dgvVendas.AllowUserToAddRows = false;
            this.dgvVendas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvVendas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVendas.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendas.Location = new System.Drawing.Point(8, 78);
            this.dgvVendas.Margin = new System.Windows.Forms.Padding(6);
            this.dgvVendas.Name = "dgvVendas";
            this.dgvVendas.ReadOnly = true;
            this.dgvVendas.RowHeadersVisible = false;
            this.dgvVendas.RowTemplate.Height = 24;
            this.dgvVendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVendas.Size = new System.Drawing.Size(813, 237);
            this.dgvVendas.TabIndex = 3;
            // 
            // txtQuant
            // 
            this.txtQuant.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtQuant.Location = new System.Drawing.Point(397, 47);
            this.txtQuant.Margin = new System.Windows.Forms.Padding(4);
            this.txtQuant.MaxLength = 4;
            this.txtQuant.Name = "txtQuant";
            this.txtQuant.Size = new System.Drawing.Size(100, 20);
            this.txtQuant.TabIndex = 2;
            this.txtQuant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuant_KeyPress);
            this.txtQuant.Validating += new System.ComponentModel.CancelEventHandler(this.txtQuant_Validating);
            // 
            // txtValorUnitario
            // 
            this.txtValorUnitario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtValorUnitario.Location = new System.Drawing.Point(505, 47);
            this.txtValorUnitario.Margin = new System.Windows.Forms.Padding(4);
            this.txtValorUnitario.Name = "txtValorUnitario";
            this.txtValorUnitario.ReadOnly = true;
            this.txtValorUnitario.Size = new System.Drawing.Size(100, 20);
            this.txtValorUnitario.TabIndex = 34;
            this.txtValorUnitario.TabStop = false;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(718, 29);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 13);
            this.label13.TabIndex = 33;
            this.label13.Text = "Estoque";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(107, 30);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Código Produto";
            // 
            // txtEstoque
            // 
            this.txtEstoque.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEstoque.Location = new System.Drawing.Point(721, 46);
            this.txtEstoque.Margin = new System.Windows.Forms.Padding(4);
            this.txtEstoque.Name = "txtEstoque";
            this.txtEstoque.ReadOnly = true;
            this.txtEstoque.Size = new System.Drawing.Size(100, 20);
            this.txtEstoque.TabIndex = 32;
            this.txtEstoque.TabStop = false;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(502, 30);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Valor Unitario";
            // 
            // frmTelaVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(857, 491);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BarraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTelaVenda";
            this.Text = "frmTelaVenda";
            this.Load += new System.EventHandler(this.frmTelaVenda_Load);
            this.BarraTitulo.ResumeLayout(false);
            this.BarraTitulo.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BarraTitulo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtVendedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtVlrTotal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodigoProduto;
        private System.Windows.Forms.TextBox txtProduto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvVendas;
        private System.Windows.Forms.TextBox txtQuant;
        private System.Windows.Forms.TextBox txtValorUnitario;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEstoque;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lbVenda;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtNomeCli;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.Label lbItens;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnVenda;
    }
}