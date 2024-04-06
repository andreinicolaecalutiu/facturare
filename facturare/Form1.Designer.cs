namespace facturare
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
            lblDescription = new Label();
            lblPrice = new Label();
            txtDescription = new TextBox();
            txtPrice = new TextBox();
            btnAddItem = new Button();
            lblSubtotal = new Label();
            txtSubtotal = new TextBox();
            btnGenerate = new Button();
            lblTotal = new Label();
            txtTotal = new TextBox();
            lblNumeClient = new Label();
            txtNumeClient = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblTaxRate = new Label();
            txtTaxRate = new TextBox();
            SuspendLayout();
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(58, 185);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(117, 30);
            lblDescription.TabIndex = 0;
            lblDescription.Text = "DESCRIERE";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(58, 235);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(60, 30);
            lblPrice.TabIndex = 1;
            lblPrice.Text = "PREȚ";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(226, 180);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(642, 35);
            txtDescription.TabIndex = 2;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(226, 230);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(642, 35);
            txtPrice.TabIndex = 3;
            // 
            // btnAddItem
            // 
            btnAddItem.Location = new Point(58, 293);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(810, 85);
            btnAddItem.TabIndex = 4;
            btnAddItem.Text = "ADAUGĂ";
            btnAddItem.UseVisualStyleBackColor = true;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Location = new Point(58, 412);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(108, 30);
            lblSubtotal.TabIndex = 5;
            lblSubtotal.Text = "SUBTOTAL";
            // 
            // txtSubtotal
            // 
            txtSubtotal.Location = new Point(226, 407);
            txtSubtotal.Name = "txtSubtotal";
            txtSubtotal.Size = new Size(392, 35);
            txtSubtotal.TabIndex = 6;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(58, 600);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(810, 85);
            btnGenerate.TabIndex = 7;
            btnGenerate.Text = "GENEREAZĂ";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnSave_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(58, 471);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(72, 30);
            lblTotal.TabIndex = 8;
            lblTotal.Text = "TOTAL";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(226, 466);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(392, 35);
            txtTotal.TabIndex = 9;
            // 
            // lblNumeClient
            // 
            lblNumeClient.AutoSize = true;
            lblNumeClient.Location = new Point(58, 58);
            lblNumeClient.Name = "lblNumeClient";
            lblNumeClient.Size = new Size(146, 30);
            lblNumeClient.TabIndex = 10;
            lblNumeClient.Text = "NUME CLIENT";
            // 
            // txtNumeClient
            // 
            txtNumeClient.Location = new Point(226, 53);
            txtNumeClient.Name = "txtNumeClient";
            txtNumeClient.Size = new Size(642, 35);
            txtNumeClient.TabIndex = 11;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(58, 106);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(98, 30);
            lblPhone.TabIndex = 12;
            lblPhone.Text = "TELEFON";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(226, 101);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(642, 35);
            txtPhone.TabIndex = 13;
            // 
            // lblTaxRate
            // 
            lblTaxRate.AutoSize = true;
            lblTaxRate.Location = new Point(58, 536);
            lblTaxRate.Name = "lblTaxRate";
            lblTaxRate.Size = new Size(49, 30);
            lblTaxRate.TabIndex = 14;
            lblTaxRate.Text = "TAX";
            // 
            // txtTaxRate
            // 
            txtTaxRate.Location = new Point(226, 531);
            txtTaxRate.Name = "txtTaxRate";
            txtTaxRate.Size = new Size(392, 35);
            txtTaxRate.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(927, 697);
            Controls.Add(txtTaxRate);
            Controls.Add(lblTaxRate);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Controls.Add(txtNumeClient);
            Controls.Add(lblNumeClient);
            Controls.Add(txtTotal);
            Controls.Add(lblTotal);
            Controls.Add(btnGenerate);
            Controls.Add(txtSubtotal);
            Controls.Add(lblSubtotal);
            Controls.Add(btnAddItem);
            Controls.Add(txtPrice);
            Controls.Add(txtDescription);
            Controls.Add(lblPrice);
            Controls.Add(lblDescription);
            Name = "Form1";
            Text = "APLICAȚIE FACTURARE";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDescription;
        private Label lblPrice;
        private TextBox txtDescription;
        private TextBox txtPrice;
        private Button btnAddItem;
        private Label lblSubtotal;
        private TextBox txtSubtotal;
        private Button btnGenerate;
        private Label lblTotal;
        private TextBox txtTotal;
        private Label lblNumeClient;
        private TextBox txtNumeClient;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblTaxRate;
        private TextBox txtTaxRate;
    }
}
