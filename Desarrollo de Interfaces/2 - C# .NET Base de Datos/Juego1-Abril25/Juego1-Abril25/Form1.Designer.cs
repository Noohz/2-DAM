namespace Juego1_Abril25
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.fLPJuego = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTObservar = new System.Windows.Forms.Label();
            this.lblTJuego = new System.Windows.Forms.Label();
            this.lblPuntuacion = new System.Windows.Forms.Label();
            this.btnImagenBuscada = new System.Windows.Forms.Button();
            this.timerObservar = new System.Windows.Forms.Timer(this.components);
            this.timerJugar = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cBNiveles = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fLPJuego
            // 
            this.fLPJuego.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fLPJuego.Location = new System.Drawing.Point(12, 85);
            this.fLPJuego.Name = "fLPJuego";
            this.fLPJuego.Size = new System.Drawing.Size(776, 361);
            this.fLPJuego.TabIndex = 0;
            // 
            // lblTObservar
            // 
            this.lblTObservar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTObservar.Location = new System.Drawing.Point(534, 26);
            this.lblTObservar.Name = "lblTObservar";
            this.lblTObservar.Size = new System.Drawing.Size(175, 29);
            this.lblTObservar.TabIndex = 1;
            this.lblTObservar.Text = "¡Visualizando!";
            this.lblTObservar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTJuego
            // 
            this.lblTJuego.AutoSize = true;
            this.lblTJuego.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTJuego.Location = new System.Drawing.Point(730, 23);
            this.lblTJuego.Name = "lblTJuego";
            this.lblTJuego.Size = new System.Drawing.Size(46, 31);
            this.lblTJuego.TabIndex = 2;
            this.lblTJuego.Text = "10";
            // 
            // lblPuntuacion
            // 
            this.lblPuntuacion.AutoSize = true;
            this.lblPuntuacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuntuacion.Location = new System.Drawing.Point(169, 22);
            this.lblPuntuacion.Name = "lblPuntuacion";
            this.lblPuntuacion.Size = new System.Drawing.Size(40, 42);
            this.lblPuntuacion.TabIndex = 3;
            this.lblPuntuacion.Text = "0";
            // 
            // btnImagenBuscada
            // 
            this.btnImagenBuscada.Enabled = false;
            this.btnImagenBuscada.Location = new System.Drawing.Point(419, 9);
            this.btnImagenBuscada.Name = "btnImagenBuscada";
            this.btnImagenBuscada.Size = new System.Drawing.Size(88, 67);
            this.btnImagenBuscada.TabIndex = 4;
            this.btnImagenBuscada.UseVisualStyleBackColor = true;
            // 
            // timerObservar
            // 
            this.timerObservar.Interval = 1000;
            this.timerObservar.Tick += new System.EventHandler(this.timerObservar_Tick);
            // 
            // timerJugar
            // 
            this.timerJugar.Interval = 1000;
            this.timerJugar.Tick += new System.EventHandler(this.timerJugar_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 42);
            this.label1.TabIndex = 5;
            this.label1.Text = "Puntos";
            // 
            // cBNiveles
            // 
            this.cBNiveles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBNiveles.FormattingEnabled = true;
            this.cBNiveles.Location = new System.Drawing.Point(258, 36);
            this.cBNiveles.Name = "cBNiveles";
            this.cBNiveles.Size = new System.Drawing.Size(121, 21);
            this.cBNiveles.TabIndex = 6;
            this.cBNiveles.SelectedIndexChanged += new System.EventHandler(this.cBNiveles_SelectedIndexChanged);
            this.cBNiveles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cBNiveles_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(254, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Elije un nivel";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 458);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cBNiveles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImagenBuscada);
            this.Controls.Add(this.lblPuntuacion);
            this.Controls.Add(this.lblTJuego);
            this.Controls.Add(this.lblTObservar);
            this.Controls.Add(this.fLPJuego);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fLPJuego;
        private System.Windows.Forms.Label lblTObservar;
        private System.Windows.Forms.Label lblTJuego;
        private System.Windows.Forms.Label lblPuntuacion;
        private System.Windows.Forms.Button btnImagenBuscada;
        private System.Windows.Forms.Timer timerObservar;
        private System.Windows.Forms.Timer timerJugar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBNiveles;
        private System.Windows.Forms.Label label2;
    }
}

