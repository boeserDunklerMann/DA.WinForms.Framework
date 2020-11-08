namespace DA.WinForms.Framework.Test
{
	partial class BookForm
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
			this.gbBook = new System.Windows.Forms.GroupBox();
			this.lbCat = new System.Windows.Forms.Label();
			this.cbCategory = new System.Windows.Forms.ComboBox();
			this.cbHardcover = new System.Windows.Forms.CheckBox();
			this.btnHitme = new System.Windows.Forms.Button();
			this.lbPrice = new System.Windows.Forms.Label();
			this.txtPrice = new System.Windows.Forms.TextBox();
			this.lbAuthor = new System.Windows.Forms.Label();
			this.lbName = new System.Windows.Forms.Label();
			this.txtAuthor = new System.Windows.Forms.TextBox();
			this.txtTitle = new System.Windows.Forms.TextBox();
			this.dgvBooks = new System.Windows.Forms.DataGridView();
			this.lbBooks = new System.Windows.Forms.Label();
			this.gbBook.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
			this.SuspendLayout();
			// 
			// gbBook
			// 
			this.gbBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.gbBook.Controls.Add(this.lbCat);
			this.gbBook.Controls.Add(this.cbCategory);
			this.gbBook.Controls.Add(this.cbHardcover);
			this.gbBook.Controls.Add(this.btnHitme);
			this.gbBook.Controls.Add(this.lbPrice);
			this.gbBook.Controls.Add(this.txtPrice);
			this.gbBook.Controls.Add(this.lbAuthor);
			this.gbBook.Controls.Add(this.lbName);
			this.gbBook.Controls.Add(this.txtAuthor);
			this.gbBook.Controls.Add(this.txtTitle);
			this.gbBook.Location = new System.Drawing.Point(258, 12);
			this.gbBook.Name = "gbBook";
			this.gbBook.Size = new System.Drawing.Size(268, 212);
			this.gbBook.TabIndex = 0;
			this.gbBook.TabStop = false;
			this.gbBook.Text = "Book";
			// 
			// lbCat
			// 
			this.lbCat.AutoSize = true;
			this.lbCat.Location = new System.Drawing.Point(22, 151);
			this.lbCat.Name = "lbCat";
			this.lbCat.Size = new System.Drawing.Size(55, 15);
			this.lbCat.TabIndex = 9;
			this.lbCat.Text = "Category";
			// 
			// cbCategory
			// 
			this.cbCategory.FormattingEnabled = true;
			this.cbCategory.Location = new System.Drawing.Point(82, 148);
			this.cbCategory.Name = "cbCategory";
			this.cbCategory.Size = new System.Drawing.Size(121, 23);
			this.cbCategory.TabIndex = 8;
			// 
			// cbHardcover
			// 
			this.cbHardcover.AutoSize = true;
			this.cbHardcover.Location = new System.Drawing.Point(82, 122);
			this.cbHardcover.Name = "cbHardcover";
			this.cbHardcover.Size = new System.Drawing.Size(86, 19);
			this.cbHardcover.TabIndex = 7;
			this.cbHardcover.Text = "Hardcover?";
			this.cbHardcover.UseVisualStyleBackColor = true;
			// 
			// btnHitme
			// 
			this.btnHitme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnHitme.Location = new System.Drawing.Point(6, 183);
			this.btnHitme.Name = "btnHitme";
			this.btnHitme.Size = new System.Drawing.Size(256, 23);
			this.btnHitme.TabIndex = 6;
			this.btnHitme.Text = "do same changes and hit me!";
			this.btnHitme.UseVisualStyleBackColor = true;
			this.btnHitme.Click += new System.EventHandler(this.btnHitme_Click);
			// 
			// lbPrice
			// 
			this.lbPrice.AutoSize = true;
			this.lbPrice.Location = new System.Drawing.Point(22, 95);
			this.lbPrice.Name = "lbPrice";
			this.lbPrice.Size = new System.Drawing.Size(33, 15);
			this.lbPrice.TabIndex = 5;
			this.lbPrice.Text = "Price";
			// 
			// txtPrice
			// 
			this.txtPrice.Location = new System.Drawing.Point(82, 92);
			this.txtPrice.Name = "txtPrice";
			this.txtPrice.Size = new System.Drawing.Size(100, 23);
			this.txtPrice.TabIndex = 4;
			// 
			// lbAuthor
			// 
			this.lbAuthor.AutoSize = true;
			this.lbAuthor.Location = new System.Drawing.Point(22, 65);
			this.lbAuthor.Name = "lbAuthor";
			this.lbAuthor.Size = new System.Drawing.Size(44, 15);
			this.lbAuthor.TabIndex = 3;
			this.lbAuthor.Text = "Author";
			// 
			// lbName
			// 
			this.lbName.AutoSize = true;
			this.lbName.Location = new System.Drawing.Point(22, 35);
			this.lbName.Name = "lbName";
			this.lbName.Size = new System.Drawing.Size(30, 15);
			this.lbName.TabIndex = 2;
			this.lbName.Text = "Title";
			// 
			// txtAuthor
			// 
			this.txtAuthor.Location = new System.Drawing.Point(82, 62);
			this.txtAuthor.Name = "txtAuthor";
			this.txtAuthor.Size = new System.Drawing.Size(100, 23);
			this.txtAuthor.TabIndex = 1;
			// 
			// txtTitle
			// 
			this.txtTitle.Location = new System.Drawing.Point(82, 32);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(100, 23);
			this.txtTitle.TabIndex = 0;
			// 
			// dgvBooks
			// 
			this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvBooks.Location = new System.Drawing.Point(12, 29);
			this.dgvBooks.Name = "dgvBooks";
			this.dgvBooks.Size = new System.Drawing.Size(240, 150);
			this.dgvBooks.TabIndex = 1;
			this.dgvBooks.Text = "dataGridView1";
			this.dgvBooks.Click += new System.EventHandler(this.dgvBooks_Click);
			// 
			// lbBooks
			// 
			this.lbBooks.AutoSize = true;
			this.lbBooks.Location = new System.Drawing.Point(12, 11);
			this.lbBooks.Name = "lbBooks";
			this.lbBooks.Size = new System.Drawing.Size(60, 15);
			this.lbBooks.TabIndex = 2;
			this.lbBooks.Text = "Bookstore";
			// 
			// BookForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(545, 233);
			this.Controls.Add(this.lbBooks);
			this.Controls.Add(this.dgvBooks);
			this.Controls.Add(this.gbBook);
			this.Name = "BookForm";
			this.Text = "Books";
			this.gbBook.ResumeLayout(false);
			this.gbBook.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox gbBook;
		private System.Windows.Forms.Label lbAuthor;
		private System.Windows.Forms.Label lbName;
		private System.Windows.Forms.TextBox txtAuthor;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.Label lbPrice;
		private System.Windows.Forms.TextBox txtPrice;
		private System.Windows.Forms.Button btnHitme;
		private System.Windows.Forms.CheckBox cbHardcover;
		private System.Windows.Forms.Label lbCat;
		private System.Windows.Forms.ComboBox cbCategory;
		private System.Windows.Forms.DataGridView dgvBooks;
		private System.Windows.Forms.Label lbBooks;
	}
}

