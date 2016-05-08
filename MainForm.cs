//Multiple face detection and recognition in real time as well as in still images
//Using EmguCV cross platform .Net wrapper to the Intel OpenCV image processing library for C#.Net

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Diagnostics;

namespace MultiFaceRec
{
    public partial class FaceDetectNRecognize : Form
    {
        //Declararation of all variables, vectors and haarcascades
        Image<Bgr, Byte> currentFrame;
        Capture capture;
        HaarCascade haar;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.6d, 0.6d);
        Image<Gray, byte> result, TrainedFace = null, currentFace;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> NamePersons = new List<string>();
        int ContTrain, NumLabels, total;
        string name, names = null;
        Image<Bgr, Byte> TestImage;
        Image<Bgr, Byte> myImage;

        //to store the extracted images
        Bitmap[] ExtFaces;


        //Let's set the default values of the parameters, to be use as a variable in call to DetectHaarCascase()
        private int WindowSize = 25;
        private Double ScaleIncreaseRate = 1.1;
        private int MinNeighbours = 3;

        //To count the no of faces
        int faceNo = 0;

        public FaceDetectNRecognize()
        {
            InitializeComponent();
            //Load haarcascades for face detection
            haar = new HaarCascade("haarcascade_frontalface_alt_tree.xml");

            try
            {
                //Load of previus trainned faces and labels for each image
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;

                for (int tf = 1; tf < NumLabels + 1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                    labels.Add(Labels[tf]);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button).", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void liveVideo_Click(object sender, EventArgs e)
        {
            if (capture == null)
            {
                try
                {
                    capture = new Capture();
                    capture.QueryFrame();
                }
                catch (NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
            }

            if (capture != null)
            {
                if (liveVideo.Text == "Detect Face")
                {   //if camera is getting frames then stop the capture and set button Text
                    // to "Resume Live Video" for resuming capture
                    liveVideo.Text = "Resume Live Video";
                    Application.Idle -= new EventHandler(FrameGrabberVideo);

                    //Call face detection
                    ExtractFaceVideo();
                }
                else
                {
                    //if camera is NOT getting frames then start the capture and set button
                    // Text to "Detect Face" for pausing capture
                    liveVideo.Text = "Detect Face";
                    Application.Idle += new EventHandler(FrameGrabberVideo);
                }

            }
        }
        void FrameGrabberVideo(object sender, EventArgs e)
        {
            try
            {
                ScaleIncreaseRate = Double.Parse(comboBoxScIncRate.Text);   //the 2nd parameter
                MinNeighbours = int.Parse(comboBoxMinNeigh.Text);   //the 3rd parameter
                WindowSize = int.Parse(textBoxWinSize.Text);    //the 5th parameter

                faceLabel.Text = "0";
                personLabel.Text = "";
                NamePersons.Add("");

                //Get the current frame form capture device
                currentFrame = capture.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                //Convert it to Grayscale
                gray = currentFrame.Convert<Gray, Byte>();

                //Face Detector
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                haar,
                ScaleIncreaseRate,
                MinNeighbours,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new Size(WindowSize, WindowSize));

                //Action for each element detected
                foreach (MCvAvgComp face in facesDetected[0])
                {
                    total = total + 1;
                    result = currentFrame.Copy(face.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    //draw the face detected in the 0th (gray) channel with blue color
                    currentFrame.Draw(face.rect, new Bgr(Color.Red), 2);


                    if (trainingImages.ToArray().Length != 0)
                    {
                        //TermCriteria for face recognition with numbers of trained images like maxIteration
                        MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                        //Eigen face recognizer
#pragma warning disable CS0436
                        // Type conflicts with imported type
                        EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
#pragma warning disable CS0436
                        // Type conflicts with imported type
#pragma warning restore CS0436
                        // Type conflicts with imported type
                        trainingImages.ToArray(),
#pragma warning restore CS0436
                        // Type conflicts with imported type
                        labels.ToArray(),
                               3000,
                               ref termCrit);

                        name = recognizer.Recognize(result);
                        //Draw the label for each face detected and recognized
                        currentFrame.Draw(name, ref font, new Point(face.rect.X - 2, face.rect.Y - 2), new Bgr(Color.Red));
                    }

                    NamePersons[total - 1] = name;
                    NamePersons.Add("");

                    //Set the number of faces detected on the scene
                    faceLabel.Text = facesDetected[0].Length.ToString();
                }
                total = 0;

                //Names concatenation of persons recognized
                for (int n = 0; n < facesDetected[0].Length; n++)
                {
                    names = names + NamePersons[n] + ", ";
                }

                //Show the faces procesed and recognized
                mainImageBox.Image = currentFrame;
                personLabel.Text = names;
                names = "";

                //Clear the list(vector) of names
                NamePersons.Clear();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (FormatException)
            {

                MessageBox.Show("Windows Size cannot be Null");
            }
        }

        private void ExtractFaceVideo()
        {
            //Get the current frame form capture device
            currentFrame = capture.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //convert the image to grey scale
            Image<Gray, byte> grayframe = currentFrame.Convert<Gray, byte>();
            haar = new HaarCascade("haarcascade_frontalface_alt_tree.xml");

            //assign user-defined values to parameter variables
            try
            {
                ScaleIncreaseRate = Double.Parse(comboBoxScIncRate.Text);   //the 2nd parameter
                MinNeighbours = int.Parse(comboBoxMinNeigh.Text);   //the 3rd parameter
                WindowSize = int.Parse(textBoxWinSize.Text);    //the 5th parameter

                var faces = grayframe.DetectHaarCascade(
                    haar,
                    ScaleIncreaseRate,
                    MinNeighbours,
                    Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                    new Size(WindowSize, WindowSize))[0];
                if (faces.Length > 0)
                {
                    Bitmap BmpInput = grayframe.ToBitmap();
                    Bitmap ExtractedFace; //empty
                    Graphics FaceCanvas;
                    ExtFaces = new Bitmap[faces.Length];
                    faceNo = 0;

                    //draw a green rectangle on each detected face in image
                    foreach (var face in faces)
                    {
                        //set the size of the empty box(ExtractedFace) which will later contain the face
                        ExtractedFace = new Bitmap(face.rect.Width, face.rect.Height);

                        //set empty image as FaceCanvas, for painting
                        FaceCanvas = Graphics.FromImage(ExtractedFace);

                        FaceCanvas.DrawImage(BmpInput, 0, 0, face.rect, GraphicsUnit.Pixel);

                        ExtFaces[faceNo] = ExtractedFace;
                        faceNo++;
                    }
                    faceNo = 0;
                    myImage = new Image<Bgr, Byte>(ExtFaces[faceNo]);
                    extFaceBox.Image = myImage.Resize(100, 100, INTER.CV_INTER_CUBIC);

                    //enable the previous and next button
                    buttonPrev.Enabled = true;
                    buttonNext.Enabled = true;
                }
                else
                    MessageBox.Show("No Face Detected !");

            }
            //Catch statement to prevent null value of window size
            catch (FormatException)
            {
                MessageBox.Show("Windows Size cannot be Null");
            }
        }



        private void addFaceVideo_Click(object sender, System.EventArgs e)
        {
            try
            {
                ScaleIncreaseRate = Double.Parse(comboBoxScIncRate.Text);   //the 2nd parameter
                MinNeighbours = int.Parse(comboBoxMinNeigh.Text);   //the 3rd parameter
                WindowSize = int.Parse(textBoxWinSize.Text);    //the 5th parameter

                //Trained face counter
                ContTrain = ContTrain + 1;

                //Get a gray frame from capture device
                gray = capture.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                //Face Detector
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                haar,
                ScaleIncreaseRate,
                MinNeighbours,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new Size(WindowSize, WindowSize));

                //Action for each element detected
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                    break;
                }

                //resize face detected image for force to compare the same size with the 
                //test image with cubic interpolation type method

                currentFace = myImage.Convert<Gray, byte>();
                TrainedFace = currentFace.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                trainingImages.Add(TrainedFace);
                labels.Add(nameBox.Text);

                //Write the number of triained faces in a file text for further load
                File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");

                //Write the labels of triained faces in a file text for further load
                for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                {
                    trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/face" + i + ".bmp");
                    File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                }

                MessageBox.Show(nameBox.Text + "'s face detected and added :)", "Training OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Enable the face detection first", "Training Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void browsePhoto_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image InputImg = Image.FromFile(openFileDialog.FileName);
                TestImage = new Image<Bgr, byte>(new Bitmap(InputImg)).Resize(0.8, INTER.CV_INTER_CUBIC);
                mainImageBox.Image = TestImage;

                //Initialize the FrameGraber event
                Application.Idle += new EventHandler(FrameGrabberImage);
                ExtractFaceImage();

            }
        }

        void FrameGrabberImage(object sender, EventArgs e)
        {
            try
            {
                ScaleIncreaseRate = Double.Parse(comboBoxScIncRate.Text);   //the 2nd parameter
                MinNeighbours = int.Parse(comboBoxMinNeigh.Text);   //the 3rd parameter
                WindowSize = int.Parse(textBoxWinSize.Text);    //the 5th parameter

                faceLabel.Text = "0";
                personLabel.Text = "";
                NamePersons.Add("");
                gray = TestImage.Convert<Gray, Byte>();
                //Face Detector

                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                haar,
                ScaleIncreaseRate,
                MinNeighbours,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new Size(WindowSize, WindowSize));

                //Action for each element detected
                foreach (MCvAvgComp face in facesDetected[0])
                {
                    total = total + 1;
                    result = TestImage.Copy(face.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                    //draw the face detected in the 0th (gray) channel with blue color
                    TestImage.Draw(face.rect, new Bgr(Color.Red), 2);
                    if (trainingImages.ToArray().Length != 0)
                    {
                        //TermCriteria for face recognition with numbers of trained images like maxIteration
                        MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                        //Eigen face recognizer
#pragma warning disable CS0436
                        // Type conflicts with imported type
                        EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
#pragma warning disable CS0436
                        // Type conflicts with imported type
#pragma warning restore CS0436
                        // Type conflicts with imported type
                        trainingImages.ToArray(),
#pragma warning restore CS0436
                            // Type conflicts with imported type
                            labels.ToArray(),
                            3000,
                            ref termCrit);

                        name = recognizer.Recognize(result);

                        //Draw the label for each face detected and recognized
                        TestImage.Draw(name, ref font, new Point(face.rect.X - 2, face.rect.Y - 2), new Bgr(Color.Red));
                    }

                    NamePersons[total - 1] = name;
                    NamePersons.Add("");

                    //Set the number of faces detected on the scene
                    faceLabel.Text = facesDetected[0].Length.ToString();
                }
                total = 0;

                //Names concatenation of persons recognized
                for (int n = 0; n < facesDetected[0].Length; n++)
                {
                    names = names + NamePersons[n] + ", ";
                }
                //Show the faces procesed and recognized
                mainImageBox.Image = TestImage;
                personLabel.Text = names;
                names = "";
                //Clear the list(vector) of names
                NamePersons.Clear();

            }
            catch (NullReferenceException)
            {

            }
        }

        private void ExtractFaceImage()
        {
            //convert the image to grey scale
            Image<Gray, byte> grayframe = TestImage.Convert<Gray, byte>();
            haar = new HaarCascade("haarcascade_frontalface_alt_tree.xml");

            //assign user-defined values to parameter variables
            try
            {
                ScaleIncreaseRate = Double.Parse(comboBoxScIncRate.Text);   //the 2nd parameter
                MinNeighbours = int.Parse(comboBoxMinNeigh.Text);   //the 3rd parameter
                WindowSize = int.Parse(textBoxWinSize.Text);    //the 5th parameter

                var faces = grayframe.DetectHaarCascade(haar, ScaleIncreaseRate, MinNeighbours,
                    Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                    new Size(WindowSize, WindowSize))[0];
                if (faces.Length > 0)
                {
                    Bitmap BmpInput = grayframe.ToBitmap();
                    Bitmap ExtractedFace; //empty
                    Graphics FaceCanvas;
                    ExtFaces = new Bitmap[faces.Length];
                    faceNo = 0;

                    //draw a green rectangle on each detected face in image
                    foreach (var face in faces)
                    {
                        //set the size of the empty box(ExtractedFace) which will later contain the face
                        ExtractedFace = new Bitmap(face.rect.Width, face.rect.Height);

                        //set empty image as FaceCanvas, for painting
                        FaceCanvas = Graphics.FromImage(ExtractedFace);
                        FaceCanvas.DrawImage(BmpInput, 0, 0, face.rect, GraphicsUnit.Pixel);
                        ExtFaces[faceNo] = ExtractedFace;
                        faceNo++;
                    }
                    faceNo = 0;
                    myImage = new Image<Bgr, Byte>(ExtFaces[faceNo]);
                    extFaceBox.Image = myImage.Resize(100, 100, INTER.CV_INTER_CUBIC);

                    //enable the previous and next button
                    buttonPrev.Enabled = true;
                    buttonNext.Enabled = true;
                }
                else
                    MessageBox.Show("No Face Detected !");
            }

            //Catch statement to prevent null value of window size
            catch (FormatException)
            {
                MessageBox.Show("Windows Size cannot be Null");
            }

        }

        private void addFacePhoto_Click(object sender, EventArgs e)
        {
            try
            {
                ScaleIncreaseRate = Double.Parse(comboBoxScIncRate.Text);   //the 2nd parameter
                MinNeighbours = int.Parse(comboBoxMinNeigh.Text);   //the 3rd parameter
                WindowSize = int.Parse(textBoxWinSize.Text);    //the 5th parameter

                //Trained face counter
                ContTrain = ContTrain + 1;

                //Get a gray frame from capture device
                gray = myImage.Convert<Gray, byte>();

                //Face Detector
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                haar,
                ScaleIncreaseRate,
                MinNeighbours,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new Size(WindowSize, WindowSize));

                //Action for each element detected
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    TrainedFace = myImage.Copy(f.rect).Convert<Gray, byte>();

                    break;
                }

                //resize face detected image for force to compare the same size with the 
                //test image with cubic interpolation type method
                currentFace = myImage.Convert<Gray, byte>();
                TrainedFace = currentFace.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                trainingImages.Add(TrainedFace);
                labels.Add(nameBox.Text);

                //Write the number of triained faces in a file text for further load
                File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");

                //Write the labels of triained faces in a file text for further load
                for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                {
                    trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/face" + i + ".bmp");
                    File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                }

                MessageBox.Show(nameBox.Text + "'s face detected and added :)", "Training OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Enable the face detection first", "Training Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (faceNo > 0)
            {
                faceNo--;
                myImage = new Image<Bgr, Byte>(ExtFaces[faceNo]);
                extFaceBox.Image = myImage.Resize(100, 100, INTER.CV_INTER_CUBIC);
            }
            else
                MessageBox.Show("First Image!");
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (faceNo < ExtFaces.Length - 1)
            {
                faceNo++;
                myImage = new Image<Bgr, Byte>(ExtFaces[faceNo]);
                extFaceBox.Image = myImage.Resize(100, 100, INTER.CV_INTER_CUBIC);
            }
            else
                MessageBox.Show("Last Image!");
        }
    }
}