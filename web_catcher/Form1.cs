using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace web_catcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void file_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void display_textBox_TextChanged(object sender, EventArgs e)
        {

        }



        private WebBrowser web_connecter = new WebBrowser();
        private string file_place;
        private static void system_record(ref RichTextBox box, string words, Color color)
        {
            box.Select(box.TextLength, 0);
            box.SelectionColor = Color.Black;
            box.AppendText("[" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "] \r\n");
            box.Select(box.TextLength, 0);
            box.SelectionColor = color;
            box.AppendText(words);
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            file_place = file_textBox.Text;
            if (string.IsNullOrWhiteSpace(file_place))
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = "C:";
                ofd.Filter = "Text Files (*.txt)|*.txt";//|All Files (*.*)|*.*";
                ofd.Title = "請開啟文字檔案";
                ofd.CheckFileExists = true;				  //檔案 不存在顯示錯誤訊息
                ofd.CheckPathExists = true;                 //路徑 不存在顯示錯誤訊息
                if (ofd.ShowDialog(this) == DialogResult.Cancel)
                    return;
                file_textBox.Text = ofd.FileName;
            }
            else if (file_place == "clear")
            {
                display_textBox.Clear();
                file_textBox.Clear();
                return;
            }
            else if(File.Exists(file_place))
            {
                system_record(ref display_textBox, "Start load\r\n", Color.Blue);

                StreamReader input_txt = new StreamReader(file_place);
                string target_url = input_txt.ReadLine();
                input_txt.Close();


                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(target_url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();

                    if (response.CharacterSet == null)
                    {
                        system_record(ref display_textBox, "ERROR : Get NULL string\r\n", Color.Red);
                        response.Close();
                        return ;
                    }

                    StreamReader readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    document_completed( readStream.ReadToEnd() );

                    response.Close();
                    readStream.Close();
                    system_record(ref display_textBox, "End load\r\n", Color.Green);
                }
                else
                {
                    system_record(ref display_textBox, "Return not ok\r\n", Color.Red);
                }
            }
            else
            {
                system_record(ref display_textBox, "ERROR : file is not exists\r\n", Color.Red);
            }
        }
        private void document_completed(string RowWebContent)
        {
            StreamWriter output_txt = new StreamWriter(file_place, true, Encoding.UTF8);

            remove_comment(ref RowWebContent);
            remove_javascript(ref RowWebContent);
            remove_htmltag(ref RowWebContent);
            remove_enter_space(ref RowWebContent);

            output_txt.WriteLine("#########################################################");
            output_txt.WriteLine(RowWebContent);
            output_txt.Close();
        }
        /*
        private void remove_button(ref string pure_data)
        {
            pure_data = Regex.Replace(pure_data, @"<[^>]*?(input\s*type\s*=\s*\"\s*button\s*\")[\s\S]*?>[\s\S]*?<[\s\S]*?>", "");
        }
        */
        private void remove_comment(ref string pure_data)
        {
            pure_data = Regex.Replace(pure_data, @"<!--[\s\S]*?-->", "");
        }

        private void remove_javascript(ref string pure_data)
        {
            pure_data = Regex.Replace(pure_data, @"<script[\d\D]*?>[\d\D]*?</script>", "");
            pure_data = Regex.Replace(pure_data, @"<noscript[\d\D]*?>[\d\D]*?</noscript>", "");
        }

        private void remove_htmltag(ref string pure_data)
        {
            pure_data = Regex.Replace(pure_data, @"<[^>]*>", "");
        }

        private void remove_enter_space(ref string pure_data)
        {
            pure_data = Regex.Replace(pure_data, @"\n[\n\s\t\f]*", "\n");
        }





        /*
        private void webbrowser_document_completed(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                 return; 
            StreamReader data_in = new StreamReader(web_connecter.DocumentStream, Encoding.UTF8);
            string RowWebContent = data_in.ReadToEnd();
            StreamWriter output_txt = new StreamWriter(file_place, true, Encoding.UTF8);

            remove_comment(ref RowWebContent);
            remove_javascript(ref RowWebContent);
            remove_htmltag(ref RowWebContent);
            remove_enter_space(ref RowWebContent);

            output_txt.WriteLine("#########################################################");
            output_txt.WriteLine(RowWebContent);
            output_txt.Close();
        }
        */
    }
}
