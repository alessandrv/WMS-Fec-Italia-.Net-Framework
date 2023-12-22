
using System;
using System.Configuration;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using WMS_Fec_Italia.Net_Framework.Properties;

namespace WMS_Fec_Italia_MVC
{
    public partial class Fotocamera : Form
    {

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        public Fotocamera()
        {
            InitializeComponent();
        }
        private void Fotocamera_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count > 0)
            {
                MessageBox.Show(videoDevices.Count.ToString());
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                videoSource.Start();
            }
            else
            {
                MessageBox.Show("Nessuna fotocamera trovata.");
            }
        }
        private Bitmap currentFrame;

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            currentFrame = (Bitmap)eventArgs.Frame.Clone();
            if (Settings.Default.flipWebcam)
            {
                //Il tablet ha la fotocamera capovolta quindi capovolgo l'immagine
                currentFrame.RotateFlip(RotateFlipType.RotateNoneFlipXY);
            }
          
            pictureBox1.Image = currentFrame;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (currentFrame != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Immagini JPEG|*.jpg|Tutti i file|*.*";
                saveFileDialog.Title = "Salva immagine";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFrame.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    MessageBox.Show("Immagine salvata con successo.");

                    // Invia l'immagine via email
                    InviaEmail(saveFileDialog.FileName);
                }
            }
            else
            {
                MessageBox.Show("Nessuna immagine da salvare.");
            }
        }
        private void Fotocamera_Leave(object sender, FormClosingEventArgs e)
        {

        }

        private void Fotocamera_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
              
                videoSource.WaitForStop();
            }
        }

        private void InviaEmail(string attachmentPath)
        {
            try
            {
                string emailMittente = Settings.Default.emailMittente;
                string password = Settings.Default.emailPassword;
                string emailDestinatario = Settings.Default.emailDestinatario;
                string smtpTargetName = Settings.Default.smtpTargetName;
                string smtpServer = Settings.Default.smtpServer;
                // Configura il client Smtp per l'invio delle email
                SmtpClient smtpClient = new SmtpClient(smtpServer);
                smtpClient.EnableSsl = true;

                smtpClient.Port = 587;
                if (smtpTargetName != "")
                {
                    smtpClient.TargetName = smtpTargetName;
                }
                
                
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                NetworkCredential Credentials = new NetworkCredential(emailMittente, password);
                smtpClient.Credentials = Credentials;
                // Configura il messaggio email
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(emailMittente);
                mailMessage.To.Add(emailDestinatario);
                mailMessage.Subject = "Merce non conforme segnalata";
                mailMessage.Body = "Merce danneggiata segnalata in magazzino.";

                // Allega l'immagine all'email
                Attachment attachment = new Attachment(attachmentPath);
                mailMessage.Attachments.Add(attachment);

                // Invia l'email
                smtpClient.Send(mailMessage);

                MessageBox.Show("Email inviata con successo.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante l'invio dell'email: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
