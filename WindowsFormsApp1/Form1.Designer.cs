namespace WindowsFormsApp1
{
	partial class frmExecutando
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExecutando));
			this.pctGif = new System.Windows.Forms.PictureBox();
			this.btnParar = new System.Windows.Forms.Button();
			this.btnInicio = new System.Windows.Forms.Button();
			this.lblConfiguracao = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pctGif)).BeginInit();
			this.SuspendLayout();
			// 
			// pctGif
			// 
			this.pctGif.Image = ((System.Drawing.Image)(resources.GetObject("pctGif.Image")));
			this.pctGif.Location = new System.Drawing.Point(12, 12);
			this.pctGif.Name = "pctGif";
			this.pctGif.Size = new System.Drawing.Size(312, 303);
			this.pctGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pctGif.TabIndex = 0;
			this.pctGif.TabStop = false;
			// 
			// btnParar
			// 
			this.btnParar.Location = new System.Drawing.Point(168, 323);
			this.btnParar.Name = "btnParar";
			this.btnParar.Size = new System.Drawing.Size(75, 23);
			this.btnParar.TabIndex = 1;
			this.btnParar.Text = "&Parar";
			this.btnParar.UseVisualStyleBackColor = true;
			this.btnParar.Click += new System.EventHandler(this.btnParar_Click);
			// 
			// btnInicio
			// 
			this.btnInicio.Location = new System.Drawing.Point(249, 323);
			this.btnInicio.Name = "btnInicio";
			this.btnInicio.Size = new System.Drawing.Size(75, 23);
			this.btnInicio.TabIndex = 2;
			this.btnInicio.Text = "Início";
			this.btnInicio.UseVisualStyleBackColor = true;
			this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
			// 
			// lblConfiguracao
			// 
			this.lblConfiguracao.AutoSize = true;
			this.lblConfiguracao.Location = new System.Drawing.Point(12, 328);
			this.lblConfiguracao.Name = "lblConfiguracao";
			this.lblConfiguracao.Size = new System.Drawing.Size(0, 13);
			this.lblConfiguracao.TabIndex = 3;
			// 
			// frmExecutando
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(336, 356);
			this.Controls.Add(this.lblConfiguracao);
			this.Controls.Add(this.btnInicio);
			this.Controls.Add(this.btnParar);
			this.Controls.Add(this.pctGif);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(352, 395);
			this.MinimumSize = new System.Drawing.Size(352, 395);
			this.Name = "frmExecutando";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "App Move...";
			this.Load += new System.EventHandler(this.frm_Executando_Load);
			((System.ComponentModel.ISupportInitialize)(this.pctGif)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pctGif;
		private System.Windows.Forms.Button btnParar;
		private System.Windows.Forms.Button btnInicio;
		private System.Windows.Forms.Label lblConfiguracao;
	}
}

