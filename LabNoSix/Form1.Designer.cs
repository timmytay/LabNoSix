namespace LabNoSix
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbDirection = new System.Windows.Forms.TrackBar();
            this.lblDirection = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbGraviton = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGraviton = new System.Windows.Forms.Label();
            this.chbGraviton = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSpreading = new System.Windows.Forms.Label();
            this.tbSpreading = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.lblParticlesPerTick = new System.Windows.Forms.Label();
            this.tbParticlesPerTick = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.lblLife = new System.Windows.Forms.Label();
            this.tbLife = new System.Windows.Forms.TrackBar();
            this.lblActiveParticles = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpreading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbParticlesPerTick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLife)).BeginInit();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.Location = new System.Drawing.Point(2, 12);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(622, 426);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            this.picDisplay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseClick);
            this.picDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbDirection
            // 
            this.tbDirection.Location = new System.Drawing.Point(630, 56);
            this.tbDirection.Maximum = 359;
            this.tbDirection.Name = "tbDirection";
            this.tbDirection.Size = new System.Drawing.Size(117, 45);
            this.tbDirection.TabIndex = 1;
            this.tbDirection.Scroll += new System.EventHandler(this.tbDirection_Scroll);
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Location = new System.Drawing.Point(753, 66);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(17, 13);
            this.lblDirection.TabIndex = 2;
            this.lblDirection.Text = "0°";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(638, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Направление";
            // 
            // tbGraviton
            // 
            this.tbGraviton.Location = new System.Drawing.Point(630, 379);
            this.tbGraviton.Maximum = 100;
            this.tbGraviton.Name = "tbGraviton";
            this.tbGraviton.Size = new System.Drawing.Size(104, 45);
            this.tbGraviton.TabIndex = 4;
            this.tbGraviton.Value = 50;
            this.tbGraviton.Scroll += new System.EventHandler(this.tbGraviton_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(638, 363);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Размер гравитона";
            // 
            // lblGraviton
            // 
            this.lblGraviton.AutoSize = true;
            this.lblGraviton.Location = new System.Drawing.Point(753, 379);
            this.lblGraviton.Name = "lblGraviton";
            this.lblGraviton.Size = new System.Drawing.Size(37, 13);
            this.lblGraviton.TabIndex = 6;
            this.lblGraviton.Text = "50 ед.";
            // 
            // chbGraviton
            // 
            this.chbGraviton.AutoSize = true;
            this.chbGraviton.Location = new System.Drawing.Point(641, 407);
            this.chbGraviton.Name = "chbGraviton";
            this.chbGraviton.Size = new System.Drawing.Size(95, 17);
            this.chbGraviton.TabIndex = 7;
            this.chbGraviton.Text = "Присутствует";
            this.chbGraviton.UseVisualStyleBackColor = true;
            this.chbGraviton.CheckedChanged += new System.EventHandler(this.chbGraviton_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(638, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Разброс";
            // 
            // lblSpreading
            // 
            this.lblSpreading.AutoSize = true;
            this.lblSpreading.Location = new System.Drawing.Point(753, 117);
            this.lblSpreading.Name = "lblSpreading";
            this.lblSpreading.Size = new System.Drawing.Size(17, 13);
            this.lblSpreading.TabIndex = 9;
            this.lblSpreading.Text = "0°";
            // 
            // tbSpreading
            // 
            this.tbSpreading.Location = new System.Drawing.Point(630, 107);
            this.tbSpreading.Maximum = 359;
            this.tbSpreading.Name = "tbSpreading";
            this.tbSpreading.Size = new System.Drawing.Size(117, 45);
            this.tbSpreading.TabIndex = 8;
            this.tbSpreading.Scroll += new System.EventHandler(this.tbSpreading_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(638, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Скорость";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(746, 168);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(47, 13);
            this.lblSpeed.TabIndex = 12;
            this.lblSpeed.Text = "10 см/с";
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(630, 158);
            this.tbSpeed.Maximum = 30;
            this.tbSpeed.Minimum = 5;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(117, 45);
            this.tbSpeed.TabIndex = 11;
            this.tbSpeed.Value = 10;
            this.tbSpeed.Scroll += new System.EventHandler(this.tbSpeed_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(638, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Кол-во частиц за тик";
            // 
            // lblParticlesPerTick
            // 
            this.lblParticlesPerTick.AutoSize = true;
            this.lblParticlesPerTick.Location = new System.Drawing.Point(753, 219);
            this.lblParticlesPerTick.Name = "lblParticlesPerTick";
            this.lblParticlesPerTick.Size = new System.Drawing.Size(49, 13);
            this.lblParticlesPerTick.TabIndex = 15;
            this.lblParticlesPerTick.Text = "10 ч/тик";
            // 
            // tbParticlesPerTick
            // 
            this.tbParticlesPerTick.Location = new System.Drawing.Point(630, 209);
            this.tbParticlesPerTick.Maximum = 40;
            this.tbParticlesPerTick.Minimum = 1;
            this.tbParticlesPerTick.Name = "tbParticlesPerTick";
            this.tbParticlesPerTick.Size = new System.Drawing.Size(117, 45);
            this.tbParticlesPerTick.TabIndex = 14;
            this.tbParticlesPerTick.Value = 10;
            this.tbParticlesPerTick.Scroll += new System.EventHandler(this.tbParticlesPerTick_Scroll);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(638, 244);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(157, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Период жизни частиц в тиках";
            // 
            // lblLife
            // 
            this.lblLife.AutoSize = true;
            this.lblLife.Location = new System.Drawing.Point(753, 270);
            this.lblLife.Name = "lblLife";
            this.lblLife.Size = new System.Drawing.Size(36, 13);
            this.lblLife.TabIndex = 18;
            this.lblLife.Text = "100 т.";
            // 
            // tbLife
            // 
            this.tbLife.Location = new System.Drawing.Point(630, 260);
            this.tbLife.Maximum = 200;
            this.tbLife.Minimum = 20;
            this.tbLife.Name = "tbLife";
            this.tbLife.Size = new System.Drawing.Size(117, 45);
            this.tbLife.TabIndex = 17;
            this.tbLife.Value = 100;
            this.tbLife.Scroll += new System.EventHandler(this.trackBar4_Scroll);
            // 
            // lblActiveParticles
            // 
            this.lblActiveParticles.AutoSize = true;
            this.lblActiveParticles.Location = new System.Drawing.Point(638, 12);
            this.lblActiveParticles.Name = "lblActiveParticles";
            this.lblActiveParticles.Size = new System.Drawing.Size(58, 13);
            this.lblActiveParticles.TabIndex = 20;
            this.lblActiveParticles.Text = "Частицы: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(805, 450);
            this.Controls.Add(this.lblActiveParticles);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblLife);
            this.Controls.Add(this.tbLife);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblParticlesPerTick);
            this.Controls.Add(this.tbParticlesPerTick);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.tbSpeed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSpreading);
            this.Controls.Add(this.tbSpreading);
            this.Controls.Add(this.chbGraviton);
            this.Controls.Add(this.lblGraviton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbGraviton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDirection);
            this.Controls.Add(this.tbDirection);
            this.Controls.Add(this.picDisplay);
            this.Name = "Form1";
            this.Text = "Система частиц";
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpreading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbParticlesPerTick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLife)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar tbDirection;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tbGraviton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblGraviton;
        private System.Windows.Forms.CheckBox chbGraviton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSpreading;
        private System.Windows.Forms.TrackBar tbSpreading;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblParticlesPerTick;
        private System.Windows.Forms.TrackBar tbParticlesPerTick;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblLife;
        private System.Windows.Forms.TrackBar tbLife;
        private System.Windows.Forms.Label lblActiveParticles;
    }
}

