namespace MultiFaceRec
{
    partial class FaceDetectNRecognize
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.addFaceVideo = new System.Windows.Forms.Button();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.extFaceBox = new Emgu.CV.UI.ImageBox();
            this.resultBox = new System.Windows.Forms.GroupBox();
            this.persons = new System.Windows.Forms.Label();
            this.personLabel = new System.Windows.Forms.Label();
            this.faceLabel = new System.Windows.Forms.Label();
            this.faces = new System.Windows.Forms.Label();
            this.liveVideo = new System.Windows.Forms.Button();
            this.mainImageBox = new Emgu.CV.UI.ImageBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.browsePhoto = new System.Windows.Forms.Button();
            this.addFacePhoto = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.scaleLabel = new System.Windows.Forms.Label();
            this.neighbourLabel = new System.Windows.Forms.Label();
            this.detectionLabel = new System.Windows.Forms.Label();
            this.parametersBox = new System.Windows.Forms.GroupBox();
            this.comboBoxMinNeigh = new System.Windows.Forms.ComboBox();
            this.comboBoxScIncRate = new System.Windows.Forms.ComboBox();
            this.textBoxWinSize = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.extFaceBox)).BeginInit();
            this.resultBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainImageBox)).BeginInit();
            this.parametersBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // addFaceVideo
            // 
            this.addFaceVideo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.addFaceVideo.Location = new System.Drawing.Point(678, 250);
            this.addFaceVideo.Name = "addFaceVideo";
            this.addFaceVideo.Size = new System.Drawing.Size(203, 31);
            this.addFaceVideo.TabIndex = 3;
            this.addFaceVideo.Text = "Add Face For Video";
            this.addFaceVideo.UseVisualStyleBackColor = true;
            this.addFaceVideo.Click += new System.EventHandler(this.addFaceVideo_Click);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(727, 430);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(100, 20);
            this.nameBox.TabIndex = 7;
            this.nameBox.Text = "Enter Name";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(680, 433);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(41, 13);
            this.nameLabel.TabIndex = 8;
            this.nameLabel.Text = "Name: ";
            // 
            // extFaceBox
            // 
            this.extFaceBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.extFaceBox.Location = new System.Drawing.Point(727, 287);
            this.extFaceBox.Name = "extFaceBox";
            this.extFaceBox.Size = new System.Drawing.Size(100, 100);
            this.extFaceBox.TabIndex = 5;
            this.extFaceBox.TabStop = false;
            // 
            // resultBox
            // 
            this.resultBox.Controls.Add(this.persons);
            this.resultBox.Controls.Add(this.personLabel);
            this.resultBox.Controls.Add(this.faceLabel);
            this.resultBox.Controls.Add(this.faces);
            this.resultBox.Location = new System.Drawing.Point(678, 16);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(428, 228);
            this.resultBox.TabIndex = 9;
            this.resultBox.TabStop = false;
            this.resultBox.Text = "Results: ";
            // 
            // persons
            // 
            this.persons.AutoSize = true;
            this.persons.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.persons.ForeColor = System.Drawing.Color.Black;
            this.persons.Location = new System.Drawing.Point(9, 17);
            this.persons.Name = "persons";
            this.persons.Size = new System.Drawing.Size(198, 18);
            this.persons.TabIndex = 17;
            this.persons.Text = "Persons detected in the scene:";
            // 
            // personLabel
            // 
            this.personLabel.AutoSize = true;
            this.personLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personLabel.ForeColor = System.Drawing.Color.Blue;
            this.personLabel.Location = new System.Drawing.Point(9, 37);
            this.personLabel.Name = "personLabel";
            this.personLabel.Size = new System.Drawing.Size(57, 18);
            this.personLabel.TabIndex = 16;
            this.personLabel.Text = "Nobody";
            // 
            // faceLabel
            // 
            this.faceLabel.AutoSize = true;
            this.faceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.faceLabel.ForeColor = System.Drawing.Color.Red;
            this.faceLabel.Location = new System.Drawing.Point(178, 191);
            this.faceLabel.Name = "faceLabel";
            this.faceLabel.Size = new System.Drawing.Size(16, 16);
            this.faceLabel.TabIndex = 15;
            this.faceLabel.Text = "0";
            // 
            // faces
            // 
            this.faces.AutoSize = true;
            this.faces.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.faces.Location = new System.Drawing.Point(9, 189);
            this.faces.Name = "faces";
            this.faces.Size = new System.Drawing.Size(176, 18);
            this.faces.TabIndex = 14;
            this.faces.Text = "Number of faces detected: ";
            // 
            // liveVideo
            // 
            this.liveVideo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.liveVideo.Location = new System.Drawing.Point(908, 248);
            this.liveVideo.Name = "liveVideo";
            this.liveVideo.Size = new System.Drawing.Size(198, 33);
            this.liveVideo.TabIndex = 2;
            this.liveVideo.Text = "Start Web Cam";
            this.liveVideo.UseVisualStyleBackColor = true;
            this.liveVideo.Click += new System.EventHandler(this.liveVideo_Click);
            // 
            // mainImageBox
            // 
            this.mainImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainImageBox.Location = new System.Drawing.Point(12, 12);
            this.mainImageBox.Name = "mainImageBox";
            this.mainImageBox.Size = new System.Drawing.Size(640, 480);
            this.mainImageBox.TabIndex = 4;
            this.mainImageBox.TabStop = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // browsePhoto
            // 
            this.browsePhoto.Location = new System.Drawing.Point(908, 458);
            this.browsePhoto.Name = "browsePhoto";
            this.browsePhoto.Size = new System.Drawing.Size(198, 34);
            this.browsePhoto.TabIndex = 10;
            this.browsePhoto.Text = "Browse Photo";
            this.browsePhoto.UseVisualStyleBackColor = true;
            this.browsePhoto.Click += new System.EventHandler(this.browsePhoto_Click);
            // 
            // addFacePhoto
            // 
            this.addFacePhoto.Location = new System.Drawing.Point(678, 458);
            this.addFacePhoto.Name = "addFacePhoto";
            this.addFacePhoto.Size = new System.Drawing.Size(203, 34);
            this.addFacePhoto.TabIndex = 11;
            this.addFacePhoto.Text = "Add Face For Photo";
            this.addFacePhoto.UseVisualStyleBackColor = true;
            this.addFacePhoto.Click += new System.EventHandler(this.addFacePhoto_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.Enabled = false;
            this.buttonPrev.Location = new System.Drawing.Point(727, 393);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(37, 23);
            this.buttonPrev.TabIndex = 12;
            this.buttonPrev.Text = "<";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Enabled = false;
            this.buttonNext.Location = new System.Drawing.Point(792, 393);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(35, 25);
            this.buttonNext.TabIndex = 13;
            this.buttonNext.Text = ">";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // scaleLabel
            // 
            this.scaleLabel.AutoSize = true;
            this.scaleLabel.Location = new System.Drawing.Point(6, 26);
            this.scaleLabel.Name = "scaleLabel";
            this.scaleLabel.Size = new System.Drawing.Size(110, 13);
            this.scaleLabel.TabIndex = 14;
            this.scaleLabel.Text = "Scale Increase Rate :";
            // 
            // neighbourLabel
            // 
            this.neighbourLabel.AutoSize = true;
            this.neighbourLabel.Location = new System.Drawing.Point(6, 68);
            this.neighbourLabel.Name = "neighbourLabel";
            this.neighbourLabel.Size = new System.Drawing.Size(87, 13);
            this.neighbourLabel.TabIndex = 15;
            this.neighbourLabel.Text = "Min Neighbours :";
            // 
            // detectionLabel
            // 
            this.detectionLabel.AutoSize = true;
            this.detectionLabel.Location = new System.Drawing.Point(6, 110);
            this.detectionLabel.Name = "detectionLabel";
            this.detectionLabel.Size = new System.Drawing.Size(109, 26);
            this.detectionLabel.TabIndex = 16;
            this.detectionLabel.Text = "Min Detection Scale :\r\n(Window Size)";
            // 
            // parametersBox
            // 
            this.parametersBox.Controls.Add(this.comboBoxMinNeigh);
            this.parametersBox.Controls.Add(this.comboBoxScIncRate);
            this.parametersBox.Controls.Add(this.textBoxWinSize);
            this.parametersBox.Controls.Add(this.scaleLabel);
            this.parametersBox.Controls.Add(this.detectionLabel);
            this.parametersBox.Controls.Add(this.neighbourLabel);
            this.parametersBox.Location = new System.Drawing.Point(908, 287);
            this.parametersBox.Name = "parametersBox";
            this.parametersBox.Size = new System.Drawing.Size(198, 163);
            this.parametersBox.TabIndex = 17;
            this.parametersBox.TabStop = false;
            this.parametersBox.Text = "Tune Detection Parameters";
            // 
            // comboBoxMinNeigh
            // 
            this.comboBoxMinNeigh.FormattingEnabled = true;
            this.comboBoxMinNeigh.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBoxMinNeigh.Location = new System.Drawing.Point(116, 65);
            this.comboBoxMinNeigh.Name = "comboBoxMinNeigh";
            this.comboBoxMinNeigh.Size = new System.Drawing.Size(74, 21);
            this.comboBoxMinNeigh.TabIndex = 21;
            this.comboBoxMinNeigh.Text = "3";
            // 
            // comboBoxScIncRate
            // 
            this.comboBoxScIncRate.FormattingEnabled = true;
            this.comboBoxScIncRate.Items.AddRange(new object[] {
            "1.1",
            "1.2",
            "1.3",
            "1.4"});
            this.comboBoxScIncRate.Location = new System.Drawing.Point(116, 23);
            this.comboBoxScIncRate.Name = "comboBoxScIncRate";
            this.comboBoxScIncRate.Size = new System.Drawing.Size(74, 21);
            this.comboBoxScIncRate.TabIndex = 20;
            this.comboBoxScIncRate.Text = "1.1";
            // 
            // textBoxWinSize
            // 
            this.textBoxWinSize.Location = new System.Drawing.Point(116, 107);
            this.textBoxWinSize.Name = "textBoxWinSize";
            this.textBoxWinSize.Size = new System.Drawing.Size(74, 20);
            this.textBoxWinSize.TabIndex = 19;
            this.textBoxWinSize.Text = "25";
            // 
            // FaceDetectNRecognize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 559);
            this.Controls.Add(this.parametersBox);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.addFacePhoto);
            this.Controls.Add(this.addFaceVideo);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.browsePhoto);
            this.Controls.Add(this.extFaceBox);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.mainImageBox);
            this.Controls.Add(this.liveVideo);
            this.Name = "FaceDetectNRecognize";
            this.Text = "Suman\'s Face Detector and Recgonizer :-)";
            ((System.ComponentModel.ISupportInitialize)(this.extFaceBox)).EndInit();
            this.resultBox.ResumeLayout(false);
            this.resultBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainImageBox)).EndInit();
            this.parametersBox.ResumeLayout(false);
            this.parametersBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addFaceVideo;
        private Emgu.CV.UI.ImageBox mainImageBox;
        private Emgu.CV.UI.ImageBox extFaceBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.GroupBox resultBox;
        private System.Windows.Forms.Label persons;
        private System.Windows.Forms.Label personLabel;
        private System.Windows.Forms.Label faceLabel;
        private System.Windows.Forms.Label faces;
        private System.Windows.Forms.Button liveVideo;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button browsePhoto;
        private System.Windows.Forms.Button addFacePhoto;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label scaleLabel;
        private System.Windows.Forms.Label neighbourLabel;
        private System.Windows.Forms.Label detectionLabel;
        private System.Windows.Forms.GroupBox parametersBox;
        private System.Windows.Forms.ComboBox comboBoxMinNeigh;
        private System.Windows.Forms.ComboBox comboBoxScIncRate;
        private System.Windows.Forms.TextBox textBoxWinSize;
    }
}

