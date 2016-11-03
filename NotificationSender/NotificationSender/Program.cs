using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace NotificationSender
{
    public static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>

        public static string applicationID = DataConfigs.ReadSetting("applicationID");
        public static string senderId = DataConfigs.ReadSetting("senderId");
        public static WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void send(dynamic data)
        {
            string str = string.Empty;
            try
            {
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                tRequest.ContentLength = byteArray.Length;
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                str = sResponseFromServer;
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}       
       public static void SendToOne(string TokenId, string Message, string Title)
        {
            try
            {
                var dat = new
                {
                    to = TokenId,
                    data = new
                    {
                        msg = Message,
                        sound = "Enabled"
                    }
                };
                send(dat);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }
        public static void SendToTopic(string topic, string message, string titles)
        {
            try
            {
                var data = new
                {
                    to = "/topics/"+topic,
                    data = new
                    {
                        body = message,
                        title = titles,
                        sound = "Enabled"
                    }
                };
                send(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void sendToFew(string[] tokens, string message, string titles)
        {
            try
            {
                var data = new
                {
                    registration_ids = tokens,
                    priority = "high",
                    notification = new
                    {
                        title = titles,
                        body = message,
						sound = "Enabled"
					}
                };
                send(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
